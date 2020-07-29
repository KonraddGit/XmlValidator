using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidation.Tests
{
    [TestClass]
    public class XmlValidatiorTest
    {
        [TestMethod]
        public void CheckingIfStringValueIsDifferentThanNull()
        {
            string filePath = "C:/Users/Konrad/Desktop/Work/Repozytorium Lokalne/xmlvalidator/XmlValidator/ConsoleApp1/bin/Debug/";
            string xmlPath = $"deklaracja.xml";
            string xsdPath = $"schemat.xsd";

            XmlValidator xmlValidator = new XmlValidator(xsdPath, xmlPath, filePath);

            
        }
    }
}
