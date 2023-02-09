namespace Xenopedia.Entities.Entity.User
{
    public class UserEntity
    {
        public int IdUser { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}
