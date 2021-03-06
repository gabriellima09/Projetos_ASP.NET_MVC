USE [teste_aspnet]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 22/10/2018 01:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoPessoa] [int] NULL,
	[Nome] [varchar](50) NULL,
	[Sobrenome] [varchar](15) NULL,
	[CPF] [varchar](14) NULL,
	[DataNascimento] [date] NULL,
	[NomeFantasia] [varchar](50) NULL,
	[RazaoSocial] [varchar](50) NULL,
	[CNPJ] [varchar](18) NULL,
	[DataCadastro] [smalldatetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 22/10/2018 01:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[IdCliente] [int] NOT NULL,
	[Bairro] [varchar](50) NULL,
	[CEP] [varchar](8) NULL,
	[Cidade] [varchar](50) NULL,
	[Complemento] [varchar](50) NULL,
	[Logradouro] [varchar](50) NULL,
	[Numero] [int] NULL,
	[UF] [int] NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[SP_CLIENTE_DELETE]    Script Date: 22/10/2018 01:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CLIENTE_DELETE]
(
	@Id		int
)
AS
BEGIN
	DELETE FROM Cliente where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CLIENTE_INSERT]    Script Date: 22/10/2018 01:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

truncate table cliente
truncate table endereco

delete from cliente where id = 3

select * from cliente
select * from endereco

SP_CLIENTE_INSERT 1, 'Teste', 'tester', '123.456.789-00', '1999-06-09', null, null, null, 'teste', 'teste', 'teste', 'teste', 'teste', 123, 26
SP_CLIENTE_INSERT 2, null, null, null, null, 'teste2', 'tester', '76.717.468/0001-63', 'teste', 'teste', 'teste', 'teste', 'teste', 456, 27

*/
CREATE PROCEDURE [dbo].[SP_CLIENTE_INSERT](
@TipoPessoa			int = 0

,@Nome			    varchar(50) = ''
,@Sobrenome		    varchar(15) = ''
,@CPF			    varchar(14) = ''
,@DataNascimento    date = ''

,@NomeFantasia		varchar(50) = ''
,@RazaoSocial		varchar(50) = ''
,@CNPJ				varchar(18) = ''

,@Bairro			varchar(50) = ''
,@CEP				varchar(8) = ''
,@Cidade			varchar(50) = ''
,@Complemento		varchar(50) = ''
,@Logradouro		varchar(50) = ''
,@Numero			int = 0
,@UF				int = 0
)
AS
BEGIN
	BEGIN TRAN

		insert into Cliente
		(
			TipoPessoa
			,Nome
			,Sobrenome
			,CPF
			,DataNascimento
			,NomeFantasia
			,RazaoSocial
			,CNPJ
			,DataCadastro
		)
		values
		(
			 @TipoPessoa
			,@Nome
			,@Sobrenome
			,@CPF
			,@DataNascimento
			,@NomeFantasia
			,@RazaoSocial
			,@CNPJ
			,getdate()
		)

		insert into Endereco
		(
			IdCliente
			,Bairro
			,CEP
			,Cidade
			,Complemento
			,Logradouro
			,Numero
			,UF
		)
		values
		(
			@@IDENTITY
			,@Bairro
			,@CEP
			,@Cidade
			,@Complemento
			,@Logradouro
			,@Numero
			,@UF
		)

	if @@error <> 0
		ROLLBACK

	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CLIENTE_SELECT]    Script Date: 22/10/2018 01:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CLIENTE_SELECT]
AS
BEGIN
	SELECT 
	Id
	,TipoPessoa
	,isnull(Nome, '')Nome
	,isnull(Sobrenome, '')Sobrenome
	,isnull(CPF, '')CPF
	,DataNascimento
	,isnull(NomeFantasia, '')NomeFantasia
	,isnull(RazaoSocial, '')RazaoSocial
	,isnull(CNPJ, '')CNPJ
	,DataCadastro

	,Bairro
	,CEP
	,Cidade
	,isnull(Complemento, '')Complemento
	,Logradouro
	,Numero
	,UF
	FROM Cliente c

	INNER JOIN Endereco e
		on e.IdCliente = c.Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CLIENTE_SELECT_BY_ID]    Script Date: 22/10/2018 01:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CLIENTE_SELECT_BY_ID]
(
	@Id		int
)
AS
BEGIN
	SELECT 
	Id
	,TipoPessoa
	,isnull(Nome, '')Nome
	,isnull(Sobrenome, '')Sobrenome
	,isnull(CPF, '')CPF
	,DataNascimento
	,isnull(NomeFantasia, '')NomeFantasia
	,isnull(RazaoSocial, '')RazaoSocial
	,isnull(CNPJ, '')CNPJ
	,DataCadastro

	,Bairro
	,CEP
	,Cidade
	,isnull(Complemento, '')Complemento
	,Logradouro
	,Numero
	,UF
	FROM Cliente c

	INNER JOIN Endereco e
		on e.IdCliente = c.Id

	WHERE c.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CLIENTE_UPDATE]    Script Date: 22/10/2018 01:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

truncate table cliente
truncate table endereco

delete from cliente where id = 3

select * from cliente
select * from endereco

SP_CLIENTE_UPDATE 4, 1, 'Teste', 'tester', '123.456.789-00', '1999-06-09', null, null, null, 'teste', 'teste', 'teste', 'teste', 'teste', 123, 26
SP_CLIENTE_UPDATE 2, 2, null, null, null, null, 'teste2', 'tester', '76.717.468/0001-63', 'teste', 'teste', 'teste', 'teste', 'teste', 456, 27

*/
create PROCEDURE [dbo].[SP_CLIENTE_UPDATE](
@Id					int = 0
,@TipoPessoa		int = 0

,@Nome			    varchar(50) = ''
,@Sobrenome		    varchar(15) = ''
,@CPF			    varchar(14) = ''
,@DataNascimento    date = ''

,@NomeFantasia		varchar(50) = ''
,@RazaoSocial		varchar(50) = ''
,@CNPJ				varchar(18) = ''

,@Bairro			varchar(50) = ''
,@CEP				varchar(8) = ''
,@Cidade			varchar(50) = ''
,@Complemento		varchar(50) = ''
,@Logradouro		varchar(50) = ''
,@Numero			int = 0
,@UF				int = 0
)
AS
BEGIN
	BEGIN TRAN

	IF @TipoPessoa = 1
	begin
		update Cliente
		set
			TipoPessoa		= @TipoPessoa
			,Nome			= @Nome
			,Sobrenome		= @Sobrenome
			,CPF			= @CPF
			,DataNascimento	= @DataNascimento
		where Id = @Id
	end
	ELSE IF @TipoPessoa = 2
	begin
		update Cliente
			set
				TipoPessoa		= @TipoPessoa
				,NomeFantasia	= @NomeFantasia
				,RazaoSocial	= @RazaoSocial
				,CNPJ			= @CNPJ
			where Id = @Id
	end

	update Endereco
	set
		Bairro			= @Bairro
		,CEP			= @CEP
		,Cidade			= @Cidade
		,Complemento	= @Complemento
		,Logradouro		= @Logradouro
		,Numero			= @Numero
		,UF				= @UF
	where IdCliente = @Id

	if @@error <> 0
		ROLLBACK

	COMMIT
END
GO
