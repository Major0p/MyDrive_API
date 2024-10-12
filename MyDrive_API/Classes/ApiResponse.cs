using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyDrive_API.Classes
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }

        public ApiResponse()
        {
            IsSuccess = false;
            Data = [];
            Message = "Failed"; 
        }

        public void SetSuccessApiResopnse(List<T>? DataList = null)
        {
            IsSuccess = true;
            Data = DataList ?? [];
            Message = "Success";
        }
    }
}

