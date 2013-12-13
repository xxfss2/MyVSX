using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeProduce.BaseCode
{
    public static class TempType
    {
        public const string MarkStart = "<~";
        public const string MarkEnd = "~>";
        /// <summary>
        /// 实体名称
        /// </summary>
        public const string ENTITYNAME = "<~ENTITYNAME~>";
        /// <summary>
        /// 主键
        /// </summary>
        public const string PRIMARYKEY = "<~PRIMARYKEY~>";
        /// <summary>
        /// 字段生成区域
        /// </summary>
        public const string FIELDS = "<~FIELDS~>";
        /// <summary>
        /// 导航属性区域
        /// </summary>
        public const string RELATIONSHIP = "<~RELATIONSHIP~>";
    }
}
