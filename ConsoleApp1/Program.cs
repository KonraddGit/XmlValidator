using System;

namespace XmlValidation
{
    class Program
    {
        //http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/DefinicjeTypy/
        // — kopia
        static void Main(string[] args)
        {
            string xmlPath = "deklaracja.xml";
            string xsdPath = "http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/DefinicjeTypy/";

            XmlValidator xmlValidator = new XmlValidator(xmlPath, xsdPath);

            GetAllFiles getAllFiles = new GetAllFiles();

            Console.ReadLine();
        }
        
    }
}
