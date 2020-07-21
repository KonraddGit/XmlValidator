using System.Collections.Generic;
using System;
using System.Linq;

namespace XmlValidation
{
    public class GetAllFiles
    {
        private readonly AddingLinks addingLinks = new AddingLinks();

        private List<string> FinalList = new List<string>();

        public List<string> GetUrlsString(string url)
        {
            var result = new List<string>();
            var links = FinalList;

            if (!links.Contains(url))
            {
                if (links.Count() > 0)
                {
                    foreach (var item in links)
                    {
                        result.AddRange(GetUrlsString(item.ToString()));
                    }
                }
                result.AddRange(GetUrlsString(url.ToString()));
            }

            Console.WriteLine(links.ToString());
            return result;
        }


        public List<string> ShowAndDownload(string xsdPath, string xmlPath)
        {
            if (xsdPath.Contains(".xsd"))
            {
                addingLinks.AddLinksToDictionaryFromLocalXsd(xsdPath);

            }
            else addingLinks.AddLinksToDictionaryFromHtmlAndDownload(xsdPath);
            
            if (xmlPath.Contains(".xml"))
            {
                addingLinks.AddLinksToDictionaryFromLocalXml(xmlPath);
            }


            foreach (var item in addingLinks.urlDictionary)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (var item in addingLinks.notWorkingLinks)
            {
                Console.WriteLine(item);
            }
            FinalList = addingLinks.urlDictionary.Keys.ToList();

            return FinalList;
        }

    }
}
