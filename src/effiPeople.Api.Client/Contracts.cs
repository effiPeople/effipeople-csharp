using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        /// <summary>
        /// Añade un nuevo contrato a un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contract">Contrato</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> AddCustomerContractAsync(string customerId, Contract contract)
        {
            string url = GetUrl("/customers/{0}/contracts", customerId);

            return PostAsync(url, contract);
        }

        /// <summary>
        /// Obtiene los contratos de un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task<List<Contract>> GetCustomerContractsAsync(string customerId)
        {
            string url = GetUrl("/customers/{0}/contracts", customerId);

            return GetAsync<List<Contract>>(url);
        }

        /// <summary>
        /// Obtiene el contrato de un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public Task<Contract> GetCustomerContractAsync(string customerId, string contractId)
        {
            string url = GetUrl("/customers/{0}/contracts/{1}", customerId, contractId);

            return GetAsync<Contract>(url);
        }

        /// <summary>
        /// Añade o actualiza los contratos de un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="contracts"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> AddCustomerContractsAsync(string customerId, List<Contract> contracts)
        {
            string url = GetUrl("/customers/{0}/contracts", customerId);

            return PutAsync(url, contracts);
        }

        /// <summary>
        /// Actualiza el contrato de un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="contractId"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        public Task UpdateCustomerContractAsync(string customerId, string contractId, Contract contract)
        {
            string url = GetUrl("/customers/{0}/contracts/{1}", customerId, contractId);

            return PutAsync(url, contract);
        }
    }
}