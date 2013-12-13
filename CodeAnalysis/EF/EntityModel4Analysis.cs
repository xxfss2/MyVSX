using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using CodeProduce .BaseCode ;

//-------------xxfss2----------------------------------------------------//
//-------------2012-2-27-----------------------------------------------//
//-------------http://www.cnblogs.com/xxfss2--------------------//
namespace CodeProduce.CodeAnalysis
{
    /// <summary>
    /// 分析XML文件，获取模型信息
    /// </summary>
    public class EntityModel4Analysis : CodeAnysis
    {
        private const string RUNTIME = "Runtime";
        private const string DESIGNER = "Designer";

        private const string STORAGEMODEL="StorageModels";
        private const string CONCEPTUALMODEL="ConceptualModels";
        private const string MAPPINGS="Mappings";
        /// <summary>
        /// 
        /// </summary>
        private string _nameSpace;
        private XElement _ConceptualModelsNode;
        public XElement StorageModelsNode { get; private set; }
        public XElement ConceptualModelsNode
        {
            get
            {
                return (XElement)_ConceptualModelsNode.FirstNode;
            }
            private set
            {
                _ConceptualModelsNode = value;
            }
        }
        public XElement MappingsNode { get; private set; }
        public XElement DesignTimeNode { get; private set; }

        public EntityModel4Analysis()
        {

        }
        public override bool Connetion(string fileName)
        {
            XElement entityModel = XElement.Load(fileName);
            string ns = entityModel.Name.NamespaceName;
            XElement runTimeNode = entityModel.Element(XName.Get(RUNTIME, ns));
            this.StorageModelsNode = runTimeNode.Element(XName.Get(STORAGEMODEL, ns));
            this.ConceptualModelsNode = runTimeNode.Element(XName.Get(CONCEPTUALMODEL, ns));
            _nameSpace = this.ConceptualModelsNode.Attribute(XName.Get("Namespace", "")).Value;
            this.MappingsNode = runTimeNode.Element(XName.Get(MAPPINGS, ns));
            this.DesignTimeNode = entityModel.Element(XName.Get(DESIGNER, ns));
            return true;
        }

        private IEnumerable<XElement> GetEntityNodes()
        {
            string nameSpace = this.ConceptualModelsNode.Name.NamespaceName;
            return ConceptualModelsNode.Elements(XName.Get("EntityType", nameSpace));
        }

        public override IEnumerable<EntityInfo> GetEntitys()
        {
            IEnumerable<XElement> elements = this.GetEntityNodes();
            foreach (XElement element in elements)
            {
                yield return AnalysisEntityNode(element);
            }
        }

        public EntityInfo AnalysisEntityNode(XElement entityNode)
        {
            //string nameSpace = this.ConceptualModelsNode.Name.NamespaceName;
            EntityInfo entity = new EntityInfo();
            entity.Name = entityNode.Attribute(XName.Get("Name", "")).Value;
            //普通属性解析
            IEnumerable <XElement> propertys=entityNode .Elements (XName .Get ("Property",entityNode .Name .NamespaceName));
            XElement keyNode=entityNode .Element (XName .Get ("Key",entityNode .Name .NamespaceName));
            IEnumerable<XElement> keys = keyNode.Elements(XName.Get("PropertyRef", entityNode.Name.NamespaceName));
            foreach (XElement element in propertys)
            {
                FieldInfo filed = new FieldInfo();
                filed.Name = element.Attribute(XName.Get("Name", "")).Value;
                foreach (XElement key in keys)
                {
                    string keyName = key.Attribute(XName.Get("Name", "")).Value;
                    if (keyName == filed.Name)
                    {
                        filed.MainKey = true;
                        break;
                    }
                }
                filed.DataType = element.Attribute(XName.Get("Type", "")).Value;
                filed.Nullable = element.Attribute(XName.Get("Nullable", "")) == null ? false : Convert.ToBoolean(element.Attribute(XName.Get("Nullable", "")).Value);
                entity.Fields.Add(filed);
            }
            //导航属性解析
            IEnumerable<XElement> navigationPropertys = entityNode.Elements(XName.Get("NavigationProperty", entityNode.Name.NamespaceName));
            IEnumerable<XElement> associations = ConceptualModelsNode.Elements(XName.Get("Association", entityNode.Name.NamespaceName)).ToList ();
            foreach (XElement navigation in navigationPropertys)
            {
                string relationship = navigation.Attribute(XName.Get("Relationship", "")).Value ;
                relationship = relationship.Substring(_nameSpace.Length + 1);
                XElement association = associations.Where(s => s.Attribute(XName.Get("Name", "")).Value == relationship).FirstOrDefault();
                //获取当前导航属性的 收、发件 角色信息
                //当收、发件角色均为当前实体对象本身时（自关联的导航属性），取第一个
                IEnumerable<XElement> relations = association.Elements(XName.Get("End", entityNode.Name.NamespaceName));
                XElement entityType = relations.Where(s => s.Attribute("Type").Value.Substring(_nameSpace.Length + 1) != entity.Name).FirstOrDefault();
                if (entityType == null)
                    entityType = relations.FirstOrDefault();
                ComplexFieldInfo field = new ComplexFieldInfo();
                field .DataType =field.Name = entityType.Attribute(XName.Get("Type", "")).Value.Substring (_nameSpace.Length + 1);
                field.Name = navigation.Attribute(XName.Get("Name", "")).Value;
                string isMultiValue=entityType.Attribute(XName.Get("Multiplicity", "")).Value ;
                field.IsMulti = isMultiValue == "1" || isMultiValue == "0..1" ? false : true;
                entity.Fields.Add(field);
            }
            return entity;
        }

    }
}
