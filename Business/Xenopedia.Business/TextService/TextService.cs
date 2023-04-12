using Xenopedia.Business.Mapper;
using Xenopedia.Commons.Enums;
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
        public async Task<IEnumerable<TextDTO>> GetAllText()
        {
            IEnumerable<TextEntity> getTextAllEntities = await textRepository.GetAllText();

            IEnumerable<TextDTO> getTextAllDto = getTextAllEntities
                .Select(x => textMapper.TextEntityToTextDto(x));

            return getTextAllDto;

        }

        public async Task<TextDTO> GetTextById(long idText)
        {
            TextEntity textEntity =  await textRepository.GetTextById(idText);
            
            var result = textMapper.TextEntityToTextDto(textEntity);

            return result;
        }

        public async Task<TextBaseResponseDTO> AddNewText(NewTextRequestDTO newText)
        {
            TextEntity textToInsert = textMapper.NewTextRequestToTextEntity(newText);

            bool inserted = await textRepository.InsertText(textToInsert);

            if (!inserted)
            {
                return new TextBaseResponseDTO { Result = TextResultCodes.ERROR, Message = "Error when adding text" };
            }

            return new TextBaseResponseDTO { Result = TextResultCodes.SUCCESS, Message = "SUCCESS" };
        }
    }
}
