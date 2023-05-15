using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaPraktyczneKursCSharpZUdemy
{
    internal class OperationResult
    {
        public string ErrorMessage { get; private set; }

        public OperationResult(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        private OperationResult()
        {
        }

        public bool IsSuccess()
        {
            return string.IsNullOrEmpty(this.ErrorMessage);
        }

        public bool IsError()
        {
            return !IsSuccess();    
        }

        public static OperationResult Success()
        {
            return new OperationResult();
        }
    }
}
