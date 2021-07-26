using API_AlexandrePradoRomeu.InputModel;
using API_AlexandrePradoRomeu.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_AlexandrePradoRomeu.Services
{
    public interface ICadastroServices
    {
        Task<List<UsuarioModel>> Obter(int pag, int qtdd);
        Task<UsuarioModel> Obter(Guid id);
        Task<UsuarioModel> Inserir(CadastroUserModel cadastro);
        Task Atualizar(Guid id, CadastroUserModel cadastro);
        Task Remover(Guid id);
    }
}
