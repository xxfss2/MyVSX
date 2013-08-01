using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeProduce.BaseCode;

namespace CodeProduce.CodeAnalysis
{
    /// <summary>
    /// 代码分析类抽象类
    /// </summary>
    public abstract class CodeAnysis
    {
        public abstract bool Connetion(string con);
        public abstract IEnumerable<EntityInfo> GetEntitys();
    }
}
