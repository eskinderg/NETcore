public class AppSettings
{
  public string DbConnectionString     { get; set; }
  public IdentityServer IdentityServer { get; set; }
  public Api Api                       { get; set; }
  public MoviesApi MoviesApi           { get; set; }
  public Auth0 Auth0                   { get; set; }
}

public class IdentityServer
{
  public string Authority          { get; set; }
  public string Audience           { get; set; }
  public bool RequireHttpsMetadata { get; set; }
}

public class Api {
  public string VersionReader                     { get; set; }
  public bool AssumeDefaultVersionWhenUnspecified { get; set; } = true;
}

public class MoviesApi {
  public string Url { get; set; }
  public string Key { get; set; }
}

public class Auth0 {
  public string Domain        { get; set; }
  public string ApiIdentifier { get; set; }
}
