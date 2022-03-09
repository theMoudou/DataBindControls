using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TryWebAPI.Models;

namespace TryWebAPI.Managers
{
    public class StudentManager
    {
        private static List<StudentInfo> _list = new List<StudentInfo>()
        {
            new StudentInfo() { Name = "John", Age = 41 },
            new StudentInfo() { Name = "Moudou", Age = 21 },
        };


        public static StudentInfo GetStudent(string name)
        {
            foreach (StudentInfo item in StudentManager._list)
            {
                if (string.Compare(item.Name, name, true) == 0)
                    return item;
            }

            return null;
        }
    }
}