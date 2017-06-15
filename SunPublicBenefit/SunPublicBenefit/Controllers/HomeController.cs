using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunPublicBenefit.Models;
using System.IO;

namespace SunPublicBenefit.Controllers
{
    public class HomeController : ContextController
    {
        SunPublicBenefitDBContextOne db = new SunPublicBenefitDBContextOne();
        // GET: Home
        public ActionResult Index()
        {
            addRoles();
            return View(db.Roles.ToList());
        }
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public int Verify(Users user)
        {
            string userName = user.UserName;
            string passWord = user.PassWord;
            List<Users> userList = db.User.OrderBy(m => m.UserName).ToList();
            bool isname = false;            
            foreach (var item in userList)
            {
                if (item.UserName == userName && item.PassWord == passWord)
                {
                    isname = true;
                }
            }
            if(isname == false)
            {
                return 1;
            }
            else
            {
                return 0;
            }
           
        }

        public ActionResult Error()
        {
            return View();
        }
        //查询角色表中的数据，并且如果不存在的话，便是给创建出来这样的角色信息
        public void addRoles()
        {
            List<Roles> chk_role = db.Roles.OrderBy(m => m.RoleID).ToList();
            bool[] check = { false, false, false};
            foreach (var item in chk_role)
            {
                if (item.Name == "Super_Admin")
                {
                    check[0] = true;
                }
                if (item.Name == "Backstage_Admin")
                {
                    check[1] = true;
                }
                if (item.Name == "Money_Admin")
                {
                    check[2] = true;
                }
            }
            int i = 1;
            foreach (var item in check)
            {
                Roles role = new Roles();
                role.RoleID = Guid.NewGuid();
                Users user = new Users();
                user.UserID = Guid.NewGuid();
                if (item == false && i ==1)
                {
                    role.Name = "Super_Admin";
                    role.Description = "超级管理员";
                    user.UserName = "Super_Admin@163.com";
                    user.PassWord = "123456";
                    user.Role = role;
                    db.Roles.Add(role);
                    db.User.Add(user);
                    db.SaveChanges();
                }
                if (item == false && i== 2)
                {
                    role.Name = "Backstage_Admin";
                    role.Description = "后台管理员";
                    user.UserName = "Backstage_Admin@163.com";
                    user.PassWord = "123456";
                    user.Role = role;
                    db.Roles.Add(role);
                    db.User.Add(user);
                    db.SaveChanges();
                }
                if (item == false && i ==3)
                {
                    role.Name = "Money_Admin";
                    role.Description = "资金管理员";
                    user.UserName = "Money_Admin@163.com";
                    user.PassWord = "123456";
                    user.Role = role;
                    db.Roles.Add(role);
                    db.User.Add(user);
                    db.SaveChanges();
                }
                i++;
            }
           
        }

        [HttpPost]
        public ActionResult IsApprove()
        {
            string data = "";
            Session["ActiveUser"] = new Users { UserID = Guid.NewGuid(), UserName = "aa", IsStatus = 0 };
            if (Session["ActiveUser"] != null)
            {

                Users user = Session["ActiveUser"] as Users;                            
                if (user.IsStatus == 0)
                {
                    data = "0";
                }
                if (user.IsStatus == 1)
                {
                    data = "1";
                }
                if (user.IsStatus == 2)
                {
                    data = "2";
                }
                if (user.IsStatus == 3)
                {
                    data = "3";
                }
            }
            
            return Content(data);
        }
        public ActionResult ApproveWayChoose()
        {
            return View();
        }
    }
}