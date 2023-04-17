using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xenopedia.Business.TextService;
using Xenopedia.Commons.Enums;
using Xenopedia.Entities.DTO.Text;

namespace Xenopedia.Service.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TextController : ControllerBase
    {
        private readonly ITextService textService;

        public TextController(ITextService textService) 
        {
            this.textService = textService;
        }

        [HttpGet("GetTextById")]
        public async Task<TextDTO> GetTextById([FromQuery]long idText)
        {
            TextDTO textDTO = await textService.GetTextById(idText);
            
            return textDTO;
        }

        [HttpGet("GetTextAll")]
        public async Task<ActionResult<TextDTO>> GetTextAll()
        {
            IEnumerable<TextDTO> textAll = await textService.GetAllText();

            if (textAll == null || !textAll.Any()) 
            {
                return (textAll == null) switch
                {
                    true => new BadRequestResult(),
                    _ => Ok(new List<TextDTO>()),
                };
            }

            return Ok(textAll);
        }

        [HttpPost("NewText")]
        public async Task<ActionResult<TextBaseResponseDTO>> NewText([FromBody] NewTextRequestDTO newTextRequest)
        {
            TextBaseResponseDTO result;

            result = await textService.AddNewText(newTextRequest);

            return result.Result switch
            {
                TextResultCodes.ERROR => BadRequest(result),
                TextResultCodes.SUCCESS => Ok(result),
                _ => new BadRequestResult(),
            };
        }

        [HttpDelete("DeleteText")]
        public async Task<ActionResult<TextBaseResponseDTO>> DeleteText([FromQuery] long idText)
        {
            TextBaseResponseDTO result;

            result = await textService.DeleteText(idText);

            return result.Result switch
            {
                TextResultCodes.ERROR => BadRequest(result),
                TextResultCodes.SUCCESS => Ok(result),
                _ => new BadRequestResult(),
            };
        }
    }
}
