using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class ErrorBankParam
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public DateTimeOffset Date { get; set; }
        public int students { get; set; }
        public int departments { get; set; }
}
}
