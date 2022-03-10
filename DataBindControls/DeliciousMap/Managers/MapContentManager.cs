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

                        conn.Open();

                        command.Parameters.AddWithValue("@ID", model.ID);
                        command.Parameters.AddWithValue("@Title", model.Title);
                        command.Parameters.AddWithValue("@Body", model.Body);
                        command.Parameters.AddWithValue("@Longitude", model.Latitude);
                        command.Parameters.AddWithValue("@Latitude", model.Longitude);
                        command.Parameters.AddWithValue("@CoverImage", model.CoverImage);
                        command.Parameters.AddWithValue("@IsEnable", model.IsEnable);
                        command.Parameters.AddWithValue("@CreateDate", model.CreateDate);
                        command.Parameters.AddWithValue("@CreateUser", model.CreateUser);
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

        public void DeleteMapContent(MapContentModel model)
        { }
    }
}