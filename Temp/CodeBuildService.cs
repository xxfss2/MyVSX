using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CodeProduce.BaseCode;

namespace CodeProduce.Temp
{
    public class CodeBuildService
    {

        public CodeBuildService()
        {
        }
        /// <summary>
        /// 将生成的代码添加到指定的文件中
        /// </summary>
        /// <param name="path">代码文件路径</param>
        /// <param name="code">生成的代码</param>
        protected void CodeFileReBuild(string path,string code)
        {
            string startStr = @"//codebuild";
            StreamReader sr = new StreamReader(path);
            string file = sr.ReadToEnd();
            sr.Close();
            int startindex = file.LastIndexOf(startStr);
            file = file.Insert(startindex + startStr.Length, code);
            StreamWriter sw = new StreamWriter(path, false);
            sw.WriteLine(file);
            sw.Close();
        }

        public virtual void CodeBuild(ICollection<EntityInfo> entitys)
        {
            throw new Exception("wrong");
        }
        public virtual string CodePrint()
        {
            throw new Exception("wrong..");
        }
        public virtual void CodeFileBuild(string path)
        {
            throw new Exception("wrong..");
        }
    }
}
