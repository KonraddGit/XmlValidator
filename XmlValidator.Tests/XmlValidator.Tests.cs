using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidation.Tests
{
    [TestClass]
    public class XmlValidatiorTest
    {
        [TestMethod]
        public void CheckIfLibraryWorksCorrectly()
        {
            string xmlPath = $"deklaracja.xml";
            string xsdPath = $"schemat.xsd";
            XmlValidator xmlValidator = new XmlValidator(xsdPath, xmlPath);

            
        }
    }
}
