using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vaskelista.Controllers
{
    public class BaseController : Controller
    {
        public String HouseholdToken
        {
            get {
                object token;
                if (RouteData.Values.TryGetValue("householdToken", out token))
                {
                    return token as string;
                }
                return null;
            }
        }
	}
}