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
        private readonly AddingLinks addingLinks = new AddingLinks();

        //public List<string> GetUrlsString(string url)
        //{
        //    var result = new List<string>();
        //    var links = GetLinkFromFile(url);

        //    if (links.Count() > 0)
        //    {
        //        foreach (var item in links)
        //        {
        //            GetHttpPage(item);
        //            result.AddRange(GetUrlsString(item));
        //        }
        //    }

        //    result.AddRange(GetUrlsString(url));
        //    Console.WriteLine(result);
        //    return result;
        //}


        public void ShowAndDownload(string url, string xmlPath)
        {
            if (url.Contains(".xsd"))
            {
                addingLinks.AddLinksToDictionaryFromLocalXsd(url);
            }
            else addingLinks.AddLinksToDictionaryFromHtml(url);
            
            if (xmlPath.Contains(".xml"))
            {
                addingLinks.AddLinksToDictionaryFromLocalXml(xmlPath);
            }


            foreach (var item in addingLinks.urlList)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (var item in addingLinks.notWorkingLinks)
            {
                Console.WriteLine(item);
            }
        }

    }
}
