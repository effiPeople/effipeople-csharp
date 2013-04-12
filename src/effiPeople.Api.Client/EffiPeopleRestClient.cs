using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using EffiPeople.Api.Client;
using effiPeople.Api.Client.Model.Common;

namespace effiPeople.Api.Client
{
    /// <summary>
    ///     EffiPeople REST API wrapper
    /// </summary>
    public partial class EffiPeopleRestClient : RestClient
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly AuthenticationType _authenticationScheme = AuthenticationType.Basic;

        /// <summary>
        ///     Inicializa un nuevo cliente con la clave de acceso especificada
        /// </summary>
        /// <param name="accessKey"></param>
        public EffiPeopleRestClient(string accessKey) : base("https://api.effipeople.com/v1")
        {
            _accessKey = accessKey;
            _authenticationScheme = AuthenticationType.Basic;
        }

        /// <summary>
        ///     Inicializa un nuevo cliente con la clavede acceso, la clave secreta y el tipo de autenticación
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="authenticationScheme"></param>
        public EffiPeopleRestClient(string accessKey, string secretKey, AuthenticationType authenticationScheme)
            : base("https://api.effipeople.com/v1")
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
            _authenticationScheme = authenticationScheme;
        }

        /// <summary>
        ///     Inicializa un nuevo cliente con la clavede acceso, la clave secreta, el tipo de autenticación y la url base
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="authenticationScheme"></param>
        /// <param name="baseUrl"></param>
        public EffiPeopleRestClient(string accessKey, string secretKey, AuthenticationType authenticationScheme, string baseUrl) : base(baseUrl)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
            _authenticationScheme = authenticationScheme;
        }

        /// <summary>
        ///     Tipo de autenticación
        /// </summary>
        public AuthenticationType AuthenticationScheme
        {
            get { return _authenticationScheme; }
        }

        /// <summary>
        ///     Obtiene el cliente Http
        /// </summary>
        /// <returns></returns>
        protected override HttpClient GetDefaultHttpClient()
        {
            var client = base.GetDefaultHttpClient();

            client.DefaultRequestHeaders.Authorization = CreateAuthenticationHeader();

            return client;
        }

        /// <summary>
        ///     Crea la cabecera de autenticación
        /// </summary>
        /// <returns></returns>
        protected AuthenticationHeaderValue CreateAuthenticationHeader()
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", _accessKey, _secretKey)));
            var authenticationHeaderValue = new AuthenticationHeaderValue(_authenticationScheme.ToString(), token);
            return authenticationHeaderValue;
        }
    }
}