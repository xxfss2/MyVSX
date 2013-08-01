using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeProduce.BaseCode
{
    /// <summary>
    /// 实体信息类
    /// </summary>
    public class EntityInfo
    {
        private string _name;
        private string _iname;
        private string _fname;
        public EntityInfo()
        {
            Fields = new List<FieldInfo>();
        }
        public EntityInfo(string name):this()
        {
            _name = name;
            _iname = string.Format("I{0}", name);
            _fname = name[0].ToString().ToLower() + name.Substring(1);
        }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; _iname = string.Format("I{0}", _name); } 
        }
        /// <summary>
        /// 实体接口名称
        /// </summary>
        public string IName
        {
            get{  return _iname;}
        }
        /// <summary>
        /// 实体作为局部变量的名称
        /// </summary>
        public string FName
        {
            get { return _fname; }
        }
        public List<FieldInfo> Fields { get; set; }
    }
}
