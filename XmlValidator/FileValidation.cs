using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using XmlValidation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XmlValidation
{
    public class XmlValidator
    {
        public Results results = new Results(2);

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
                results.PrintErrors();
            }
            catch (XmlException xe)
            {
                results.StatusOfValidation(0);
                Console.WriteLine(xe.Message, xe.LineNumber, xe.LinePosition);
                Errors error = new Errors(xe.LineNumber, xe.Message.ToString());
                results.Add(error);
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message.ToString());
                results.StatusOfValidation(0);
                Errors error = new Errors(0, e.Message.ToString());
                results.Add(error);

            }
        }
    }

    /// //////////////////////////////// TODO przerzucić do pliku

    public struct Errors
    {
        public int lineNumber;
        public string errorSubstance;

        public Errors(int lineNumber, string errorSubstance)
        {
            this.lineNumber = lineNumber;
            this.errorSubstance = errorSubstance;
        }
        public void Print()
            {
                Console.WriteLine($"błąd w linii {lineNumber}, treść:  {errorSubstance}");
            }
    }
    /*
    //deklarowanie struktury:
    Results name = new Results(1);  //1-walidacja przebieła pomyślnie
                                    //0-walidacja nie powiodła się
                                    //2-brak dostępu do plików zdalnych
    name.ValidationStatus(0);
    Errors name2 = new Errors(14, "errorSubstance"); //nr lini błędu, treść błędu
    name.Add(name2);
    Errors name3 = new Errors(28, "errorSubstance"); 
    name.Add(name3);
    */
    public struct Results
    {
        public enum ValidationStatus
        {
            Failure = 0,
            Success = 1,
            Inconclusive = 2
        }
        public ValidationStatus validationStatus;

        private List<Errors> ErrorList;

        public Results(int statusOfValidation)
        {
            switch (statusOfValidation)
            {
                case 1:
                    validationStatus = ValidationStatus.Success;
                    break;
                case 0:
                    validationStatus = ValidationStatus.Failure;
                    break;
                case 2:
                    validationStatus = ValidationStatus.Inconclusive;
                    break;
                default:
                    validationStatus = ValidationStatus.Inconclusive;
                    break;
            }
            ErrorList = new List<Errors>();
        }
        public void StatusOfValidation(int statusOfValidation)
        {
            switch (statusOfValidation)
            {
                case 1:
                    validationStatus = ValidationStatus.Success;
                    break;
                case 0:
                    validationStatus = ValidationStatus.Failure;
                    break;
                case 2:
                    validationStatus = ValidationStatus.Inconclusive;
                    break;
                default:
                    validationStatus = ValidationStatus.Inconclusive;
                    break;
            }
        }

        public void Add(Errors error)
        {
            ErrorList.Add(error);
        }

        public void PrintErrors()
            {
                foreach (Errors element in ErrorList)
                {
                    element.Print();
                }
            }
    }

}

