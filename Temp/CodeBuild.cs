using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .IO ;
using CodeProduce.BaseCode;

//-------------xxfss2----------------------------------------------------//
//-------------2011-3-17-----------------------------------------------//
//-------------http://www.cnblogs.com/xxfss2--------------------//
namespace CodeProduce.Temp
{
    /// <summary>
    /// 模板处理，代码生成
    /// </summary>
    public class CodeBuild
    {
        private static CodeBuild _instanceObject=null ;
        private CodeBuild()
        {

        }
        public static CodeBuild GetInstance()
        {
            if (_instanceObject == null)
                _instanceObject = new CodeBuild();
            return _instanceObject;
        }

        /// <summary>
        /// 传入实体和模板，生成代码
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool BaseBuild(TempInfo temp,EntityInfo entity)
        {
            StreamReader sr = new StreamReader(temp .FullName);
            string line = sr.ReadLine();
            if (Directory.Exists(temp.SavePath) == false)
            {
                Directory.CreateDirectory(temp.SavePath);
            }
            string newfile = temp .SavePath  +"\\"+ FileNameExchange (temp .BuildFilename ,entity .Name);
            StreamWriter sw = File.CreateText(newfile);
            while (line != null)
            {
                line = LineExchange(line, entity);
                sw.WriteLine(line);
                line = sr.ReadLine();
            }
            sw.Close();
            return true;
        }

        /// <summary>
        /// 代码生成入口函数，传入模板列表和实体列表
        /// </summary>
        /// <param name="temps"></param>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool BuildBaseCode(List <TempInfo > temps,List <EntityInfo > entitys)
        {
            if (entitys == null || temps == null)
            {
                throw new Exception("");
            }
            foreach (EntityInfo entity in entitys)
            {
                foreach (TempInfo temp in temps)
                {
                    this.BaseBuild(temp, entity);
                }
            }
            return true;
        }

