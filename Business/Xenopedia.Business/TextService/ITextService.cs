using Xenopedia.Entities.DTO.Text;

namespace Xenopedia.Business.TextService
{
    public interface ITextService
    {
        Task<IEnumerable<TextDTO>> GetAllText();

        Task<TextDTO> GetTextById(long idText);

        Task<TextBaseResponseDTO> AddNewText(NewTextRequestDTO newText);
    }
}
