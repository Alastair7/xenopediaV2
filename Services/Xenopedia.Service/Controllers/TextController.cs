using Microsoft.AspNetCore.Mvc;
using Xenopedia.Business.TextService;
using Xenopedia.Entities.DTO.Text;

namespace Xenopedia.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : ControllerBase
    {
        private readonly ITextService textService;

        public TextController(ITextService textService) 
        {
            this.textService = textService;
        }

        [HttpGet("GetTextById")]
        public async Task<IEnumerable<TextDTO>> GetTextById([FromQuery]long idText)
        {
            IEnumerable<TextDTO> textDTO = await textService.GetTextById(idText);
            
            return textDTO;
        }
    }
}
