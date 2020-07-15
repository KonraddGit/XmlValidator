using System;

namespace XmlValidation
{
    class Program
    {
        // — kopia
        static void Main(string[] args)
        {
            string xmlPath = "deklaracja.xml";
            string xsdPath = "schemat.xsd";

            XmlValidator xmlValidator = new XmlValidator(xmlPath, xsdPath);

            GetAllFiles getAllFiles = new GetAllFiles();

            Console.ReadLine();
        }
        
    }
}
