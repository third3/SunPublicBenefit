using SunPublicBenefit.Models;
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

        [HttpPost]
        public ActionResult AutoUserApprove(string identityNumber, string realName, UserApprove approve,User1 user)
        {
            if (IDVerify(identityNumber) && IsCN(realName))
            {
                user = Session["userInfo"] as User1;
                try
                {
                    foreach (Role item in user.Role)
                    {
                        item.RoleName = "Individual_User";
                    }
                    approve.ID = Guid.NewGuid().ToString();
                    approve.RealName = realName;
                    approve.IdentityNumber = identityNumber;
                    foreach (User1 item in approve.User1)
                    {
                        item.ID = user.ID;
                        item.UserName = user.UserName;
                        item.UserPassword = user.UserPassword;
                        item.Role = user.Role;
                    }
                    sun.UserApproveSet.Add(approve);               
                    sun.Entry(user).State = EntityState.Modified;
                    sun.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {

                    throw dbEx;
                }

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
    }
}