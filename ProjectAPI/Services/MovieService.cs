using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProjectAPI.Helpers;

namespace ProjectAPI.Services
{
  public class MovieService : IMovieService
  {

    private readonly IOptionsSnapshot<AppSettings> _settings;
    private readonly HttpClient                    _apiClient;
    private readonly IHttpContextAccessor          _httpContextAccesor;
    private static   HttpClient                    client = new HttpClient();
    private readonly string                        _remoteServiceBaseUrl;

    public MovieService(IOptionsSnapshot<AppSettings> settings, HttpClient httpClient, IHttpContextAccessor httpContextAccesor)
    {
      _settings             = settings;
      _apiClient            = httpClient;
      _httpContextAccesor   = httpContextAccesor ?? throw new ArgumentNullException(nameof(httpContextAccesor));
      _remoteServiceBaseUrl = $"{_settings.Value.MoviesApi.Url}";
    }
    public async Task <List<MovieViewModel>> GetPopular()
    {
      client.BaseAddress     = new Uri(_remoteServiceBaseUrl);
      string _movieUrlPrefix = "tv/popular?&api_key=" + this._settings.Value.MoviesApi.Key;
      Uri moviesUri          = UriHelper.CombineUri(client.BaseAddress, _movieUrlPrefix);
      var response           = await HttpRequestFactory.Get(moviesUri.ToString());
      var outputModel        = response.ContentAsType<MovieModel>();

      return outputModel.results;;
    }
  }

  public class MovieModel{
    public string page                  { get; set; }
    public string total_results         { get; set; }
    public string total_pages           { get; set; }
    public List<MovieViewModel> results { get; set; }
  }

  public class MovieViewModel {
    public string original_name { get; set; }
    public string name          { get; set; }
    public string overview      { get; set; }
    public string backdrop_path { get; set; }
  }
}
