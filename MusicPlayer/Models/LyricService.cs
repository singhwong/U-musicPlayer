using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    class LyricService
    {
        private HttpClient client = new HttpClient();
        private HttpResponseMessage response;
        private LyricData serviceData;
        public LyricData GetLyrics(string artist, string songTitle)
        {
            client.BaseAddress = new Uri("https://api.lyrics.ovh/v1/");
            //"https://api.lyrics.ovh/v1/artist/songTitle"
            response = client.GetAsync($"{artist}/{songTitle}").Result;

            if (response.IsSuccessStatusCode)
            {
                string output = response.Content.ReadAsStringAsync().Result;
                output = output.Replace($"\\n", Environment.NewLine);
                //if conversion fails, every property gets default Value.
                serviceData = JsonConvert.DeserializeObject<LyricData>(output);
                //object containing lyrics
                return serviceData;
            }
            else
            {
                return null;
            }
        }

        public class LyricData
        {
            //the annotation will let JsonDeserialise read the property as lyrics instead of the actual name.
            [JsonProperty(PropertyName = "lyrics")]
            public string Lyrics { get; set; }
        }
    }
}
