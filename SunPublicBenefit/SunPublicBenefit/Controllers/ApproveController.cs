﻿using SunPublicBenefit.Models;
using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text.RegularExpressions;
using System.Web.Mvc;
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
            Session["Users"] = new Users { UserID = Guid.NewGuid(), UserName = "aalkjkh",PassWord="123",IsStatus=0};//测试用，使用时请注释
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
                return RedirectToAction("验证成功页面");
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
        public ActionResult BeneficenceApprove()
        {
            return View();
        }

    }
}