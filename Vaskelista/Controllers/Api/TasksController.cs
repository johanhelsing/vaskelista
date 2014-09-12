﻿using System;
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
        public class TasksApiViewModel {
            public Int32 activityId { get; set; }
            public string name { get; set; }
            public string day { get; set; }
            public DateTime start {get; set; }
            public string room { get; set; }
            public bool finished { get; set; }
        }

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
            return household.GetPlannedTasksForWeek(week).Select(t => new TasksApiViewModel {
                activityId = t.Activity.ActivityId,
                name = t.Activity.Name, 
                day = t.Start.DayOfWeek.ToString(),
                start = t.Start,
                room = t.Activity.Room.Name,
                finished = t.Finished
            });
        }

        public dynamic Post([FromBody] TasksApiViewModel vm)
        {
            if (vm.finished)
            {
                return "Add finished";
            }
            else
            {
                return "Remove finished";
            }
        }
    }
}
