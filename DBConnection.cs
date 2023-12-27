using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databaseproject
{
    internal class DBConnection
    {
        SqlConnection Cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string Con;

        public string connection()
        {
            Con = "Data Source=LAPTOP-0LKEO4VQ;Initial Catalog=Paf-iast(DBMS_Project);Persist Security Info=True;User ID=sa;Password=12345";
            return Con;
        }
    }
}
