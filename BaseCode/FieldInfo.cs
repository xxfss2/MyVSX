using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeProduce.BaseCode
{
    /// <summary>
    /// 字段信息类
    /// </summary>
    public class  FieldInfo
    {
        protected bool _nullable;
        protected bool _mainKey;
        private string _name;
        private string _pName;
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name 
        {
            get { return _name; }
            set { _name = value; _pName = value[0].ToString().ToLower() + value.Substring(1); }
        }
        /// <summary>
        /// 属性作为参数时的名称
        /// </summary>
        public string PName { get { return _pName; } }
        /// <summary>
        /// 属性数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 属性类型（简单、复杂）
        /// </summary>
        public virtual FieldType FieldType { get { return FieldType.SimpleField; } }
        /// <summary>
        /// 是否可空
        /// </summary>
        public bool Nullable
        {
            get
            {
                return _nullable;
            }
            set
            {
                if (MainKey == true && value == true)
                {
                    throw new Exception("主键不可空！");
                }
                _nullable = value;
            }
        }
        /// <summary>
        /// 是否主键
        /// </summary>
        public virtual bool MainKey
        {
            get
            {
                return _mainKey;
            }
            set
            {
                if (value == true)
                {
                    _nullable = false;
                    _mainKey = value;
                }
            }
        }
    }

    public class ComplexFieldInfo : FieldInfo
    {
        public override bool MainKey
        {
            get
            {
                return base.MainKey;
            }
            set
            {
                _mainKey = false;
            }
        }
        public override FieldType FieldType{get{return FieldType .ComplexField;}}

        /// <summary>
        /// 是否是个集合
        /// </summary>
        public bool IsMulti { get; set; }
    }
}
