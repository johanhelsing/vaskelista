using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vaskelista.Models;

namespace Vaskelista.Services
{
    public class HouseholdService 
    {
        private VaskelistaContext db;
        
        public HouseholdService(VaskelistaContext db)
        {
            this.db = db;
        }

        public List<string> GetUniqueUrls(int count){
            var randomUrls = new List<string>();
            while(randomUrls.Count < count)
            {
                var url = RandomUrl.GetUrl();
                var household = db.Households.FirstOrDefault(s => s.Token.Equals(url));
                if (household == null) {
                    randomUrls.Add(url);
                }
            }
            return randomUrls;
        }
    }
}