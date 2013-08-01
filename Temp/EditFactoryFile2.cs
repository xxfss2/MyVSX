using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeProduce.BaseCode;
using System.IO;

namespace CodeProduce.Temp
{
    public class EditFactoryFile2:CodeBuildService 
    {
        private string _entityCode;
        private string _ientityCode;
        public override  void CodeBuild(ICollection<EntityInfo> entitys)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            sb2.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            foreach (EntityInfo entity in entitys)
            {
                sb.Append(this.EntityCode(entity));
                sb2.Append(this.IEntityCode(entity));
            }
            _entityCode = sb.ToString();
            _ientityCode = sb2.ToString();
         //   CodeFileReBuild(Path, sb.ToString());
      //      CodeFileReBuild(_iPath, sb2.ToString());
        }

        public override void CodeFileBuild(string path)
        {
            base.CodeFileBuild(path);
        }
        public override string CodePrint()
        {
            return _entityCode + Environment.NewLine + _ientityCode;
        }


        private string EntityCode(EntityInfo entity)
        {
            StringBuilder sb = new StringBuilder();
            List<string> paramList = new List<string>();
         
            //foreach (FieldInfo field in entity .Fields )
            //{
            //    if (field.FieldType == FieldType.ComplexField)
            //    {
            //        ComplexFieldInfo cfield=(ComplexFieldInfo)field;
            //        if (cfield.IsMulti)
            //            continue;
            //        paramList.Add(string.Format("I{0} {1}", field.DataType, field.Name.ToLower()));
            //    }
            //    else if (!field.MainKey )
            //    {
            //        paramList.Add(string.Format("{0} {1}", field.DataType, field.Name.ToLower()));
                    
            //    }
            //}
            sb.AppendLine();
            sb.AppendInCode(2, "public {0} Create{1}()", entity.IName, entity.Name);
            sb.AppendInCode(2, "{{");
            sb.AppendInCode(3, "return new {0}", entity.Name);
            sb.AppendInCode(3, "{{");

            sb.AppendInCode(3, "}};");
            sb.AppendInCode(2, "}}");


            return sb.ToString();
        }


        private string IEntityCode(EntityInfo entity)
        {
            List<string> paramList = new List<string>();
            foreach (FieldInfo field in entity.Fields)
            {
                if (field.FieldType == FieldType.ComplexField)
                {
                    ComplexFieldInfo cfield = (ComplexFieldInfo)field;
                    if (cfield.IsMulti)
                        continue;
                    paramList.Add(string.Format("I{0} {1}", field.DataType, field.Name.ToLower()));
                }
                else if (!field.MainKey)
                {
                    paramList.Add(string.Format("{0} {1}", field.DataType, field.Name.ToLower()));
                }
            }
            return string.Format("        I{0} Create{0}();{1}", entity.Name,Environment .NewLine );
        }
    }
}
