using Newtonsoft.Json;
/* using System; */
/* using System.Collections.Generic; */
/* using System.Linq; */
/* using System.Threading.Tasks; */
using System.Net.Http;
using System.Text;

namespace ProjectAPI.Helpers
{
  public class JsonContent :StringContent
  {
    public JsonContent(object value)
      : base(JsonConvert.SerializeObject(value), Encoding.UTF8,
          "application/json")
    {
    }

    public JsonContent(object value, string mediaType)
      : base(JsonConvert.SerializeObject(value), Encoding.UTF8, mediaType)
    {
    }

  }
}
