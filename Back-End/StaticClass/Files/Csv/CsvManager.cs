using CsvHelper;
using CsvHelper.Configuration;
using StaticClass.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Files.Csv
{
    public class CsvManager : ICsvManager
    {
        public byte[] Generate<T>(IEnumerable<T> source) where T : class
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(true)))
                    {
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            LeaveOpen = true,
                            Delimiter = ";"
                        };

                        using (var csvWriter = new CsvWriter(streamWriter, config))
                        {
                            csvWriter.WriteRecords(source);
                        }
                    }

                    return memoryStream.ToArray();
                }
            }
            catch (System.Exception ex)
            {
                throw new FileGenerationException($"Error al generar el Csv: {ex.Message}");
            }
        }

    }
}
