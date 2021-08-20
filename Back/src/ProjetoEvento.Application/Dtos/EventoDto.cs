using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEvento.Application.Dtos
{
    public class EventoDto
    {
         public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3, 
        ErrorMessage ="O campo {0} deve conter entre 3 a 50 caracteres")]
        public string Tema { get; set; }


        [Display(Name = "Quantidade de Pessoas")]
        [Range(1, 120000, 
        ErrorMessage ="{0} não pode ser menor que 1 e maior que 120.000")]
        public int QtdPessoas { get; set; }


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


        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }


    }
}