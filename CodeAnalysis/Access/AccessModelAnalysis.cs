using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CodeProduce.BaseCode;

namespace CodeProduce.CodeAnalysis
{
    public class AccessModelAnalysis:CodeAnysis
    {
        private OleDbConnection _con;
        public override bool Connetion(string fiilename)
        {
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fiilename;
             _con = new OleDbConnection(constr);

            return true;
        }

        public override IEnumerable<EntityInfo> GetEntitys()
        {
            if (_con == null)
            {
                throw new FieldAccessException();
            }
            _con.Open();
            DataTable dt = _con.GetSchema("Tables");
            DataTable mainKeys = _con.GetSchema("Indexes");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[2].ToString().Substring(0, 4) == "MSys")
                {
                    continue;
                }
                EntityInfo entity = new EntityInfo(dr[2].ToString());
                DataTable dt2 = _con.GetSchema("Columns", new string[] { null, null, dr[2].ToString() });
                List<FieldInfo> fields = new List<FieldInfo>();
                string mainkey=null;
                if (mainKeys.Select("INDEX_NAME='PrimaryKey' and TABLE_NAME='" + dr[2].ToString() + "'").Count() > 0)
                {
                    mainkey = mainKeys.Select("INDEX_NAME='PrimaryKey' and TABLE_NAME='" + dr[2].ToString() + "'")[0][17].ToString();
                }
               
                foreach (DataRow dr2 in dt2.Rows)
                {
                    FieldInfo field = new FieldInfo();
                    field.Name = dr2[3].ToString();
                    switch (dr2 ["DATA_TYPE"].ToString ())
                    {
                        case "3":
                            field.DataType = "int";
                            break ;
                        case "130":
                            field.DataType = "string";
                            break;
                        case "7":
                            field.DataType = "DateTime";
                            break;
                        case "11":
                            field.DataType = "bool";
                            break;
                        default :
                            break;
                    }
                    if (field.DataType == "DateTime")
                        field.Nullable = Convert.ToBoolean(dr2["IS_NULLABLE"]);
                    if (mainkey == field.Name)
                        field.MainKey = true;
                    fields.Add(field);
                }
                entity.Fields = fields;
                yield return entity;
            }
            yield break;
        }
    }
}
