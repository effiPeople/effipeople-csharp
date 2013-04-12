using System;
using System.Net;

namespace effiPeople.Api.Client.Model.Exceptions
{
    public class RestClientException : Exception
    {
        protected HttpStatusCode StatusCode { get; set; }

        public RestClientException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public RestClientException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public RestClientException(HttpStatusCode statusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}