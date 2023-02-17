using Xenopedia.Entities.DTO.Text;

namespace Xenopedia.Business.TextService
{
    public class TextService : ITextService
    {
        public Task<IEnumerable<TextDTO>> GetAllText()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TextDTO>> GetTextById(long idText)
        {
            IEnumerable<TextDTO> textDTOs = null;

            return (Task<IEnumerable<TextDTO>>)(textDTOs ?? new List<TextDTO>());
        }
    }
}
