using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using guestbook4.Models;
using MvcApplication1.Service;

namespace guestbook4.Controllers
{
    public class messageController : Controller
    {
        //實例化Service
        messageDBService data = new messageDBService();


        // GET: /message/
        public ActionResult Index()
        {
            //Article列表
            return View(data.GetData());
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete()
        {
            string id = Request.QueryString["id"];
            int x;
            if (!int.TryParse(id, out x))
            {
                //Response.Write("<script>alert('参数不完整');location.href='/'</script>");
                //return null;
            }
            data.db.Table.Remove(data.db.Table.SingleOrDefault(a => a.Id == x));
            data.db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(string strTitle, string strContent)
        {
            if(strTitle.Length==0||strContent.Length==0)
            {
                Response.Write("<script>alert('请将内容填写完整哟');</script>");
                return View();
            }
            
            data.DBCreate(strTitle, strContent);
            return RedirectToAction("Index");
        }
    }
}