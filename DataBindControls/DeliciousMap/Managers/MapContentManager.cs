using DeliciousMap.Helpers;
using DeliciousMap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeliciousMap.Managers
{
    public class MapContentManager
    {
        public List<MapContentModel> GetMapList()
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = 
                @"  SELECT *
                    FROM MapContents 
                    WHERE IsEnable = 'true'
                    ORDER BY CreateDate DESC ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<MapContentModel> retList = new List<MapContentModel>();    // 將資料庫內容轉為自定義型別清單
                        while (reader.Read())
                        {
                            MapContentModel info = this.BuildMapContentModel(reader);
                            retList.Add(info);
                        }

                        return retList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public List<MapContentModel> GetAdminMapList(string keyword)
        {
            string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(keyword))
                whereCondition = " WHERE Title LIKE '%'+@keyword+'%' ";

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@" SELECT *
                    FROM MapContents 
                    {whereCondition}
                    ORDER BY CreateDate DESC ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                        {
                            command.Parameters.AddWithValue("@keyword", keyword);
                        }

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<MapContentModel> retList = new List<MapContentModel>();    // 將資料庫內容轉為自定義型別清單
                        while (reader.Read())
                        {
                            MapContentModel info = this.BuildMapContentModel(reader);
                            retList.Add(info);
                        }

                        return retList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetAdminMapList", ex);
                throw;
            }
        }

        public List<MapContentModel> GetMapList(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0)
                return new List<MapContentModel>();

            List<string> idTextList = new List<string>();
            for (int i = 0; i < ids.Count; i++)
            {
                idTextList.Add("@id" + i);
            }
            string whereCondition = string.Join(", ", idTextList);


            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@" SELECT *
                    FROM MapContents 
                    WHERE ID IN ({whereCondition}) ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            command.Parameters.AddWithValue("@id" + i, ids[i]);
                        }


                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<MapContentModel> retList = new List<MapContentModel>();    // 將資料庫內容轉為自定義型別清單
                        while (reader.Read())
                        {
                            MapContentModel info = this.BuildMapContentModel(reader);
                            retList.Add(info);
                        }

                        return retList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }


        private MapContentModel BuildMapContentModel(SqlDataReader reader)
        {
            var model = new MapContentModel()
            {
                ID = (Guid)reader["ID"],
                Title = reader["Title"] as string,
                Body = reader["Body"] as string,
                CoverImage = reader["CoverImage"] as string,
                IsEnable = (bool)reader["IsEnable"],
                Longitude = (double)reader["Longitude"],
                Latitude = (double)reader["Latitude"],

                CreateDate = (DateTime)reader["CreateDate"],
                CreateUser = (Guid)reader["CreateUser"],
                UpdateDate = reader["UpdateDate"] as DateTime?,
                UpdateUser = reader["UpdateUser"] as Guid?,
                DeleteDate = reader["DeleteDate"] as DateTime?,
                DeleteUser = reader["DeleteUser"] as Guid?,
            };

            return model;
        }

        public MapContentModel GetMap(Guid id)
        {
            return null;
        }

        public void CreateMapContent(MapContentModel model, Guid cUserID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
               @"   INSERT INTO MapContents
                        (ID, Title, Body, Longitude, Latitude, CoverImage, IsEnable, CreateDate, CreateUser)
                    VALUES
                        (@ID, @Title, @Body, @Longitude, @Latitude, @CoverImage, @IsEnable, @CreateDate, @CreateUser) ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        model.ID = Guid.NewGuid();

                        command.Parameters.AddWithValue("@ID", model.ID);
                        command.Parameters.AddWithValue("@Title", model.Title);
                        command.Parameters.AddWithValue("@Body", model.Body);
                        command.Parameters.AddWithValue("@Longitude", model.Latitude);
                        command.Parameters.AddWithValue("@Latitude", model.Longitude);
                        command.Parameters.AddWithValue("@CoverImage", model.CoverImage);
                        command.Parameters.AddWithValue("@IsEnable", model.IsEnable);
                        command.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                        command.Parameters.AddWithValue("@CreateUser", cUserID);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.CreateMapContent", ex);
                throw;
            }
        }

        public void UpdateMapContent(MapContentModel model)
        { }

        public void DeleteMapContent(List<Guid> idList)
        {
            if (idList == null || idList.Count == 0)
                throw new Exception("id List is required.");

            List<string> idTextList = new List<string>();
            for (int i = 0; i < idList.Count; i++)
            {
                idTextList.Add("@id" + i);
            }
            string whereCondition = string.Join(", ", idTextList);

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
               $@"  DELETE MapContents
                    WHERE ID IN ({whereCondition}); ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        for (int i = 0; i < idList.Count; i++)
                        {
                            command.Parameters.AddWithValue("@id" + i, idList[i]);
                        }
         
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.DeleteMapContent", ex);
                throw;
            }
        }
    }
}