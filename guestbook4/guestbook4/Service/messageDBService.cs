using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using guestbook4.Models;  //引用Model命名空間

namespace MvcApplication1.Service
{
    public class messageDBService
    {
        //實例化實體數據
        public GuestBookEntities db = new GuestBookEntities();
        public List<Table> GetData()
        {
            return (db.Table.OrderByDescending(a =>a.Id).ToList());
        }
        //把從User接受的數據寫入messageEnitity
        public void DBCreate(string strTitle, string strContent)
        {
            //實例化Artile對象
            Table newData = new Table();

            //給Artile對象的屬性賦值
            newData.Title = strTitle;
            newData.Content = strContent;
            newData.Time = DateTime.Now;

            //實體添加到Entity中
            db.Table.Add(newData);
            //保存到數據庫
            db.SaveChanges();

        }
    }
}