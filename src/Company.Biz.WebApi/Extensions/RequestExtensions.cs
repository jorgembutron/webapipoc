using Company.Biz.WebApi.Application.Commands;
using Company.Biz.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Extensions
{
    public static class RequestExtensions
    {
        public static CreatePingCommand ToCreatePingCommand(this PingRequest request) => new CreatePingCommand() { Name = request.Name };
    }
}
