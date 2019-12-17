using System;

namespace Tfl.Api.Presentation.Entities
{
    public class ApiError
    {
        public DateTime timestampUtc { get; set; }
        public string exceptionType { get; set; }
        public int httpStatusCode { get; set; }
        public string httpStatus { get; set; }
        public string relativeUri { get; set; }
        public string message { get; set; }
    }
}

