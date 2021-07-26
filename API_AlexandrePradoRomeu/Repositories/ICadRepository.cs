using API_AlexandrePradoRomeu.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_AlexandrePradoRomeu.Repositories
{
    public interface ICadRepository : IDisposable
    {
        Task<Cadastro> Obter(Guid id);
        Task<List<Cadastro>> Obter(int pag, int qtdd);
        Task Inserir(Cadastro cadastro);
        Task Atualizar(Cadastro cadastro);
        Task Remover(Guid id);
    }
}
