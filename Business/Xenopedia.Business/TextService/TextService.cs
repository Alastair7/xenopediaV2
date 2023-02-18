using Xenopedia.Business.Mapper;
using Xenopedia.Entities.DTO.Text;
using Xenopedia.Entities.Entity.Text;
using Xenopedia.Infrastructure.Text;

namespace Xenopedia.Business.TextService
{
    public class TextService : ITextService
    {
        private readonly ITextRepository textRepository;
        private readonly ITextMapper textMapper;

        public TextService(ITextRepository textRepository, ITextMapper textMapper) 
        {
            this.textRepository = textRepository;
            this.textMapper = textMapper;
        }
        public Task<IEnumerable<TextDTO>> GetAllText()
        {
            throw new NotImplementedException();
        }

        public async Task<TextDTO> GetTextById(long idText)
        {
            TextEntity textEntity =  await textRepository.GetTextById(idText);
            
            var result = textMapper.TextEntityToTextDto(textEntity);

            return result;
        }
    }
}
