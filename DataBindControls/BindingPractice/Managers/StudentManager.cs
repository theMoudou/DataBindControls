using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace BindingPractice.Managers
{
    public class StudentManager
    {
        /// <summary> 讀取資料庫並放到 DataTable 中 </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            string connStr = "Server=localhost;Database=CSharpLesson;Integrated Security=True;";
            string commandText = @"
                SELECT [ID], [Name], Birthday, IsMale, [Mobile], [ImagePath]
                FROM [StudentInfos] ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        return dt;
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}