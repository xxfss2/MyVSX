using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeProduce.BaseCode
{
    /// <summary>
    /// 模板信息
    /// </summary>
    public class TempInfo
    {
        public TempInfo()
        {

        }
        public string FullName { get; set; }
        /// <summary>
        /// 生成的文件名称
        /// </summary>
        public string BuildFilename { get; set; }
        /// <summary>
        /// 生成的代码文件保存路径
        /// </summary>
        public string SavePath { get; set; }
        /// <summary>
        /// 复制到目标项目的路径
        /// </summary>
        public string ProjectPath { get; set; }
        public bool IsInterface { get; set; }
    }
}
