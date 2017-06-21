using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunPublicBenefit.Models;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

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
                Session["Users"] = user;
                return 0;
            }
           
        }
        public static string GetMD5(string str)
        {
            //创建MD5对象;
            MD5 md5 = MD5.Create();
            //开始加密;
            //需要将字符串转换为字节数组,二进制的;
            byte[] buffer = Encoding.UTF8.GetBytes(str);

            byte[] MD5buffer = md5.ComputeHash(buffer);
            //将字节数组中每个元素按照编码格式解析成字符串;
            //string str2 = Encoding.UTF8.GetString(MD5buffer);
            //直接将数组ToString();
            //将字节数组中的每个元素ToString();  
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < MD5buffer.Length; i++)
            {
                result.Append(MD5buffer[i].ToString("x2"));
            }

            return result.ToString();

        }
        [HttpPost]
        public int addUser(Users user)
        {
            string username = user.UserName;
            string password = GetMD5(user.PassWord);
            List<Users> userList = db.User.OrderBy(m => m.UserName).ToList();
            bool bol = false;
            foreach (var item in userList)
            {
                if(item.UserName == username)
                {
                    bol = true;
                }
            }
            if(bol==false)
            {
                user.UserID = Guid.NewGuid();
                user.IsStatus = 0;
                db.User.Add(user);
                db.SaveChanges();
                return 0;
            }
            else
            {
                return 1;
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
            Session["Users"] = new Users { UserID = Guid.NewGuid(), UserName = "aa", IsStatus = 0 };
            if (Session["ActiveUser"] != null)
            {

                Users user = Session["Users"] as Users;                            
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
        public ActionResult PersonalCenter()
        {
            return View();
        }
    }
}