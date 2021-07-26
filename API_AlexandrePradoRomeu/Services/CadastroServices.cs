using API_AlexandrePradoRomeu.Entities;
using API_AlexandrePradoRomeu.Exceptions;
using API_AlexandrePradoRomeu.ViewModel;
using API_AlexandrePradoRomeu.Repositories;
using System.Threading.Tasks;
using API_AlexandrePradoRomeu.InputModel;
using System.Collections.Generic;
using System;
using System.Linq;

namespace API_AlexandrePradoRomeu.Services
{
    public class CadastroServices : ICadastroServices
    {
        private readonly ICadRepository _cadRepository;

        public CadastroServices(ICadRepository cadRepository)
        {
            _cadRepository = cadRepository;
        }

        public async Task<UsuarioModel> Obter(Guid id)
        {
            var cadastro = await _cadRepository.Obter(id);

            if (cadastro == null) return null;

            return new UsuarioModel
            {
                Id = cadastro.Id,
                Nome = cadastro.Nome,
                Cpf = cadastro.Cpf,
                Email = cadastro.Email,
                Telefone = cadastro.Telefone,
                Sexo = cadastro.Sexo,
                Dt_nasc = cadastro.Dt_nasc
            };
        }

        public async Task<List<UsuarioModel>> Obter(int pag, int qtdd)
        {
            var registros = await _cadRepository.Obter(pag, qtdd);

            return registros.Select(registro => new UsuarioModel
            {
                Id = registro.Id,
                Nome = registro.Nome,
                Cpf = registro.Cpf,
                Email = registro.Email,
                Telefone = registro.Telefone,
                Sexo = registro.Sexo,
                Dt_nasc = registro.Dt_nasc
            }).ToList();
        }
        
        public async Task<UsuarioModel> Inserir(CadastroUserModel usuario)
        {

            var cadastro = new Cadastro
            {
                Id = Guid.NewGuid(),
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Sexo = usuario.Sexo,
                Dt_nasc = usuario.Dt_Nasc
            };

            await _cadRepository.Inserir(cadastro);

            return new UsuarioModel
            {
                Id = cadastro.Id,
                Nome = cadastro.Nome,
                Cpf = cadastro.Cpf,
                Email = cadastro.Email,
                Telefone = cadastro.Telefone,
                Sexo = cadastro.Sexo,
                Dt_nasc = cadastro.Dt_nasc,
            };
        }

        public async Task Atualizar(Guid id, CadastroUserModel usuario)
        {
            var entidade = await _cadRepository.Obter(id);

            if (entidade == null)
                throw new UserNaoCadException();

            entidade.Nome = usuario.Nome;
            entidade.Cpf = usuario.Cpf;
            entidade.Email = usuario.Email;
            entidade.Telefone = usuario.Telefone;
            entidade.Sexo = usuario.Sexo;
            entidade.Dt_nasc = usuario.Dt_Nasc;

            await _cadRepository.Atualizar(entidade);
        }

        public async Task Remover(Guid id)
        {
            var cadastro = await _cadRepository.Obter(id);

            if (cadastro == null)
                throw new UserNaoCadException();

            await _cadRepository.Remover(id);
        }

        public void Dispose()
        {
            _cadRepository?.Dispose();
        }

    }
}
