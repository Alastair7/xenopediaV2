using Xenopedia.Entities.DTO.Text;

namespace Xenopedia.Business.TextService
{
    public interface ITextService
    {
        Task<IEnumerable<TextDTO>> GetAllText();
    }
}
