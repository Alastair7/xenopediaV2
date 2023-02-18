using Newtonsoft.Json;

namespace Xenopedia.Entities.DTO.Text
{
    public class TextDTO
    {
        [JsonProperty("idText")]
        public long IdText { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
