using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}