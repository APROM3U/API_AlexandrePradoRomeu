using System;

namespace API_AlexandrePradoRomeu.Exceptions
{
    public class UserNaoCadException : Exception
    {
        public UserNaoCadException()
        : base("Este usuário não encontrado")
        { }
    }
}
