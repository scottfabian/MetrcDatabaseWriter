using MetrcAPIService;
using Microsoft.Extensions.Configuration;

namespace MetrcDatabaseWriter;

public class MetrcApiFactory
{
    private IConfiguration _config;
    private HttpClient _httpClient;

    public MetrcApiFactory(IConfiguration config, HttpClient httpClient)
    {
        _config = config;
        _httpClient = httpClient;
    }

    public MetrcAPI CreateMetrcAPI()
    {
        string vendorKey = _config["Metrc:VendorKey"];
        string userKey = _config["Metrc:UserKey"];
        string baseUrl = _config["Metrc:BaseURL"];

        var metrc = new MetrcAPI(baseUrl, _httpClient, vendorKey, userKey);

        return metrc;
    }
}
