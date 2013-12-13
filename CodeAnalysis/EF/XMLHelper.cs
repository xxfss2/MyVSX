using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CodeProduce.CodeAnalysis
{
    public class XMLHelper
    {
        /// <summary>
        /// 获取节点,遍历所有子节点，直到找出符合条件的对象
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public XElement GetChild(XElement parentNode, XName name)
        {
            XElement element = parentNode.Element(name);
            if (element == null)
            {
                foreach (XElement e in parentNode.Elements())
                {
                    return GetChild(e, name);
                }
                return null;
            }
            else
            {
                return element;
            }
        }
    }
}
