using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        /// <summary>
        /// Añade un punto de suministro
        /// </summary>
        /// <param name="usagePoint"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> AddUsagePointAsync(UsagePoint usagePoint)
        {
            string url = GetUrl("/usagepoints");

            return PostAsync(url, usagePoint);
        }
    }
}
