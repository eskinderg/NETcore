using System;
/* using System.Collections.Generic; */
/* using System.Linq; */
/* using System.Net.Http; */
/* using System.Threading.Tasks; */

namespace ProjectAPI.Helpers
{
  public static class UriHelper
  {
#region static methods
    internal static Uri CombineUri(Uri baseUri, string relativeUrl)
    {
      string local = baseUri.ToString() + relativeUrl;
      if (local != null && (!String.IsNullOrEmpty(local)))
      {
        return new Uri(local);
      }
      return new Uri(local);
    }
#endregion
  }
}
