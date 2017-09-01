

using System.Net;

namespace SampleEmailSettings.ViewModel
{
    public class ApiResponse
    {
        public string Status { get; set; }

        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public object Data { get; set; }

        public int TotalRecords { get; set; }

        public ApiResponse(string status, HttpStatusCode statusCode, int totalRecords = 0, object data = null, string errorMessage = null)
        {
            Status = status;
            StatusCode = (int)statusCode;
            Data = data;
            ErrorMessage = errorMessage;
            TotalRecords = totalRecords;
        }

    }
}
