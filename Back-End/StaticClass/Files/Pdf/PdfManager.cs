using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using StaticClass.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace StaticClass.Files.Pdf
{
    public class PdfManager : IPdfManager
    {
        private void WriteListToPdf<T>(IEnumerable<T> source, Document doc) where T : class
        {
            Style styleHeaderTable = new Style()
                .SetFontSize(10)
                .SetBold()
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            Style styleRowTable = new Style()
                .SetFontSize(10)
                .SetBold()
                .SetBackgroundColor(ColorConstants.WHITE);

            IList<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties());

            Table table = new Table(props.Count, true);

            doc.Add(table);

            foreach (var p in props)
            {
                table.AddHeaderCell(new Paragraph(p.Name)).AddStyle(styleHeaderTable);
            }
            table.Flush();

            foreach (var emp in source)
            {
                foreach (var prop in props)
                {
                    var value = emp.GetType().GetProperty(prop.Name).GetValue(emp, null)?.ToString();
                    table.AddCell(new Paragraph(value ?? "")).AddStyle(styleRowTable);
                }
                table.Flush();
            }

            table.Complete();
        }

        public byte[] Generate<T>(string title, string subtitle, IEnumerable<T> source) where T : class
        {
            try
            {
                using var stream = new MemoryStream();
                using var writer = new PdfWriter(stream);
                using var pdf = new PdfDocument(writer);
                using var doc = new Document(pdf, PageSize.A4);

                Style styleTitle = new Style()
                    .SetBold()
                    .SetFontSize(20);

                Style styleSubTitle = new Style()
                    .SetBold()
                    .SetFontSize(16);

                if (!string.IsNullOrEmpty(title))
                    doc.Add(new Paragraph(title).AddStyle(styleTitle));

                if (!string.IsNullOrEmpty(subtitle))
                    doc.Add(new Paragraph(subtitle).AddStyle(styleSubTitle));

                WriteListToPdf(source, doc);

                doc.Close();

                return stream.ToArray();
            }
            catch (System.Exception ex)
            {
                throw new FileGenerationException($"Error al generar el Pdf: {ex.Message}");
            }
        }

        //Type myType = T.GetType();
        //IList<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties());

        // table with 2 columns:
        //Table table = new Table(2);
        // header row:

        //var sbHeader = new StringBuilder();
        //var sbRow = new StringBuilder();

        //foreach (PropertyInfo prop in props)
        //{
        //    sbHeader.Append($"<th scope='col'>{prop.Name}</th>");
        //}

        //foreach (var emp in source)
        //{
        //    sbRow.Append(@"<tr>");
        //    foreach (var prop in props)
        //    {
        //        sbRow.AppendFormat(@"<td>{0}</td>", emp.GetType().GetProperty(prop.Name).GetValue(emp, null));
        //    }
        //    sbRow.Append(@"</tr>");
        //}

        //var sb = new StringBuilder();
        //sb.Append(@$"
        //            <html>
        //                <head>
        //                </head>
        //                <body>
        //                    <div class='header'><h1>This is the generated PDF report!!!</h1></div>

        //                    <table class='table'>
        //                        <thead>
        //                            <tr>
        //                                {sbHeader}
        //                            </tr>
        //                        </thead>
        //                        <tbody>
        //                            {sbRow}
        //                        </tbody>
        //                    </table>
        //                </body>
        //            </html>");

        //return stream.ToArray();


    }
}
