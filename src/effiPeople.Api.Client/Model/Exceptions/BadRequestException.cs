using System.Net;
using System.Web.Http;

namespace effiPeople.Api.Client.Model.Exceptions
{
    public class BadRequestException : HttpErrorException
    {
        public BadRequestException(HttpError error) : base(HttpStatusCode.BadRequest, error)
        {
        }
    }
}