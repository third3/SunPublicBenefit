using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SunPublicBenefit.VCode
{
    /// <summary>
    /// Code 的摘要说明
    /// </summary>
    public class Code : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ValidateCode validateCode = new ValidateCode();
            string strCode = validateCode.CreateValidateCode(4);
            context.Session["VCode"] = strCode;       
            validateCode.CreateValidateGraphic(strCode, context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}