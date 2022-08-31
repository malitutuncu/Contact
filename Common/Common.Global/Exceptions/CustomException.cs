using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Global.Exceptions
{
    public class CustomException : Exception
    {
        public string Code { get; set; }
        public CustomException(string code) : base("custom exception")
        {
            Code = code;
        }
    }
}
