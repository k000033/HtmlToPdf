using HtmlToPdfApi.DTO;
using HtmlToPdfApi.InterFace.HtmlToPdf;
using Microsoft.AspNetCore.Mvc;

namespace HtmlToPdfApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HtmlToPdfController : Controller
    {

        private readonly IHtmlToPdfService _htmlToPdfService;

        public HtmlToPdfController(IHtmlToPdfService htmlToPdfService)
        {
            _htmlToPdfService = htmlToPdfService;
        }
        

        [HttpPost]
        public IActionResult htmlToPdfToWeb([FromBody] PdfRequet pdfRequet)
        {
            byte [] fileByte =   _htmlToPdfService.HtmlToPdfToWeb(pdfRequet);

            return File(fileByte, "application/pdf", "generated.pdf");
        }

        [HttpPost]
        public async Task<IActionResult> htmlToPdfToLocal([FromBody] PdfRequet pdfRequet)
        {
            ReturMsg returMsg = await _htmlToPdfService.HtmlToPdfToLocal(pdfRequet);

            return Ok(returMsg);
        }
    }
}
