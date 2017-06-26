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
                ViewBag.Message = "<script>alert('验证码错误！')</script>";
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

        public ActionResult UnBeneficenceApprove()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnBeneficenceApprove(string userName, string FullName, string telephone, string residentAddress, string provie, string city, string fullTime, string nature, string annual, DateTime dateTime, string website, string explain, string code, UnBeneficenceApprove unben)
        {
            unben.FullName = FullName;//机构名称
            unben.telePhone = telephone;//电话
            unben.residentAddress = provie + "省" + city + "市" + residentAddress; //详细地址
            unben.nature = nature;//机构性质
            unben.scale = Convert.ToInt32(fullTime);//总人数
            unben.estaBlishDate = dateTime;//成立日期
            unben.website = website;//官方主页
            unben.demo = explain;//机构简介
            unben.code = code;//验证码
            sun.UnBeneficenceApprove.Add(unben);
            sun.SaveChanges();
            return View();
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
                string fullDir = dir + MD5.GetStreamMD5(file1.InputStream) + ext;
                file1.SaveAs(Request.MapPath(fullDir));
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
                string fullDir = dir + MD5.GetStreamMD5(file2.InputStream) + ext2;
                file2.SaveAs(Request.MapPath(fullDir));

            }
            return Content("");
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