using FISCA;
using FISCA.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDMAutoManager
{
    public class Program
    {
        [FISCA.MainMethod(StartupPriority.LastAsynchronized)]
        public static void main()
        {
            //診斷模式不要執行 UDM 更新。
            if (!RTContext.IsDiagMode)
            {
                QueryHelper q = new QueryHelper();

                foreach(DataRow row in q.Select("select url from _udm").Rows)
                {
                    string url = row["url"] + "";

                    ServerModule.AutoManaged(url);
                }
            }
        }
    }
}
