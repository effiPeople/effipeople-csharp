using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        /// <summary>
        /// Añade un nuevo contador a un punto de suministro
        /// </summary>
        /// <param name="usagePointId">Identificador del punto de suministro</param>
        /// <param name="meter">Contrato</param>
        /// <returns></returns>
        public Task<Meter> AddMeterAsync(string usagePointId, Meter meter)
        {
            string url = GetUrl("/usagepoints/{0}/meters", usagePointId);

            return PostAsync<Meter, Meter>(url, meter);
        }

        /// <summary>
        /// Obtiene los contadores de un punto de suministro
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <returns></returns>
        public Task<List<Meter>> GetMetersAsync(string usagePointId)
        {
            string url = GetUrl("/usagepoints/{0}/meters", usagePointId);

            return GetAsync<List<Meter>>(url);
        }

        /// <summary>
        /// Obtiene el contador de un punto de suministro
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <param name="meterId"></param>
        /// <returns></returns>
        public Task<Meter> GetMeterAsync(string usagePointId, string meterId)
        {
            string url = GetUrl("/usagepoints/{0}/meters/{1}", usagePointId, meterId);

            return GetAsync<Meter>(url);
        }

        ///// <summary>
        ///// Añade o actualiza los contadores de un punto de suministro
        ///// </summary>
        ///// <param name="usagePointId"></param>
        ///// <param name="meters"></param>
        ///// <returns></returns>
        //public Task<HttpResponseMessage> AddMetersAsync(string usagePointId, List<Meter> meters)
        //{
        //    string url = GetUrl("/usagepoints/{0}/meters", usagePointId);

        //    return PutAsync(url, meters);
        //}

        /// <summary>
        /// Actualiza el contador de un punto de suministro
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <param name="meterId"></param>
        /// <param name="meter"></param>
        /// <returns></returns>
        public Task<Meter> UpdateMeterAsync(string usagePointId, string meterId, Meter meter)
        {
            string url = GetUrl("/usagepoints/{0}/meters/{1}", usagePointId, meterId);

            return PutAsync<Meter, Meter>(url, meter);
        }

        /// <summary>
        /// Elimina el contador de un punto de suministro
        /// </summary>
        /// <param name="usagePointId">Identificador del punto de suministro</param>
        /// <param name="meterId">Identificador del contador</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteMeterAsync(string usagePointId, string meterId)
        {
            string url = GetUrl("/usagepoints/{0}/meters/{1}", usagePointId, meterId);

            return DeleteAsync(url);
        }
    }
}