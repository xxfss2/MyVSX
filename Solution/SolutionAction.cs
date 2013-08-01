using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace CodeProduce.Solution
{
    public class SolutionAction
    {
       // private readonly string DIRECTORY = AppDomain .CurrentDomain .BaseDirectory ;
        public static  readonly string DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\CodeProduce\\";
        /// <summary>
        /// 当前解决方案，可能是新创建的，也可能是加载的
        /// </summary>
        public static SolutionEntity CurrSolution = new SolutionEntity();

        //public IEnumerable<SolutionEntity> GetHistory()
        //{
        //    if (Directory.Exists(DIRECTORY) == false)
        //    {
        //        Directory.CreateDirectory(DIRECTORY);
        //    }
        //    string[] files=Directory.GetFiles(DIRECTORY, "*.xml");
        //    foreach (string file in files )
        //    {
        //        using (FileStream fs = new FileStream( file, FileMode.Open))
        //        {
        //            XmlSerializer format = new XmlSerializer(typeof(SolutionEntity));
        //            yield return (SolutionEntity)format.Deserialize(fs);
        //        }
        //    }
        //}

        public static bool Open(string solutionName)
        {
            string fullname = GetXMLFullName(solutionName);
            if (File.Exists(fullname))
            {
                using (FileStream fs = new FileStream(fullname, FileMode.Open))
                {
                    XmlSerializer format = new XmlSerializer(typeof(SolutionEntity));
                    CurrSolution = (SolutionEntity)format.Deserialize(fs);
                    return true;
                }
            }
            return false;
        }

        public static string GetXMLFullName(string solutionName)
        {
            return string .Format ("{0}\\{1}\\{1}.xml",DIRECTORY ,solutionName );
        }

        public bool Save(SolutionEntity entity)
        {
            if (Directory.Exists(DIRECTORY)==false )
            {
                Directory.CreateDirectory(DIRECTORY);
            }
            using (FileStream fs = new FileStream(GetXMLFullName(entity .Name ), FileMode.Create))
            {
                XmlSerializer format = new XmlSerializer(typeof(SolutionEntity));
                format.Serialize(fs, entity);
                return false;
            }
        }
        public bool Delete(SolutionEntity entity)
        {
            FileInfo fileinfo = new FileInfo(DIRECTORY + entity.FileName);
            fileinfo.Delete();
            return true;
        }
        

        public SolutionEntity GetByName(string id)
        {
            //XDocument doc = XDocument.Load(FILENAME);
            //foreach (XElement ele in doc.Root.Elements())
            //{
            //    SolutionEntity entity = CreateNodeEntity(ele);
                
            //    if (entity.Id == id)
            //        return entity;
            //}
            return null;
        }

    }
}
