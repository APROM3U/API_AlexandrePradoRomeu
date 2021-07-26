using API_AlexandrePradoRomeu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_AlexandrePradoRomeu.Repositories
{
    public class CadRepository : ICadRepository
    {

        private static Dictionary<Guid, Cadastro> cadastro = new Dictionary<Guid, Cadastro>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Cadastro{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Ana", Cpf = "12345678901", Email = "email@email.com", Telefone = "1144445555", Sexo = "Feminino", Dt_nasc = DateTime.Now} },
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fa56"), new Cadastro{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fa56"), Nome = "João", Cpf = "012345678910", Email = "e-mail@mail.com", Telefone = "1199995556", Sexo = "Masculino", Dt_nasc = DateTime.Now} },
        };


        public Task Inserir(Cadastro user)
        {
            cadastro.Add(user.Id, user);
            return Task.CompletedTask;
        }

        public Task<Cadastro> Obter(Guid id)
        {
            if (!cadastro.ContainsKey(id))
                return Task.FromResult<Cadastro>(null);

            return Task.FromResult(cadastro[id]);
        }

        public Task<List<Cadastro>> Obter(int pag, int qtdd)
        {
            return Task.FromResult(cadastro.Values.Skip((pag - 1) * qtdd).Take(qtdd).ToList());
        }

        public Task<List<Cadastro>> Obter(int id, string nome, string cpf, string email, string telefone, char sexo, DateTime dt_nasc)
        {
            return Task.FromResult(cadastro.Values.Where(cad => cad.Id.Equals(id) && cad.Nome.Equals(nome) && cad.Cpf.Equals(cpf) && cad.Email.Equals(email) && cad.Telefone.Equals(telefone) && cad.Sexo.Equals(sexo) && cad.Dt_nasc.Equals(dt_nasc)).ToList());
        }

        public Task Atualizar(Cadastro cad)
        {
            cadastro[cad.Id] = cad;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            cadastro.Remove(id);
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            //Fechar conexão com o banco
        }

    }
}
