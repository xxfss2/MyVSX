using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CodeProduce .BaseCode ;

namespace CodeProduce.Temp
{
    public class EditEF4DatabaseFile:CodeBuildService 
    {
        private string _entityCode;
        private string _ientityCode;

        public EditEF4DatabaseFile()
            : base()
        {
        }

        public override void CodeBuild(ICollection<EntityInfo> entitys)
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
            _entityCode =sb.ToString ();
            _ientityCode =sb2 .ToString ();
        }
        public override string CodePrint()
        {
            return _entityCode +"\r\t"+_ientityCode ;
        }
        public override void CodeFileBuild(string path)
        {
            this.CodeFileReBuild(path, _entityCode);
            string ipath = path.Insert(path.LastIndexOf('\\') + 1, "I");
            this.CodeFileReBuild(ipath, _ientityCode);
        }

        private string EntityCode(EntityInfo entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   #region " + entity.Name);
            sb.AppendLine("   private IQueryable<" + entity.Name + "> _" + entity.Name + ";");
            sb.AppendLine("   internal ObjectQuery<" + entity.Name + "> " + entity.Name + "Set");
            sb.AppendLine("   {");
            sb.AppendLine("      get");
            sb.AppendLine("      {");
            sb.AppendLine("           return "+entity .Name+"DS as ObjectQuery<"+entity .Name+">;");
            sb.AppendLine("      }");
            sb.AppendLine("   }");
            sb.AppendLine("   public IQueryable<" + entity.Name + "> " + entity.Name + "DS");
            sb.AppendLine("   {");
            sb.AppendLine("      get");
            sb.AppendLine("      {");
            sb.AppendLine("           if (_"+entity .Name+" == null)");
            sb.AppendLine("          {");
            sb.AppendLine("               _" + entity.Name + " = CreateObjectSet<" + entity.Name + ">();");
            sb.AppendLine("          }");
            sb.AppendLine("          return _" + entity.Name + ";");
            sb.AppendLine("      }");
            sb.AppendLine("   }");
            sb.AppendLine("   #endregion");
            sb.AppendLine("");
            return sb.ToString();
        }

        private string IEntityCode(EntityInfo entity)
        {
            return string .Format ("IQueryable<{0}> {0}DS {{ get; }}{1}",entity .Name,Environment .NewLine );
        }
    }
}
