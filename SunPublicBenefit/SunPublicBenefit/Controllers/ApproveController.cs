using SunPublicBenefit.Models;
using SunPublicBenefit.VCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SunPublicBenefit.Controllers
{
    public class ApproveController : ContextController
    {

        // GET: Approve
        public ActionResult AutoUserApprove()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AutoUserApprove(string identityNumber, string realName, Users user)
        {
            Session["Users"] = new Users { UserID = Guid.NewGuid(), UserName = "aalkjkh", PassWord = "123", IsStatus = 0 };//测试用，使用时请注释
            string userValidateCode = Request["txtCode"];
            string seesionVCode = Session["VCode"] as string;
            Session["VCode"] = null;
            if (string.IsNullOrEmpty(seesionVCode) || userValidateCode != seesionVCode)
            {
                ViewBag.Message = "<script>alert('验证码错误！');</script>";
                return View();
            }
            if (IDVerify(identityNumber) && IsCN(realName))
            {
                user = Session["Users"] as Users;
                user.Identity = identityNumber;
                user.RealName = realName;
                sun.User.Add(user);
                sun.SaveChanges();
                return Content("OK");
            }
            return View();
        }
        private bool IDVerify(string identityNumber)
        {
            return Regex.IsMatch(identityNumber, @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase);

        }
        static bool IsCN(string realName)
        {
            Regex reg = new Regex("^[\u4e00-\u9fa5]{2,10}$");
            return reg.IsMatch(realName);
        }
        Users user;
        public ActionResult UnBeneficenceApprove()
        {
            user = Session["Users"] as Users;
            ViewBag.userName = user.UserName;
            return View();
        }
        [HttpPost]
        public ActionResult UnBeneficenceApprove(FormCollection fc, UnBeneficenceApprove unben)
        {
            unben.unBenID =Guid.NewGuid();
            //验证码是否正确
            string imgcode = Session["VCode"] as string;//图片中的验证
            Session["VCode"] = null;
            string u = fc["userName"];
            List<Users> users = sun.User.Where(m => m.UserName == u).ToList();
            //unben.userName = users;
            unben.FullName = fc["fullName"];//机构名称
            unben.telePhone = fc["telephone"] ;//电话
            unben.residentAddress = fc["provie"] + "省" + fc["city"]  + "市" + fc["residentAddress"]; //详细地址
            unben.nature =fc["nature"] ;//机构性质
            unben.scale =fc["fullTime"];//总人数
            unben.estaBlishDate =Convert.ToDateTime( fc["dateTime"]);//成立日期
            unben.website = fc["website"];//官方主页
            unben.demo = fc["explain"];//机构简介
            unben.code = fc["code"];//验证码
            if (string.IsNullOrEmpty(imgcode) || imgcode != unben.code)
            {
                return Content("false");
               
            }
            sun.UnBeneficenceApprove.Add(unben);
            sun.SaveChanges();
            return RedirectToAction("UnBeneficenceApprove","Project");
        }
        public ActionResult BeneficenceApprove()
        {
            return View();
        }
        public ActionResult MyDonationApprove()
        {
            return View();
        }
        public ActionResult PublicWelfareActivities()
        {
            return View();
        }
        public ActionResult InitiatesProjects()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InitiatesProjects(ProjectApplication application)
        {
            string fullDirMain;
            string fullDirIllustrating;
            HttpPostedFileBase file1 = Request.Files["imgMainPicture"];
            string fileName = Path.GetFileName(file1.FileName);
            string ext = Path.GetExtension(fileName);
            if (!(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".bmp"))
            {
                return Content("sun非法文件");
            }
            else
            {
                string dir = "/Upload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(dir)));//创建文件夹
                fullDirMain = dir + MD5.GetStreamMD5(file1.InputStream) + ext;
                file1.SaveAs(Request.MapPath(fullDirMain));
            }
            HttpPostedFileBase file2 = Request.Files["imgIllustratingPicture"];
            string fileName2 = Path.GetFileName(file2.FileName);
            string ext2 = Path.GetExtension(fileName2);
            if (!(ext2 == ".jpeg" || ext2 == ".jpg" || ext2 == ".png" || ext2 == ".gif" || ext2 == ".bmp"))
            {
                return Content("sun非法文件");
            }
            else
            {
                string dir = "/Upload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                fullDirIllustrating = dir + MD5.GetStreamMD5(file2.InputStream) + ext2;
                file2.SaveAs(Request.MapPath(fullDirIllustrating));
            }
            return RedirectToAction("PersonalCenter", "Home");
        }
        StringBuilder sb = new StringBuilder();
        public ActionResult LoadAllProvinceInfo()
        {

            List<Province> provinceInfo = sun.Province.OrderBy(s => s.ID).ToList();
            foreach (var province in provinceInfo)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", province.ID, province.ProvinceName);
            }
            return Content(sb.ToString());
        }
        public ActionResult GetAllCityByProvinceID()
        {
            int pID = int.Parse(Request["pId"] ?? "0");
            IQueryable<City> cityInfo = from s in sun.City where s.ProvinceID == pID select s;
            foreach (var city in cityInfo)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", city.ID, city.CityName);
            }
            return Content(sb.ToString());
        }
        [HttpPost]
        public ActionResult UploadingImage()
        {
            HttpPostedFileBase file = Request.Files["name"];
            string ext = Path.GetExtension(file.FileName);
            if (!(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".bmp"))
            {
                return Content("hl非法文件");
            }
            else
            {
                string path = "/Upload/" + Guid.NewGuid().ToString() + file.FileName;
                file.SaveAs(Request.MapPath(path));
                return Content("hl上传成功");
            }
        }
    }
}