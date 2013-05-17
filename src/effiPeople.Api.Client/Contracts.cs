using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        private const string _contractsCollectionResourceUrl = "/customers/{0}/contracts";

        private const string _contractsItemResourceUrl = "/customers/{0}/contracts/{1}";

        private const string _contractVersionsCollectionResourceUrl = "/customers/{0}/contracts/{1}/versions";

        private const string _contractVersionsItemResourceUrl = "/customers/{0}/contracts/{1}/versions/{2}";

        /// <summary>
        /// Añade un nuevo contrato a un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contract">Contrato</param>
        /// <returns></returns>
        public Task<Contract> AddCustomerContractAsync(string customerId, Contract contract)
        {
            string url = GetUrl(_contractsCollectionResourceUrl, customerId);

            return PostAsync<Contract, Contract>(url, contract);
        }

        /// <summary>
        /// Obtiene los contratos de un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <returns></returns>
        public Task<List<Contract>> GetCustomerContractsAsync(string customerId)
        {
            string url = GetUrl(_contractsCollectionResourceUrl, customerId);

            return GetAsync<List<Contract>>(url);
        }

        /// <summary>
        /// Obtiene el contrato de un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <returns></returns>
        public Task<Contract> GetCustomerContractAsync(string customerId, string contractId)
        {
            string url = GetUrl(_contractsItemResourceUrl, customerId, contractId);

            return GetAsync<Contract>(url);
        }


        /// <summary>
        /// Actualiza el contrato de un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <param name="contract"></param>
        /// <returns></returns>
        public Task<Contract> UpdateCustomerContractVersionAsync(string customerId, string contractId, string version, Contract contract)
        {
            string url = GetUrl(_contractVersionsItemResourceUrl, customerId, contractId, version);

            return PutAsync<Contract, Contract>(url, contract);
        }

        /// <summary>
        /// Elimina el contrato de un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteContractAsync(string customerId, string contractId)
        {
            string url = GetUrl(_contractsItemResourceUrl, customerId, contractId);

            return DeleteAsync(url);
        }
    }
}