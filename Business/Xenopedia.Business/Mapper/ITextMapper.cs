using Xenopedia.Entities.DTO.Text;
using Xenopedia.Entities.Entity.Text;

namespace Xenopedia.Business.Mapper
{
    public interface ITextMapper
    {
        TextDTO TextEntityToTextDto(TextEntity textEntity);
        TextEntity NewTextRequestToTextEntity(NewTextRequestDTO newText);
    }
}
