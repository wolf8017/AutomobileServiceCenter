using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC.Web.Service
{
    interface ISmsSender
    {
        public Task SendSmsAsync(string number, string message);
    }
}
