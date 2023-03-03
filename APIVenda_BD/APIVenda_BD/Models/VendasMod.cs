using System.ComponentModel.DataAnnotations;

namespace APIVenda_BD.Models
{
    public class VendasMod
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Campo Data deve ter ao menos 10 caracteres")]
        public String Data { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [StringLength(13, MinimumLength = 3, ErrorMessage = "Campo Valor deve ter ao menos 3 caracteres")]
        public String Valor { get; set; }


    }
}
