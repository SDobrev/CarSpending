//namespace CarSpending.Data.RemoteData
//{
//    using Newtonsoft.Json;
//    using System.Net.Http;
//    using System.Threading.Tasks;

//    // fuelo api key beb5cdf4554ce11
//    public class HttpServerData : IData
//    {
//        private const string BaseUrl = "http://fuelo.net/api/price?key=beb5cdf4554ce11&fuel=";

//        public async Task<FuelPriceModel> GetFuelPrice(string type)
//        {
//            var client = new HttpClient();

//            var endpointUrl = BaseUrl + type;
//            var request = new HttpRequestMessage(HttpMethod.Get, endpointUrl);

//            var response = await client.SendAsync(request);
//            var content = await response.Content.ReadAsStringAsync();

//            var result = JsonConvert.DeserializeObject<FuelPricesGetResponse>(content);
//            return result.Result;
//        }
//    }
//}
