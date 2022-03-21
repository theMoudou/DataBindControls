using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.Managers
{
    public class FakeDataManager
    {
        private static List<FakeDataModel> _list = new List<FakeDataModel>()
        {
            new FakeDataModel() { ID = "ID1", Name = "Name1", Content = "Content1" },
            new FakeDataModel() { ID = "ID2", Name = "Name2", Content = "Content2" },
            new FakeDataModel() { ID = "ID3", Name = "Name3", Content = "Content3" },
            new FakeDataModel() { ID = "ID4", Name = "Name4", Content = "Content4" },
            new FakeDataModel() { ID = "ID5", Name = "Name5", Content = "Content5" },
        };

        public List<FakeDataModel> GetList()
        {
            return FakeDataManager._list;
        }

        public FakeDataModel Get(string id)
        {
            FakeDataModel dbEntity = FakeDataManager._list.Where(obj => obj.ID == id).FirstOrDefault();
            return dbEntity;
        }

        public void UpdateFakeData(FakeDataModel model)
        {
            FakeDataModel dbEntity = FakeDataManager._list.Where(obj => obj.ID == model.ID).FirstOrDefault();

            if (dbEntity != null)
            {
                dbEntity.Name = model.Name;
                dbEntity.Content = model.Content;
            }
        }

        public void DeleteFakeData(string id)
        {
            FakeDataModel dbEntity = FakeDataManager._list.Where(obj => obj.ID == id).FirstOrDefault();

            if (dbEntity != null)
            {
                FakeDataManager._list.Remove(dbEntity);
            }
        }
    }


    public class FakeDataModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}