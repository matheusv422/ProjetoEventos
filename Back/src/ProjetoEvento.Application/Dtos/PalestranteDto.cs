using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEvento.Application.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Nome { get; set; }
       
        public string MiniCurriculo { get; set; }
        
       
       
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", 
        ErrorMessage = "Não é um formato de imagem válido (gif, jpg, jpeg, bmp ou png")
        ]
        public string ImagemURL { get; set; }
      
      
        [Required(ErrorMessage ="O campo {0} é obrigatório")] 
        [Phone(ErrorMessage="O campo {0} contém um telefone inválido")] 
        public string Telefone { get; set; }
        
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [Display(Name ="e-mail")]
        [EmailAddress(ErrorMessage = "É necessário que o {0} seja válido")]
        public string Email { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}