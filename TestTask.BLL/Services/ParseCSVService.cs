using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.Interfaces;

namespace TestTask.BLL.Services
{
    public class ParseCSVService : IParseCSVService
    {
        public List<dynamic> ParseCsv(Stream fileStream)
        {
            Encoding encoding = DetectEncoding(fileStream);
            fileStream.Position = 0; // Reset stream position safely

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",  // Ensure proper column separation
                HasHeaderRecord = true,  // First row is treated as headers
                IgnoreBlankLines = true, // Ignore empty lines
                TrimOptions = TrimOptions.Trim, // Remove extra spaces
                BadDataFound = null // Ignore bad data instead of throwing an error
            };

            using var reader = new StreamReader(fileStream, encoding, detectEncodingFromByteOrderMarks: true, leaveOpen: true);
            using var csv = new CsvReader(reader, config);

            return new List<dynamic>(csv.GetRecords<dynamic>());
        }

        private Encoding DetectEncoding(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream, detectEncodingFromByteOrderMarks: true, leaveOpen: true);
            reader.Peek(); // Trigger encoding detection
            return reader.CurrentEncoding;
        }

    }
}
