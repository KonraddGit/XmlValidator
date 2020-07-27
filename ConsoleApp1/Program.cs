using System;

namespace XmlValidation
{
    class Program
    {
        //http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/DefinicjeTypy/
        // — kopia
        
        static void Main(string[] args)
        {
            string filePath = "C:/Users/Konrad/Desktop/Work/Repozytorium Lokalne/xmlvalidator/XmlValidator/ConsoleApp1/bin/Debug/";
            string xmlPath = $"deklaracja.xml";
            string xsdPath = $"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/DefinicjeTypy/";


            XmlValidator xmlValidator = new XmlValidator(filePath);


            Console.ReadLine();
        }
        
    }
}
