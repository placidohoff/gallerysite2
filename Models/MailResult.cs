using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAzureWebApp.Models
{
    public class MailResult
    {
        private readonly bool _isSuccess;

        public MailResult(bool isSuccess)
        {
            _isSuccess = isSuccess;
        }
    }
}