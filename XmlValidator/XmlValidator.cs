using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;

namespace XmlValidation
{
    public class XmlValidator
    {
        public Results results = new Results(2);

        public XmlValidator(string xsdPath, string xmlPath, string filePath)
        {
            GetAllFiles getAllFiles = new GetAllFiles();


            Validator(xsdPath, xmlPath);

            if (results.validationStatus == 0)
            {
                getAllFiles.SearchFolderRecursive(filePath);
            }
            else 
            {
                Console.WriteLine("Validacja przeszła");
            }
        }


        private bool Validator(string xsdPath, string xmlPath)
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

                results.StatusOfValidation(1);
                results.PrintErrors();
            }
            catch (XmlException xe)
            {
                results.StatusOfValidation(0);
                Console.WriteLine(xe.Message, xe.LineNumber, xe.LinePosition);
                Errors error = new Errors(xe.LineNumber, xe.Message.ToString());
                results.Add(error);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                results.StatusOfValidation(0);
                Errors error = new Errors(0, e.Message.ToString());
                results.Add(error);
                return false;
            }

            return true;
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

