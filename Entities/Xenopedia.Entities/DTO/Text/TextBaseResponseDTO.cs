using Xenopedia.Commons.Enums;

namespace Xenopedia.Entities.DTO.Text
{
    public class TextBaseResponseDTO
    {
        public TextResultCodes Result { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
