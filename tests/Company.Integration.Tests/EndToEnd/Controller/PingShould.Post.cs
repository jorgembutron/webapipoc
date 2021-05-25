using Company.Biz.Factories;
using Company.Biz.WebApi.Constants;
using Company.Biz.WebApi.ViewModels;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Company.Integration.Tests.EndToEnd.Controller
{
    public partial class PingShould
    {
        [Fact]
        public async Task CreateNewValidPing_AndReturn_NewIdAndHttpStatusCodeCreated()
        {
            //Arrange
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var contents = new StringContent(JsonSerializer.Serialize(VmFactory.CreatePingCommandViewModel(), options),
                Encoding.UTF8, MimeTypes.ApplicationsJson);

            //Act
            var response = await Client.PostAsync(Routes.PingRoute, contents);

            //Assert
            response.EnsureSuccessStatusCode();
            var responsePongVm = JsonSerializer.Deserialize<PingResponseVm>(await response.Content.ReadAsStringAsync(), options);

            Assert.True(responsePongVm.Id != 0);
        }
    }
}
