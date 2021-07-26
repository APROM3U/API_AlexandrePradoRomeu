using System;

namespace API_AlexandrePradoRomeu.ViewModel
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime Dt_nasc { get; set; }
       
    }
}
