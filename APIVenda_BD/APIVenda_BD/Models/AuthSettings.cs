namespace APIVenda_BD.Models
{
    public class AuthSettings
    {
        public string Secret { get; set; }
        public int ExpireIn { get; set; }
        public int ExpireOut { get; set;}

    }
}
