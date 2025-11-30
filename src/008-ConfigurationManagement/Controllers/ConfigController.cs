using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController
{
    private IConfiguration _config;
    private AppSettings _appConfig;

    public ConfigController(IConfiguration config, IOptions<AppSettings> options)
    {
        _config = config;
        _appConfig = options.Value;
    }

    [HttpGet]
    public string Get()
    {
        // Using IOptions
        var appNameO = _appConfig.ApplicationName;
        var maxItemPerPageO = _appConfig.MaxItemsPerPage;
        var adminEmailO = _appConfig.AdminEmail;

        // Using IConfiguration
        var appName = _config["AppSettings:ApplicationName"] ?? "App Name";
        var maxItemPerPage = _config["AppSettings:MaxItemsPerPage"] ?? "10";
        var adminEmail = _config["AppSettings:AdminEmail"] ?? "N/A";

        return $@"Config
    -App Name(IOptions): {appNameO}
    -App Name(Iconfiguration): {appName}

    -Max Item(IOptions): {maxItemPerPageO}
    -Max Item(Iconfiguration): {maxItemPerPage}

    -Admin Email(IOptions): {adminEmailO}
    -Admin Email(Iconfiguration): {adminEmail}";
    }
}

public class AppSettings
{
    public string ApplicationName { get; set; }
    public int MaxItemsPerPage { get; set; }
    public string AdminEmail { get; set; }
}
