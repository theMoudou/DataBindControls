using DeliciousMap.Helpers;
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

            MemberAccount member = this.GetAccount(account);

            if (string.Compare(member.Account, account, true) == 0)
                isAccountRight = true;

            if (member.Password == password)
                isPasswordRight = true;

            // 檢查帳號密碼是否正確
            bool result = (isAccountRight && isPasswordRight);

            // 帳密正確：把值寫入 Session
            if (result)
            {
                HttpContext.Current.Session["MemberAccount"] = new MemberAccount()
                {
                    Account = account,
                    Password = password
                };
            }

            return result;
        }

        public MemberAccount GetCurrentUser()
        {
            MemberAccount account = HttpContext.Current.Session["MemberAccount"] as MemberAccount;
            return account;
        }

        public void Logout()
        {
            HttpContext.Current.Session.Remove("MemberAccount");
        }

        private MemberAccount GetAccount(string account)
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
                            MemberAccount member = new MemberAccount()
                            {
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
    }
}