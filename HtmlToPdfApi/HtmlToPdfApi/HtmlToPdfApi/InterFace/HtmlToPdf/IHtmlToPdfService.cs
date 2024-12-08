using HtmlToPdfApi.DTO;

namespace HtmlToPdfApi.InterFace.HtmlToPdf
{
    public interface IHtmlToPdfService
    {
        public byte[] HtmlToPdf(PdfRequet pdf);
    }
}
