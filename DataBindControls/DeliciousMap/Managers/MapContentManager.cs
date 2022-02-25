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

        public List<MapContent> GetMapList()
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = 
                @"  SELECT *
                    FROM MapContents 
                    ORDER BY CreateDate DESC ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<MapContent> retList = new List<MapContent>();    // 將資料庫內容轉為自定義型別清單
                        while (reader.Read())
                        {
                            MapContent info = new MapContent()
                            {
                                ID = (Guid)reader["ID"],
                                Title = reader["Title"] as string,
                                Body = reader["Body"] as string,
                                CreateDate = (DateTime)reader["CreateDate"],
                                Longitude = reader["Longitude"] as float?,
                                Latitude = reader["Latitude"] as float?,
                            };
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

        public MapContent GetMap(Guid id)
        {
            return null;
        }

        public void CreateMapContent(MapContent model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
               @"   INSERT INTO MapContents
                        (Title, Body, Longitude, Latitude)
                    VALUES
                        (@Title, @Body, @Longitude, @Latitude) ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();

                        command.Parameters.AddWithValue("@Title", model.Title);
                        command.Parameters.AddWithValue("@Body", model.Body);
                        command.Parameters.AddWithValue("@Longitude", model.Latitude);
                        command.Parameters.AddWithValue("@Latitude", model.Longitude);
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

        public void UpdateMapContent(MapContent model)
        { }

        public void DeleteMapContent(MapContent model)
        { }
    }
}