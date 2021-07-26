using System;
using System.ComponentModel.DataAnnotations;

namespace API_AlexandrePradoRomeu.InputModel
{
    public class CadastroUserModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe o CPF")]
        public string Cpf {get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email {get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Informe o telefone")]
        public string Telefone {get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Informe o sexo")]
        public string Sexo {get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime Dt_Nasc { get; set; }
    }
}
