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
    /// <summary>
    /// Represents a client for sending requests to the Datamuse API.
    /// </summary>
    public class DatamuseClient
    {
        const string BASE_URL = "http://api.datamuse.com";

        WebClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatamuseClient"/> class.
        /// </summary>
        public DatamuseClient()
        {
            client = new WebClient();
        }

        /// <summary>
        /// Creates a URL from the given request.
        /// </summary>
        /// <param name="request">The request to create the URL from.</param>
        /// <returns>The resulting URL as a string.</returns>
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

        /// <summary>
        /// Sends a request to the API.
        /// </summary>
        /// <param name="request">The request to send.</param>
        /// <returns>The resulting items.</returns>
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
                    if(resultObj[i]["defHeadword"] != null)
                    {
                        nextResult.headword = resultObj[i]["defHeadword"].Value<string>();
                    }
                }

                if (resultObj[i]["numSyllables"] != null)
                {
                    nextResult.syllableCount = resultObj[i]["numSyllables"].Value<int>();
                }

                results[i] = nextResult;
            }

            return results;
        }

        /// <summary>
        /// Sends a request for a set of words using the provided request modifiers.
        /// </summary>
        /// <param name="modifiers">The request modifiers to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] Words(params IRequestModifier[] modifiers)
        {
            return Send(new WordsRequest(modifiers));
        }

        /// <summary>
        /// Sends a request for a set of completion suggestions using the provided prefix and modifiers.
        /// </summary>
        /// <param name="prefix">The prefix for the suggestions.</param>
        /// <param name="modifiers">The modifiers to use with the request.</param>
        /// <returns></returns>
        public DatamuseResultItem[] Suggestions(string prefix, params IRequestModifier[] modifiers)
        {
            return Send(new SuggestionsRequest(prefix, modifiers));
        }

        /// <summary>
        /// Sends a request for a set of words that have similar meanings to the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] MeansLike(string word)
        {
            return Words(new MeansLikeModifier(word));
        }

        /// <summary>
        /// Sends a request for a set of words that sound similar to the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] SoundsLike(string word)
        {
            return Words(new SoundsLikeModifier(word));
        }

        /// <summary>
        /// Sends a request for a set of words that have similar spellings to the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] SpelledLike(string word)
        {
            return Words(new SpelledLikeModifier(word));
        }

        /// <summary>
        /// Sends a request for a set of words that are likely to appear before the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] Before(string word)
        {
            return Words(new RightContextModifier(word));
        }

        /// <summary>
        /// Sends a request for a set of words that are likely to appear after the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] After(string word)
        {
            return Words(new LeftContextModifier(word));
        }

        /// <summary>
        /// Sends a request for a set of words that rhyme with the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] Rhymes(string word)
        {
            return Words(new RelationModifier(word, RelationType.Rhyme));
        }

        /// <summary>
        /// Sends a request for a set of words that approximately rhyme with the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] ApproximateRhymes(string word)
        {
            return Words(new RelationModifier(word, RelationType.ApproximateRhyme));
        }

        /// <summary>
        /// Sends a request for a set of words that are synonyms of the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] Synonyms(string word)
        {
            return Words(new RelationModifier(word, RelationType.Synonym));
        }

        /// <summary>
        /// Sends a request for a set of words that are antonyms of the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] Antonyms(string word)
        {
            return Words(new RelationModifier(word, RelationType.Antonym));
        }

        /// <summary>
        /// Sends a request for a set of adjectives that can be used on the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] AdjectivesUsedOn(string word)
        {
            return Words(new RelationModifier(word, RelationType.AdjectiveUsedOn));
        }

        /// <summary>
        /// Sends a request for a set of nouns that can be modified by the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] NounsModifiedBy(string word)
        {
            return Words(new RelationModifier(word, RelationType.NounModifiedBy));
        }

        /// <summary>
        /// Sends a request for a set of words that are statistically associated with the provided word.
        /// </summary>
        /// <param name="word">The word to use with the request.</param>
        /// <returns>The resulting items.</returns>
        public DatamuseResultItem[] Triggers(string word)
        {
            return Words(new RelationModifier(word, RelationType.Trigger));
        }
    }
}