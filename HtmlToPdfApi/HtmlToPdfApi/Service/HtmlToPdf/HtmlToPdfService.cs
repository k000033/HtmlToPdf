using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdfApi.DTO;
using HtmlToPdfApi.InterFace.HtmlToPdf;

namespace HtmlToPdfApi.Service.HtmlToPdf
{
    public class HtmlToPdfService: IHtmlToPdfService
    {

        public readonly IConverter _converter;

        public HtmlToPdfService(IConverter converter)
        {
            _converter = converter;
        }


        public byte [] HtmlToPdf(PdfRequet pdfRequet)
        {

            var pdfDoc = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Out = null, // 不指定輸出路徑，返回為字節流
                },
                Objects = {
                    new ObjectSettings
                    {
                        PagesCount = true,
                        HtmlContent = pdfRequet.HtmlContent,
                        Page = pdfRequet.Url, // 若 HtmlContent 為空，則從 URL 生成 PDF
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]" },
                    }
                }

            };

            byte[] pdf = _converter.Convert(pdfDoc);
            return pdf; 
        }
    }
}
