using Xenopedia.Entities.Entity.Text;

namespace Xenopedia.Infrastructure.Text
{
    public class TextRepository : ITextRepository
    {
        public Task<TextEntity> GetTextById(long idText)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertText(TextEntity text)
        {
            throw new NotImplementedException();
        }
    }
}
