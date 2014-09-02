using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vaskelista.Models;

namespace Vaskelista.Services
{
    public class ScheduleService 
    {
        private VaskelistaContext db;
        
        public ScheduleService(VaskelistaContext db)
        {
            this.db = db;
        }

        public List<string> GetUniqueUrls(int count){
            var randomUrls = new List<string>();
            while(randomUrls.Count < count)
            {
                var url = RandomUrl.GetUrl();
                var schedule = db.Schedules.FirstOrDefault(s => s.Name.Equals(url));
                if (schedule == null) {
                    randomUrls.Add(url);
                }
            }
            return randomUrls;
        }
    }
}