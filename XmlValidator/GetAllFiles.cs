using System.Collections.Generic;
using System;
using System.Linq;

namespace XmlValidation
{
    public class GetAllFiles
    {
        private readonly AddingLinks addingLinks = new AddingLinks();
        
        //public Dictionary<string,string> GetUrlsString(string url)
        //{
        //    var result = new List<string>();

        //    if (links.Count() > 0)
        //    {
        //        foreach (var item in links)
        //        {
        //            result.Add(GetUrlsString(item));
        //        }
        //    }

        //    result.Add(GetUrlsString(url));

        //    return result;
        //}


        public void ShowAndDownload(string xsdPath, string xmlPath)
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
