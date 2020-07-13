using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using XmlValidation.Models;

namespace XmlValidation
{
    public class XmlValidator
    {
        Results results = new Results(2);

        public XmlValidator(string xmlPath, string xsdPath, Links link)
        {
            LinksCheck linksCheck = new LinksCheck();
            linksCheck.AddLinksToListAndDeleteDuplicates(xsdPath, xmlPath);
            linksCheck.ListOfUrls();
            linksCheck.CheckUrlAndReturnIfFalse();

            Validator(xsdPath, xmlPath);
        }


        private void Validator(string xsdPath, string xmlPath)
        {

            try
            {

                ValidationEvents validationEvents = new ValidationEvents();
                XmlReaderSettings Xsettings = new XmlReaderSettings();
                Xsettings.Schemas.Add(null, xsdPath);

                Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                Xsettings.ValidationEventHandler += new ValidationEventHandler(validationEvents.ValidationCallBack);

                Xsettings.ValidationType = ValidationType.Schema;

                XmlDocument document = new XmlDocument();
                document.Load(xmlPath);

                XmlReader reader = XmlReader.Create(new StringReader(document.InnerXml), Xsettings);


                while (reader.Read()) ;

                Console.WriteLine("\n Successful Validation");
                results.StatusOfValidation(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                results.StatusOfValidation(0);
                Errors error = new Errors(28, e.Message.ToString());//28?
                results.Add(error);

            }
        }
    }

}

