using System.ComponentModel.DataAnnotations;

namespace APIVenda_BD.Models
{
    public class User
    {
        [Key]
        public string Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
