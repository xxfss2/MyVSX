using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeProduce .BaseCode  ;

namespace CodeProduce.Solution
{
    public enum SolutionType
    {
        Access=1,
        EntityFramework1=2,
        EntityFramework4=3
    }
    [Serializable ]
    public class SolutionEntity
    { 
        private List<TempInfo> _temps;
        public SolutionEntity()
        {
            _temps = new List<TempInfo>();
        }
        public string Name { get; set; }
        public string FileName 
        {
            get
            {
                return Name + ".xml";
            }
        }

        public DateTime CreatedAt { get; set; }
        public SolutionType Type { get; set; }
        public List<TempInfo> Temps{get{ return _temps;}}

        private int OldHashCode;
        /// <summary>
        /// 保存HASHCODE，用以比较退出时是否有修改
        /// </summary>
        public void SaveHashCode()
        {
            OldHashCode = this.GetHashCode();
        }
        public int GetOldHashCode()
        {
            return OldHashCode;
        }
    }
}
