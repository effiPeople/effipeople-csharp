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
        /// Obtiene los datos de un punto de suministro
        /// </summary>
        /// <param name="usagePointId">Identificador del punto de suministro</param>
        /// <returns></returns>
        public Task<UsagePoint> GetUsagePointAsync(string usagePointId)
        {
            string url = GetUrl("/usagepoints/{0}", usagePointId);

            return GetAsync<UsagePoint>(url);
        }

        /// <summary>
        /// Obtiene los puntos de suministro
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Task<List<UsagePoint>> GetUsagePointsAsync(int limit, int offset = 0)
        {
            var url = GetUrl("/usagepoints?limit={0}&offset={1}", limit, offset);

            return GetAsync<List<UsagePoint>>(url);
        }

        /// <summary>
        /// Añade un punto de suministro
        /// </summary>
        /// <param name="usagePoint">Punto de suministro</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> AddUsagePointAsync(UsagePoint usagePoint)
        {
            string url = GetUrl("/usagepoints");

            return PostAsync(url, usagePoint);
        }

        /// <summary>
        /// Añade un punto de suministro
        /// </summary>
        /// <param name="usagePointId">Identificador del punto de suministro</param>
        /// <param name="usagePoint">Punto de suministro</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> UpdateUsagePointAsync(string usagePointId, UsagePoint usagePoint)
        {
            string url = GetUrl("/usagepoints/{0}", usagePointId);

            return PutAsync(url, usagePoint);
        }

        /// <summary>
        /// Elimina los datos de un punto de suministro
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteUsagePointAsync(string usagePointId)
        {
            string url = GetUrl("/usagepoints/{0}", usagePointId);

            return DeleteAsync(url);
        }

        /// <summary>
        /// Añade o actualiza varios puntos de suministro
        /// </summary>
        /// <param name="usagePoints"></param>
        /// <returns></returns>
        public Task AddUsagePointsAsync(List<UsagePoint> usagePoints)
        {
            string url = GetUrl("/usagepoints");

            return PutAsync(url, usagePoints);
        }
    }
}
