using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AsianFlix.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        private DateTime DtCadastro { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome não pode estar em branco")]
        public string? ClienteName { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "CPF")]
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF Inválido")]
        public string? Cpf { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public string? FormaPagamento { get; set; }

        public string? Email { get; set; }
        private string? Status { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha a Senha")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres")]
        public string? Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As senha não conferem")]
        public string? PasswordConfirmation { get; set;}


    }
}
