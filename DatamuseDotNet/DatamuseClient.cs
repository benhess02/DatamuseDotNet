using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DatamuseDotNet
{
    public class DatamuseClient
    {
        const string BASE_URL = "http://api.datamuse.com";

        WebClient client;

        public DatamuseClient()
        {
            client = new WebClient();
        }

        public string CreateURL(DatamuseRequest request)
        {
            string url = BASE_URL + request.GetEndpoint() + "?";
            Dictionary<string, string> parameters = request.GetParameters();
            List<string> pairStrings = new List<string>();
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                pairStrings.Add(pair.Key + "=" + HttpUtility.UrlEncode(pair.Value));
            }
            url += string.Join("&", pairStrings);
            return url;
        }

        public DatamuseResultItem[] Send(DatamuseRequest request)
        {
            string json = client.DownloadString(CreateURL(request));
            JArray resultObj = JArray.Parse(json);
            DatamuseResultItem[] results = new DatamuseResultItem[resultObj.Count];

            for(int i = 0; i < resultObj.Count; i++)
            {
                DatamuseResultItem nextResult = new DatamuseResultItem();
                nextResult.word = resultObj[i].Value<string>("word");
                nextResult.score = resultObj[i].Value<int>("score");

                if(resultObj[i]["tags"] != null)
                {
                    nextResult.tags = resultObj[i]["tags"].Values<string>().ToArray();
                }

                if (resultObj[i]["defs"] != null)
                {
                    nextResult.definitions = resultObj[i]["defs"].Values<string>().ToArray();
                }

                if (resultObj[i]["numSyllables"] != null)
                {
                    nextResult.syllableCount = resultObj[i]["numSyllables"].Value<int>();
                }

                results[i] = nextResult;
            }

            return results;
        }

        public DatamuseResultItem[] Words(params IRequestModifier[] modifiers)
        {
            return Send(new WordsRequest(modifiers));
        }

        public DatamuseResultItem[] Suggestions(string prefix, params IRequestModifier[] modifiers)
        {
            return Send(new SuggestionsRequest(prefix, modifiers));
        }

        public DatamuseResultItem[] MeansLike(string word)
        {
            return Words(new MeansLikeModifier(word));
        }

        public DatamuseResultItem[] SoundsLike(string word)
        {
            return Words(new SoundsLikeModifier(word));
        }

        public DatamuseResultItem[] SpelledLike(string word)
        {
            return Words(new SpelledLikeModifier(word));
        }

        public DatamuseResultItem[] Before(string word)
        {
            return Words(new RightContextModifier(word));
        }

        public DatamuseResultItem[] After(string word)
        {
            return Words(new LeftContextModifier(word));
        }
    }
}