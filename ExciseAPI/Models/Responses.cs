using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExciseAPI.Models
{
    public class Responses
    {
        public class responseMessage
        {
            public bool IsSuccess { get; set; }

            public string ReturnMessage { get; set; }

            public int SuccessCode { get; set; }

            public string Message { get; set; }
        }
        public enum StatusCodes
        {
            Success = 200,
            Create = 201,
            Accept = 202,
            Badrequest = 400,
            Unauthorized = 401,
            NotFound = 404,
            InternalServerError = 500,
            InvalidDetails = 100,
            ApkVersion = 111,
        }
    }
}