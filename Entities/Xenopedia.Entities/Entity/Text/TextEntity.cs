namespace Xenopedia.Entities.Entity.Text
{
    public class TextEntity
    {
        public long IdText { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public int CreatedBy { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
