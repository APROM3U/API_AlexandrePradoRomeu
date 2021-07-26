/* Utilizado SQL Server para criação da estrutura da tabela */

create table tbl_cadastro (
	 id			int primary key identity
	,nome		varchar(150)	not null
	,cpf		varchar(11)		not null
	,email		varchar(100)	not null
	,telefone	varchar(11)		not null
	,sexo		varchar(9)		not null
	,dt_nasc	datetime		not null
)

--select id, nome, cpf, email, telefone, sexo, dt_nasc from tbl_cadastro
