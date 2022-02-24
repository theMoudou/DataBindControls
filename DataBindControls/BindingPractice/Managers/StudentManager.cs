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

        /// <summary> 使用學號刪除學生資料 </summary>
        /// <param name="id"></param>
        public void DeleteStudent(string id)
        {
            string connStr = "Server=localhost;Database=CSharpLesson;Integrated Security=True;";
            string commandText = @"
                DELETE FROM [StudentInfos] 
                WHERE ID = @ID ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();

                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary> 更新學生資料 </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="imagePath"></param>
        /// <param name="birthday"></param>
        public void UpdateStudent(string id, string name, string mobile, string imagePath, DateTime? birthday)
        {
            string connStr = "Server=localhost;Database=CSharpLesson;Integrated Security=True;";
            string commandText = @"
                UPDATE [StudentInfos] 
                SET
                    Name = @Name,
                    Mobile = @Mobile,
                    ImagePath = @ImagePath,
                    Birthday = @birthday
                WHERE ID = @ID ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();

                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Mobile", mobile);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@birthday", birthday);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}