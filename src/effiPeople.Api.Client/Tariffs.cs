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
        private const string _tariffsCollectionResourceUrl = "/tariffs";

        private const string _tariffsItemResourceUrl = "/tariffs/{0}";

        private const string _tariffVersionsCollectionResourceUrl = "/tariffs/{0}/versions";

        private const string _tariffVersionsItemResourceUrl = "/tariffs/{0}/versions/{1}";

        /// <summary>
        /// Añade un nueva tarifa
        /// </summary>
        /// <param name="tariff">Tarifa</param>
        /// <returns></returns>
        public Task<Tariff> AddTariffAsync(Tariff tariff)
        {
            string url = GetUrl(_tariffsCollectionResourceUrl);

            return PostAsync<Tariff, Tariff>(url, tariff);
        }

        /// <summary>
        /// Obtiene las tarifas
        /// </summary>
        /// <returns></returns>
        public Task<List<Tariff>> GetTariffsAsync()
        {
            string url = GetUrl(_tariffsCollectionResourceUrl);

            return GetAsync<List<Tariff>>(url);
        }

        /// <summary>
        /// Obtiene la tarifa
        /// </summary>
        /// <param name="tariffId">Identificador de la tarifa</param>
        /// <returns></returns>
        public Task<Tariff> GetTariffAsync(string tariffId)
        {
            string url = GetUrl(_tariffsItemResourceUrl, tariffId);

            return GetAsync<Tariff>(url);
        }


        /// <summary>
        /// Actualiza la versión de la tarifa
        /// </summary>
        /// <param name="tariffId">Identificador dla tarifa</param>
        /// <param name="version">Versión de la tarifa</param>
        /// <param name="tariff"></param>
        /// <returns></returns>
        public Task<Tariff> UpdateTariffVersionAsync(string tariffId, string version, Tariff tariff)
        {
            string url = GetUrl(_tariffVersionsItemResourceUrl, tariffId, version);

            return PutAsync<Tariff, Tariff>(url, tariff);
        }

        /// <summary>
        /// Elimina la tarifa
        /// </summary>
        /// <param name="tariffId">Identificador de la tarifa</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteTariffAsync(string tariffId)
        {
            string url = GetUrl(_tariffsItemResourceUrl, tariffId);

            return DeleteAsync(url);
        }

        /// <summary>
        /// Elimina una versión de la tarifa
        /// </summary>
        /// <param name="tariffId">Identificador de la tarifa</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteTariffVersionAsync(string tariffId, string version)
        {
            string url = GetUrl(_tariffVersionsItemResourceUrl, tariffId, version);

            return DeleteAsync(url);
        }
    }
}
