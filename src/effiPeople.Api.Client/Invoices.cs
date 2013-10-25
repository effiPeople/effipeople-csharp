using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        private const string _invoiceCollectionResourceUrl = "/customers/{0}/contracts/{1}/invoices";

        private const string _invoiceItemResourceUrl = "/customers/{0}/contracts/{1}/invoices/{2}";

        /// <summary>
        /// Añade un nuevo contrato a un cliente
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <param name="invoice">Factura</param>
        /// <returns></returns>
        public Task<Invoice> AddInvoiceAsync(string customerId, string contractId, Invoice invoice)
        {
            string url = GetUrl(_invoiceCollectionResourceUrl, customerId, contractId);

            return PostAsync<Invoice, Invoice>(url, invoice);
        }

        /// <summary>
        /// Actualiza una factura
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <param name="invoiceNumber">Número de factura</param>
        /// <param name="invoice">Factura</param>
        /// <returns></returns>
        public Task<Invoice> UpdateInvoiceAsync(string customerId, string contractId, string invoiceNumber, Invoice invoice)
        {
            string url = GetUrl(_invoiceItemResourceUrl, customerId, contractId, invoiceNumber);

            return PutAsync<Invoice, Invoice>(url, invoice);
        }

        /// <summary>
        /// Elimina una factura
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <param name="invoiceNumber">Número de factura</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteInvoiceAsync(string customerId, string contractId, string invoiceNumber)
        {
            string url = GetUrl(_invoiceItemResourceUrl, customerId, contractId, invoiceNumber);

            return DeleteAsync(url);
        }


        /// <summary>
        /// Obtiene una factura
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <param name="invoiceNumber">Número de factura</param>
        /// <returns></returns>
        public Task<Invoice> GetInvoiceAsync(string customerId, string contractId, string invoiceNumber)
        {
            string url = GetUrl(_invoiceItemResourceUrl, customerId, contractId, invoiceNumber);

            return GetAsync<Invoice>(url);
        }

        /// <summary>
        /// Obtiene las facturas asociadas a un contrato
        /// </summary>
        /// <param name="customerId">Identificador del cliente</param>
        /// <param name="contractId">Identificador del contrato</param>
        /// <returns></returns>
        public Task<List<Invoice>> GetContractInvoicesAsync(string customerId, string contractId)
        {
            string url = GetUrl(_invoiceCollectionResourceUrl, customerId, contractId);

            return GetAsync<List<Invoice>>(url);
        }
    }
}