        /// <summary>
        /// 单行文本替换
        /// </summary>
        /// <param name="oldLine"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string LineExchange(string oldLine,EntityInfo entity)
        {
            int markIndex = oldLine.IndexOf(TempType.MarkStart);
            if (markIndex > -1)
            {
                int endMarkIndex = oldLine.IndexOf(TempType.MarkEnd, markIndex);
                if (endMarkIndex > -1)
                {
                    string tempStr = oldLine.Substring(markIndex, endMarkIndex - markIndex + TempType.MarkEnd.Length);
                    oldLine = oldLine.Replace(tempStr, CodeExchange(tempStr, entity));
                    return LineExchange(oldLine, entity);
                }
                return oldLine;
            }
            else
            {
                return oldLine;
            }
        }
        /// <summary>
        /// 模板替换核心函数
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string CodeExchange(string temp, EntityInfo entity)
        {
            switch (temp)
            {
                case TempType.ENTITYNAME:
                    return entity.Name;
                case TempType .PRIMARYKEY :
                    return entity.Fields.Where(s => s.MainKey == true).FirstOrDefault().Name;
                case TempType.FIELDS:
                    StringBuilder sb = new StringBuilder();
                    foreach (FieldInfo field in entity.Fields)
                    {
                        if (field.FieldType == FieldType.SimpleField)
                        {
                            sb.AppendFormat(CodeHelp ._2codeIn  +"{0} {1} {{ get;set; }}{2}", field.Nullable == false ? field.DataType : field.DataType + "?", field.Name, Environment.NewLine);
                        }
                        else
                        {
                            ComplexFieldInfo cfield = (ComplexFieldInfo)field;
                            if (cfield.IsMulti == true)
                            {
                                sb.AppendFormat(CodeHelp._2codeIn + "ICollection<I{0}> {1} {{ get; }}{2}\t", cfield.DataType, cfield.Name.Substring(2) + "s", Environment.NewLine);
                            }
                            else
                            {
                                sb.AppendFormat(CodeHelp._2codeIn + "I{0} {1} {{ get;set; }}{2}\t", cfield.DataType, cfield.Name.Substring(2) + "s", Environment.NewLine);
                            }
                        }
                    }
                    return sb.ToString ();
                case TempType .RELATIONSHIP :
                    StringBuilder sb2 = new StringBuilder();
                    ICollection<FieldInfo> cFields = entity.Fields.Where(s => s.FieldType == FieldType.ComplexField).ToList();
                    foreach (ComplexFieldInfo cField in cFields)
                    {
                        if (cField.IsMulti == true)
                        {
                            sb2.AppendLine("\t[NonSerialized]");
                            sb2.AppendFormat("\t\tEntityReference<I{0},{0}> _{0}\r\n", cField.Name);
                            sb2.AppendFormat("\t\tinternal IEntityCollection<I{0}> {1}sInternal\r\n", cField.DataType, cField.Name);
                            sb2.AppendLine("\t\t{");
                            sb2.AppendLine("\t\t     get");
                            sb2.AppendLine("\t\t        {");
                            sb2.AppendLine("\t\t             if(_" + cField.Name + "==null)");
                            sb2.AppendLine("\t\t             {");
                            sb2.AppendLine("\t\t                 EntityHelper.EnsureEntityCollection(ref _" + cField.Name + ", " + cField.Name + " );");
                            sb2.AppendLine("\t\t                 EntityHelper.EnsureEntityCollectionLoaded(_" + cField.Name + ");");
                            sb2.AppendLine("\t\t             }");
                            sb2.AppendLine("\t\t                return _" + cField.Name + ";");
                            sb2.AppendLine("\t\t        }");
                            sb2.AppendLine("\t\t     set");
                            sb2.AppendLine("\t\t        {");
                            sb2.AppendLine("\t\t           var entitys=value as EntityCollection<I" + cField.DataType + "," + cField.DataType + ">;");
                            sb2.AppendLine("\t\t           if(entitys==null)");
                            sb2.AppendLine("\t\t           {");
                            sb2.AppendLine("\t\t               throw new Exception(\"\");");
                            sb2.AppendLine("\t\t            }");
                            sb2.AppendLine("\t\t           _" + cField.Name + "=entitys;");
                            sb2.AppendLine("\t\t        }");
                            sb2.AppendLine("\t\t}");
                            sb2.AppendLine("\t\tpublic ICollection<I"+cField .DataType +"> "+cField .Name+"s");
                            sb2.AppendLine("\t\t{");
                            sb2.AppendLine("\t\t     get");
                            sb2.AppendLine("\t\t        {");
                            sb2.AppendLine("                 return this."+cField .Name+"sInternal.AsEnumerable().Cast<I"+cField .DataType+">().ToList();");
                            sb2.AppendLine("\t\t        }");
                            sb2.AppendLine("\t\t}");
                        }
                        else
                        {
                            sb2.AppendLine("\t[NonSerialized]");
                            sb2.AppendFormat("\t\tEntityReference<I{0},{0}> _{0}\r\n", cField.Name);
                            sb2.AppendFormat("\t\tpublic I{0} {1}\r\n", cField.DataType,cField .Name);
                            sb2.AppendLine("\t\t{");
                            sb2.AppendLine("\t\t     get");
                            sb2.AppendLine("\t\t        {");
                            sb2.AppendLine("\t\t             if(" + cField.Name + "==null)");
                            sb2.AppendLine("\t\t             {");
                            sb2.AppendLine("\t\t                 EntityHelper.EnsureEntityReference(ref _" + cField.Name + ", " + cField.Name + "Reference );");
                            sb2.AppendLine("\t\t                 EntityHelper.EnsureEntityReferenceLoaded(_" + cField.Name + ");");
                            sb2.AppendLine("\t\t             }");
                            sb2.AppendLine("\t\t                return " + cField.Name + ";");
                            sb2.AppendLine("\t\t        }");
                            sb2.AppendLine("\t\t     set");
                            sb2.AppendLine("\t\t        {");
                            sb2.AppendLine("\t\t         " + cField.Name + "= (" + cField.DataType + ")value;");
                            sb2.AppendLine("\t\t        }");
                            sb2.AppendLine("\t\t}");
                        }
                    }
                    return sb2.ToString();
                default:
                    return temp;
            }
        }
        /// <summary>
        /// 文件名替换
        /// </summary>
        /// <param name="oldName"></param>
        /// <returns></returns>
        private string FileNameExchange(string oldName,string entityName)
        {
            string newName = oldName.Replace("*", entityName)+".cs";
            return newName;
        }
    }
}
