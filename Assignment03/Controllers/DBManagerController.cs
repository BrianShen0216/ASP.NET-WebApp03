using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment03.Models;
using BLL;
using DAL;

namespace Assignment03.Controllers
{
    public class DBManagerController : Controller
    {
        protected List<User> users = new List<User>();

        // GET: DBManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateOriginalTable()
        {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        public ActionResult Display()
        {
            BLLClass bll = new BLLClass();
            DataSet ds = bll.GetUsers_BLL();

            DataTable dt = ds.Tables[0];

            var query = from item in dt.AsEnumerable()
                        select new
                        {
                            ID = item.Field<int>("ID"),
                            Name = item.Field<string>("Name"),
                            Email = item.Field<string>("Email"),
                            Password = item.Field<string>("Password")
                        };

            foreach (var item in query)
            {
                var u = new User
                {
                    Name = item.Name,
                    Email = item.Email,
                    Password = item.Password,
                    Password2 = item.Password
                };
                users.Add(u);
            }

            return View(users);
        }

    }
}