using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AppSaresp_2024.Models
{
    public class ProfessorAplicador
    {
        [Display(Name = "Código do Professor")]
        public int IdProfessorAplicador { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(11, ErrorMessage = "Insira apenas 10 digitos!")]
        public int CPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo RG é obrigatório!")]
        [StringLength(9, ErrorMessage = "Insira apenas 9 digitos!")]
        public int RG { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [StringLength(12, ErrorMessage = "Insira apenas 12 digitos!")]
        public BigInteger Telefone { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email não é valido.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email valido...")]
        public string Email { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.DateTime)]
        public DateTime DataNasc { get; set; }
    }
}
