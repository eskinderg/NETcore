public class AppSettings
{
    public string DbConnectionString { get; set; }
    public IdentityServer IdentityServer { get; set; }
    public Api Api { get; set; }
}

public class IdentityServer
{
    public string Authority { get; set; }
    public string Audience { get; set; }
    public bool RequireHttpsMetadata { get; set; }
}

public class Api {
    public string VersionReader { get; set; }
    public bool AssumeDefaultVersionWhenUnspecified { get; set; } = true;
}