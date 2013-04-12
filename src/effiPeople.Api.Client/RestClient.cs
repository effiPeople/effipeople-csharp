using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using effiPeople.Api.Client.Model.Exceptions;

namespace EffiPeople.Api.Client
{
    /// <summary>
    /// Base REST API wrapper
    /// </summary>
    public abstract class RestClient
    {
        protected string _baseUrl;

        protected RestClient(string baseUrl)
        {
            _baseUrl = baseUrl.TrimEnd('/');
        }

        /// <summary>
        ///    Obtiene la URL absoluta a donde realizar la petición
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string GetUrl(string relativePath, params object[] args)
        {
            if (relativePath == null)
                relativePath = String.Empty;

            relativePath = relativePath.TrimStart('/');

            if (args != null && args.Length > 0)
                relativePath = String.Format(relativePath, args);

            string url = String.Format("{0}/{1}", _baseUrl, relativePath);

            return url;
        }

        /// <summary>
        ///     Returns the default client
        /// </summary>
        /// <returns></returns>
        protected virtual HttpClient GetDefaultHttpClient()
        {
            var handler = new HttpClientHandler
                {
                    AllowAutoRedirect = true
                };

            var client = new HttpClient(handler, true);

            return client;
        }

        /// <summary>
        /// Ejecuta una petición GET y procesa el resultado
        /// </summary>
        /// <typeparam name="T">Tipo de datos que debe devolver</typeparam>
        /// <param name="url">Url a la que realizar la petición</param>
        /// <returns></returns>
        protected async Task<T> GetAsync<T>(string url) where T : new()
        {
            using (var client = GetDefaultHttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return (default(T));

                return await HandleResponse<T>(response);
            }
        }

        /// <summary>
        /// Ejecuta una petición PUT enviando un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T t)
        {
            using (var client = GetDefaultHttpClient())
            {
                var response = await client.PutAsJsonAsync(url, t);

                return await HandleResponse(response);
            }
        }

        /// <summary>
        /// Ejecuta una petición PUT enviando un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected async Task<TResult> PutAsync<T, TResult>(string url, T t)
        {
            using (var client = GetDefaultHttpClient())
            {
                var response = await client.PutAsJsonAsync(url, t);

                return await HandleResponse<TResult>(response);
            }
        }

        /// <summary>
        /// Ejecuta una petición POST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T t)
        {
            using (var client = GetDefaultHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, t);

                return await HandleResponse(response);
            }
        }

        /// <summary>
        /// Valida la respuesta obtenida y devuelve un HttpResponseMessage
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> HandleResponse(HttpResponseMessage response)
        {
            await ValidateResponseAsync(response);

            return response;
        }

        /// <summary>
        /// Valida la respuesta obtenida y la deserializa a un objeto de tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            await ValidateResponseAsync(response);

            return await response.Content.ReadAsAsync<T>();
        }

        /// <summary>
        /// Valida la respuesta
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static async Task<bool> ValidateResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return true;

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    var error = await response.Content.ReadAsAsync<HttpError>();
                    throw new BadRequestException(error);
                case HttpStatusCode.NotFound:
                    return false;
                default:
                    var content = await response.Content.ReadAsStringAsync();
                    throw new RestClientException(response.StatusCode, content);
            }
        }


        /// <summary>
        /// Ejecuta una petición POST enviando un objeto de tipo T
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected async Task<TResult> PostAsync<TCommand, TResult>(string url, TCommand t)
        {
            using (var client = GetDefaultHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, t);

                await HandleResponse(response);

                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        /// <summary>
        /// Ejecuta una petición DELETE
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            using (var client = GetDefaultHttpClient())
            {
                var response = await client.DeleteAsync(url);

                return await HandleResponse(response);
            }
        }
    }
}