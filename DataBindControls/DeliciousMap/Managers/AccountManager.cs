﻿using DeliciousMap.Helpers;
using DeliciousMap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeliciousMap.Managers
{
    public class AccountManager
    {
        public bool TryLogin(string account, string password)
        {
            bool isAccountRight = false;
            bool isPasswordRight = false;

            AccountModel member = this.GetAccount(account);

            if (member == null) // 找不到就代表登入失敗
                return false;

            if (string.Compare(member.Account, account, true) == 0)
                isAccountRight = true;

            if (member.Password == password)
                isPasswordRight = true;

            // 檢查帳號密碼是否正確
            bool result = (isAccountRight && isPasswordRight);

            // 帳密正確：把值寫入 Session
            // 為避免任何漏洞導致 session 流出，先把密碼清除
            if (result)
            {
                member.Password = null;
                HttpContext.Current.Session["MemberAccount"] = member;
            }

            return result;
        }

        public bool IsLogined()
        {
            AccountModel account = GetCurrentUser();
            return (account != null);
        }

        public AccountModel GetCurrentUser()
        {
            AccountModel account = HttpContext.Current.Session["MemberAccount"] as AccountModel;
            return account;
        }

        public void Logout()
        {
            HttpContext.Current.Session.Remove("MemberAccount");
        }

        #region "增刪修查"
        public List<AccountModel> GetAccountList(string keyword)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Accounts ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                commandText += " WHERE Account LIKE '%'+@keyword+'%'";
            }

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
                        List<AccountModel> list = new List<AccountModel>();

                        while (reader.Read())
                        {
                            AccountModel member = new AccountModel()
                            {
                                ID = (Guid)reader["ID"],
                                Account = reader["Account"] as string
                            };

                            list.Add(member);
                        }

                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public AccountModel GetAccount(string account)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Accounts
                    WHERE Account = @account ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@account", account);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            AccountModel member = new AccountModel()
                            {
                                ID = (Guid)reader["ID"],
                                Account = reader["Account"] as string,
                                Password = reader["PWD"] as string
                            };

                            return member;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public AccountModel GetAccount(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Accounts
                    WHERE ID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            AccountModel member = new AccountModel()
                            {
                                ID = (Guid)reader["ID"],
                                Account = reader["Account"] as string,
                                Password = reader["PWD"] as string
                            };

                            return member;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public void CreateAccount(AccountModel member)
        {
            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(member.Account) != null)
                throw new Exception("已存在相同的帳號");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  INSERT INTO Accounts
                        (ID, Account, PWD)
                    VALUES
                        (@id, @account, @pwd)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        member.ID = Guid.NewGuid();

                        command.Parameters.AddWithValue("@id", member.ID);
                        command.Parameters.AddWithValue("@account", member.Account);
                        command.Parameters.AddWithValue("@pwd", member.Password);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public void UpdateAccount(AccountModel member)
        {
            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(member.Account) == null)
                throw new Exception("帳號不存在：" + member.Account);

            // 2. 編輯資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE Accounts
                    SET 
                        PWD = @pwd
                    WHERE
                        ID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", member.ID);
                        command.Parameters.AddWithValue("@pwd", member.Password);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public void DeleteAccounts(List<Guid> ids)
        {
            // 1. 判斷是否有傳入 id
            if (ids == null || ids.Count == 0)
                throw new Exception("需指定 id");

            List<string> param = new List<string>();
            for(var i = 0; i < ids.Count; i++)
            {
                param.Add("@id" + i);
            }
            string inSql = string.Join(", ", param);    // @id1, @id2, @id3, etc...

            // 2. 刪除資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@" DELETE Accounts
                    WHERE ID IN ({inSql}) ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        for(var i = 0; i < ids.Count; i++)
                        {
                            command.Parameters.AddWithValue("@id" + i, ids[i]);
                        }

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }
        #endregion
    }
}