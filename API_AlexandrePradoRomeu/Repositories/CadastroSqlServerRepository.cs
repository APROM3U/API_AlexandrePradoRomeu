using API_AlexandrePradoRomeu.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace API_AlexandrePradoRomeu.Repositories
{
    public class CadastroSqlServerRepository : ICadRepository
    {
        private readonly SqlConnection sqlConnection;

        public CadastroSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Cadastro>> Obter(int pagina, int quantidade)
        {
            var registros = new List<Cadastro>();

            var comando = $"select id, nome, cpf, email, telefone, sexo, dt_nasc " +
                          $"from tbl_cadastro order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} rows only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                registros.Add(new Cadastro
                {
                    Id = (Guid)sqlDataReader["id"],
                    Nome = (string)sqlDataReader["nome"],
                    Cpf = (string)sqlDataReader["cpf"],
                    Email = (string)sqlDataReader["email"],
                    Telefone = (string)sqlDataReader["telefone"],
                    Sexo = (string)sqlDataReader["sexo"],
                    Dt_nasc = (DateTime)sqlDataReader["dt_nasc"]
                });
            }

            await sqlConnection.CloseAsync();

            return registros;
        }

        public async Task<Cadastro> Obter(Guid id)
        {
            Cadastro cadastro = null;

            var comando = $"select id, nome, cpf, email, telefone, sexo, dt_nasc " +
                          $"from tbl_cadastro where id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                cadastro = new Cadastro
                {
                    Id = (Guid)sqlDataReader["id"],
                    Nome = (string)sqlDataReader["nome"],
                    Cpf = (string)sqlDataReader["cpf"],
                    Email = (string)sqlDataReader["email"],
                    Telefone = (string)sqlDataReader["telefone"],
                    Sexo = (string)sqlDataReader["sexo"],
                    Dt_nasc = (DateTime)sqlDataReader["dt_nasc"]
                };
            }

            await sqlConnection.CloseAsync();

            return cadastro;
        }

        public async Task Inserir(Cadastro cadastro)
        {
            var comando = $"insert tbl_cadastro (id, nome, cpf, email, telefone, sexo, dt_nasc) " +
                          $"values ('{cadastro.Id}', '{cadastro.Nome}', '{cadastro.Cpf}', {cadastro.Email}, {cadastro.Telefone}, {cadastro.Sexo}, {cadastro.Dt_nasc})";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Atualizar(Cadastro cadastro)
        {
            var comando = $"update tbl_cadastro set " +
                          $"nome = '{cadastro.Nome}', " +
                          $"cpf = '{cadastro.Cpf}', " +
                          $"email = '{cadastro.Email}', " +
                          $"telefone = '{cadastro.Telefone}', " +
                          $"sexo = '{cadastro.Sexo}', " +
                          $"dt_nasc = '{cadastro.Dt_nasc}', " +
                          $"where id = '{cadastro.Id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id)
        {
            var comando = $"delete from tbl_cadastro where id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }

    }
}
