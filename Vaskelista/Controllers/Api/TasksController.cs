using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Vaskelista.Models;

namespace Vaskelista.Controllers.Api
{
    [RoutePrefix("api/{householdToken}/Tasks")]
    public class TasksController : ApiController
    {
        private VaskelistaContext db = new VaskelistaContext();

        public string HouseholdToken
        {
            get
            {
                object token;
                
                if (Request.GetRouteData().Values.TryGetValue("householdToken", out token))
                {
                    return token as string;
                }
                return null;
            }
        }

        public dynamic Get([FromUri] DateTime week)
        {
            var household = db.Households.Where(h => h.Token == HouseholdToken).FirstOrDefault();
            return household.GetPlannedTasksForWeek(week).Select(t => new { 
                name = t.Activity.Name, 
                day = t.Start.DayOfWeek.ToString(), 
                room = t.Activity.Room.Name,
            });
        }
    }
}
