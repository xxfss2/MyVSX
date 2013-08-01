using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeProduce.Temp
{
    public static class CodeHelp
    {
        public static string _1codeIn = "    ";
        public static string _2codeIn = _1codeIn + _1codeIn;
        private const char BLANK = (char)32;
        /// <summary>
        /// 插入缩进代码
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="str"></param>
        public static void AppendInCode(this StringBuilder obj,int inx, string str,params object[] param)
        {
            string incode = new string(BLANK, inx * 4);
            obj.AppendFormat(incode+str+Environment .NewLine, param);
        }
    }
}
