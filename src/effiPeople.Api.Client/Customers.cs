using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        /// <summary>
        /// Obtiene un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task<Customer> GetCustomerAsync(string customerId)
        {
            string url = GetUrl("/customers/{0}", customerId);

            return GetAsync<Customer>(url);
        }

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Task<List<Customer>> GetCustomersAsync(int limit, int offset = 0)
        {
            var url = GetUrl("/customers?limit={0}&offset={1}", limit, offset);

            return GetAsync<List<Customer>>(url);
        }

        /// <summary>
        /// Añade un nuevo cliente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Task<Customer> AddCustomerAsync(Customer customer)
        {
            string url = GetUrl("/customers");

            return PostAsync<Customer, Customer>(url, customer);
        }

        /// <summary>
        /// Añade varios clientes
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> AddCustomersAsync(IEnumerable<Customer> customers)
        {
            string url = GetUrl("/customers");

            return PutAsync(url, customers);
        }

        /// <summary>
        /// Actualiza un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Task<Customer> UpdateCustomerAsync(string customerId, Customer customer)
        {
            string url = GetUrl("/customers/{0}", customerId);

            return PutAsync<Customer,Customer>(url, customer);
        }

        /// <summary>
        /// Elimina un cliente
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteCustomerAsync(string customerId)
        {
            string url = GetUrl("/customers/{0}", customerId);

            return DeleteAsync(url);
        }
    }
}