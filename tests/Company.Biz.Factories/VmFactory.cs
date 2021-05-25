using Company.Biz.WebApi.Application.Commands;

namespace Company.Biz.Factories
{
    public static class VmFactory
    {
        public static CreatePingCommand CreatePingCommandViewModel() => new CreatePingCommand
        {
            Name = "Integration test"
        };
    }
}