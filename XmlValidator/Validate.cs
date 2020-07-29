using System.Data.SqlClient;
using System.IO;

namespace XmlValidation
{
    class Validate
    {
        public static MemoryStream xmlFile(string varID)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
            using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", varConnection))
            {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null)
                    {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        memoryStream.Write(blob, 0, blob.Length);
                    }
            }
            return memoryStream;
        }

        public static MemoryStream xsdFile(string varID)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (var varConnection = "")
            using (var sqlQuery = new SqlCommand(@"", varConnection))
            {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null)
                    {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        memoryStream.Write(blob, 0, blob.Length);
                    }
            }
            return memoryStream;
        }

        XmlValidator XmlValidation = new XmlValidator(xmlFile, xsdFile);
    }
}
