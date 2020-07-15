using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Linq;

namespace XmlValidation
{
    public class GetAllFiles
    {
        private List<string> GetLinkFromFile(string url)
        {
            var newList = new List<string>();

            string pageXsd = File.ReadAllText(url);
            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match link in linkParser.Matches(pageXsd))
            {
                newList.Add(link.ToString());
            }
            return newList;
        }

        private string GetHttpPage(string url)
        {
            WebClient wc = new WebClient();
            var webpage = wc.DownloadString(url);
            return webpage;
        }

        public List<string> GetUrlsString(string url)
        {
            var result = new List<string>();
            var links = GetLinkFromFile(url);

            if (links.Count() > 0)
            {
                foreach (var item in links)
                {
                    GetHttpPage(item);
                    result.AddRange(GetUrlsString(item));
                }
            }

            result.AddRange(GetUrlsString(url));
            Console.WriteLine(result);
            return result;
        }

    }
}
