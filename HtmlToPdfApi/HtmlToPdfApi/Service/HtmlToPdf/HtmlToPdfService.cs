using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlToPdfApi.DTO;
using HtmlToPdfApi.InterFace.HtmlToPdf;
using PuppeteerSharp;

namespace HtmlToPdfApi.Service.HtmlToPdf
{
    public class HtmlToPdfService: IHtmlToPdfService
    {

        public readonly IConverter _converter;

        public HtmlToPdfService(IConverter converter)
        {
            _converter = converter;
        }


        public byte [] HtmlToPdfToWeb(PdfRequet pdfRequet)
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
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]" },
                    }
                }

            };

            byte[] pdf = _converter.Convert(pdfDoc);
            return pdf; 
        }


        public async Task<ReturMsg> HtmlToPdfToLocal (PdfRequet pdfRequet)
        {

            ReturMsg returMsg = new ReturMsg();

            try
            {
                // 確保 Chromium 二進制文件已經被下載
                var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync("859413"); // 如果此行仍有錯誤，使用下面的方式

                var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
                var page = await browser.NewPageAsync();

                // 設置 HTML 內容
                await page.SetContentAsync(pdfRequet.HtmlContent);

                // 設置 PDF 輸出的路徑
                var pdfFilePath = Path.Combine(@"C:\Users\k0000\OneDrive\桌面\SideProject\HtmlToPDF\PDF", $"{System.Guid.NewGuid()}.pdf");

                // 生成 PDF
                await page.PdfAsync(pdfFilePath);

                await browser.CloseAsync();


                returMsg.ReturCode = 0;
                returMsg.ReturMessage = "成功";
            }
            catch (Exception ex)
            {

                returMsg.ReturCode = 1;
                returMsg.ReturMessage =ex.Message;
            }
            
            return returMsg;
        }
    }
}
