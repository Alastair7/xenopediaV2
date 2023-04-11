using AutoMapper;
using Xenopedia.Entities.DTO.Text;
using Xenopedia.Entities.Entity.Text;

namespace Xenopedia.Business.Mapper
{
    public class TextMapper : ITextMapper
    {
        private readonly IMapper mapper;

        public TextMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TextEntity NewTextRequestToTextEntity(NewTextRequestDTO newText)
        {
            var result = mapper.Map<NewTextRequestDTO, TextEntity>(newText);

            return result;
        }

        public TextDTO TextEntityToTextDto(TextEntity textEntity)
        {
           var result = mapper.Map<TextEntity, TextDTO>(textEntity);

            return result;
        }

    }
}
