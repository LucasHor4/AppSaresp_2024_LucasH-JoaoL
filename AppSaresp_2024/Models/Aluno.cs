using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AppSaresp_2024.Models
{
    public class Aluno
    {
        [Display(Name = "Código do Aluno")]
        public int IdAluno { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email não é valido.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email valido...")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        public BigInteger Telefone { get; set; }

        [Display(Name = "Serie")]
        [Required(ErrorMessage = "O campo serie é obrigatório!")]
        [StringLength(200, ErrorMessage = "Insira no máximo 200 digitos!")]
        public string Serie { get; set; }

        [Display(Name = "Turma")]
        [Required(ErrorMessage = "O campo turma é obrigatório!")]
        [StringLength(50, ErrorMessage = "Insira no máximo 50 digitos!")]
        public string Turma { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.DateTime)]
        public DateTime DataNasc { get; set; }
    }
}
