using System.Collections.Generic;

namespace XmlValidation.Models
{

    public class Links
    {
        private string xmlPath = $"deklaracja.xml";
        private string xsdPath = $"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/DefinicjeTypy/";
        public string XsdPath { get; set; }
        public string XmlPath { get; set; }
    }
}
