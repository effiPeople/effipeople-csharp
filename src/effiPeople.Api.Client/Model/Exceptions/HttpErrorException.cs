using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace effiPeople.Api.Client.Model.Exceptions
{
    public class HttpErrorException : RestClientException
    {
        private readonly HttpError _error;

        public HttpErrorException(HttpStatusCode statusCode, HttpError error) : base(statusCode)
        {
            _error = error;
        }

        public override IDictionary Data
        {
            get { return _error; }
        }

        public override string Message
        {
            get { return _error.Message; }
        }

        private Dictionary<string, IList<string>> _modelState;

        public Dictionary<string, IList<string>> ModelState
        {
            get
            {
                if (_modelState == null)
                {
                    _modelState = _error.ContainsKey("ModelState")
                                      ? ((JObject) _error["ModelState"]).ToObject<Dictionary<string, IList<string>>>()
                                      : new Dictionary<string, IList<string>>();
                }

                return _modelState;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}\n{1}\n", Message, ModelState);
        }
    }
}