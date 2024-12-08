using HtmlToPdfApi.DTO;

namespace HtmlToPdfApi.InterFace.HtmlToPdf
{
    public interface IHtmlToPdfService
    {
        public byte[] HtmlToPdfToWeb(PdfRequet pdf);
        public  Task<ReturMsg> HtmlToPdfToLocal(PdfRequet pdf);
    }
}
