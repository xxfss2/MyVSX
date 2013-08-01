using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Xml .Linq ;
using CodeProduce .BaseCode ;

namespace CodeProduce.Temp
{
    public class EditIocConfigFile : CodeBuildService
    {
        private XDocument _doc;
        private XElement _container;
        private XElement _entitys=new XElement ("entitys");
        private XElement _repositorys=new XElement ("repositorys");
        private XElement _services=new XElement ("services");
        public EditIocConfigFile()
        {

        }

        public override string CodePrint()
        {
            return _entitys .ToString() + Environment.NewLine + _repositorys.ToString() + Environment.NewLine + _services.ToString();
        }
        public override void CodeFileBuild(string path)
        {
            _doc = XDocument.Load(path);
            _container = _doc.Descendants().Where(s => s.Name.LocalName == "container").First();
            _container.Add(_entitys.Elements());
            _container.Add(_repositorys.Elements());
            _container.Add(_services.Elements());
            _doc.Save(path);
        }

        public bool CodeBuild(ICollection<EntityInfo> entitys)
        {
            foreach (EntityInfo entity in entitys)
            {
                _entitys .Add (CreateEntityNode (entity ));
                _repositorys .Add (CreateRepositoryNode (entity ));
                _services .Add (CreateServiceNode(entity ) );
            }

            return true; 
        }
        private XElement CreateEntityNode(EntityInfo entity)
        {
            XElement entityNode = new XElement("register",
                new XAttribute("type", "I" + entity.Name),
                new XAttribute("mapTo", entity.Name),
                new XElement ("lifetime",
                    new XAttribute ("type","singleton")
                    )
                );
            return entityNode;
        }
        private XElement CreateRepositoryNode(EntityInfo entity)
        {
            XElement repositoryNode = new XElement("register", 
                new XAttribute("type", "I" + entity.Name + "Repository"),
                new XAttribute("mapTo", entity.Name + "Repository"),
                new XElement("lifetime",
                    new XAttribute("type", "PerWebRequest") ),
                    new XElement("constructor",                   
                        new XElement("param",
                       new XAttribute("name", "factory"),
                       new XAttribute("dependencyType", "IDatabaseFactory"))) );
            return repositoryNode;
        }
        private XElement CreateServiceNode(EntityInfo entity)
        {
            XElement serviceNode = new XElement("register",
                new XAttribute("type", "I" + entity.Name + "Service"),
                new XAttribute("mapTo", entity.Name + "Service"),
                new XElement("constructor",
                    new XElement("param",
                        new XAttribute("name", "bar"),
                        new XAttribute("dependencyType", "I" +entity .Name+ "Repository")),
                    new XElement("param",
                        new XAttribute("name", "factory"),
                        new XAttribute("dependencyType", "IDomainObjectFactory"))));
            return serviceNode;
        }
    }
}
