using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using LearningSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LearningSystem.Services.Implementations
{
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GeneratePdfFromHtml(string html)
        {
            var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            var htmlparser = new HtmlWorker(pdfDoc);
            using(MemoryStream memoryStream =new MemoryStream())
            {
                var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                using (StringReader stringReader = new StringReader(html))
                {
                    htmlparser.Parse(stringReader);
                } 
                pdfDoc.Close(); 
                return memoryStream.ToArray();
            }
        }
    }
}
