-- comando para criar o database db_lojaEcommerce
create database db_lojaEcommerce default charset utf8 default collate utf8_general_ci;

-- comando para usar o database db_lojaEcommerce
use db_lojaEcommerce;

-- comando para excluir o database db_lojaEcommerce
drop database db_lojaEcommerce;

-- criação das tabelas

-- tabela pagamento
create table tbl_pagamento(
	cd_pagamento int primary key auto_increment not null,
    nm_pagamento varchar(8) not null
) default charset utf8;

insert into tbl_pagamento (nm_pagamento) values ('Débito');
insert into tbl_pagamento (nm_pagamento) values ('Crédito');
insert into tbl_pagamento (nm_pagamento) values ('Boleto');

-- tabela genero
create table tbl_genero(
	cd_genero int primary key auto_increment not null,
    nm_genero varchar(9) not null
)default charset utf8;

insert into tbl_genero (nm_genero) values ('Masculino');
insert into tbl_genero (nm_genero) values ('Feminino');

-- tabela categoria
create table tbl_categoria(
	cd_categoria int primary key auto_increment not null,
    nm_categoria varchar(50) not null
)default charset utf8;

create table tbl_statusProduto(
	cd_status int primary key auto_increment not null,
    nm_status varchar(11) not null
)default charset utf8;

insert into tbl_statusProduto (nm_status) values ('Lançamentos');
insert into tbl_statusProduto (nm_status) values ('Ofertas');
insert into tbl_statusProduto (nm_status) values ('Premium');
insert into tbl_statusProduto (nm_status) values ('Destaques');
insert into tbl_statusProduto (nm_status) values ('Normal');

-- tabela funcionario
create table tbl_funcionario(
	cd_funcionario int primary key auto_increment not null,
    nm_funcionario varchar(50) not null,
    ida_funcionario varchar(14) not null,
    cpf_funcionario varchar(14) not null,
    cd_genero int not null,
    cel_funcionario varchar(15) not null,
    eml_funcionario varchar(50) not null,
    sh_funcionario varchar(15) not null,
    img_funcionario varchar(255) not null,
    cep_funcionario varchar(9) not null,
    tp_funcionario varchar(11) not null,
    foreign key (cd_genero) references tbl_genero(cd_genero)
) default charset utf8;

insert into tbl_funcionario(nm_funcionario, ida_funcionario, cpf_funcionario, cd_genero, cel_funcionario, eml_funcionario, sh_funcionario, img_funcionario, cep_funcionario, tp_funcionario) values('Matheus Santos de Abreu', '18', '310.694.059-55', '1', '(11) 98473-1198', 'matheus@gmail.com', '12345', 'Imagem de Perfil', '08240-920', 'Funcionario');

-- tabela cliente
create table tbl_usuario(
	cd_usuario int primary key auto_increment not null,
    nm_usuario varchar(60) not null,
	cpf_usuario varchar(14) not null,
    cd_genero int not null,
    cel_usuario varchar(15) not null,
    eml_usuario varchar(50) not null,
    img_usuario varchar(255) null,
    cep_usuario varchar(9) not null,
	log_usuario varchar(70) not null,
    bar_usuario varchar(40) not null,
    cid_usuario varchar(20) not null,
	uf_usuario varchar(2) not null,
    sh_usuario varchar(15) not null,
    tp_usuario varchar(11) null,
    foreign key (cd_genero) references tbl_genero(cd_genero)
) default charset utf8;

insert into tbl_usuario(nm_usuario, cpf_usuario, cd_genero, cel_usuario, eml_usuario, img_usuario, cep_usuario, log_usuario, bar_usuario, cid_usuario, uf_usuario, sh_usuario, tp_usuario) values('Henrique Torrico Silva', '310.799.658.62', '1', '(11) 98628-1187', 'torrico@gmail.com', 'Imagem Perfil', '08240-590', 'R. Avenida Moises Maimonides', 'Vila Progresso', 'São Paulo', 'SP', '12345', 'Gerente');

-- tabela fornecedor
create table tbl_fornecedor(
	cd_fornecedor int primary key auto_increment not null,
    nm_fornecedor varchar(50) not null,
    tel_fornecedor varchar(14) not null,
    cnpj_fornecedor varchar(18) not null,
    cep_fornecedor varchar(9) not null,
    log_fornecedor varchar(70) not null,
    bar_fornecedor varchar(40) not null,
    cid_fornecedor varchar(20) not null,
	uf_fornecedor varchar(2) not null
) default charset utf8;
 
-- tabela produto
create table tbl_produto(
	cd_produto int primary key auto_increment not null,
    nm_produto varchar(120) not null,
    cd_fornecedor int not null,
	cd_categoria int not null,
	mar_produto varchar(20) not null,
	qt_produto int not null,
    vl_produto decimal(12,2) not null,
    img_produto varchar(255),
    ds_produto varchar(3000) not null,
    car_produto varchar(2000) not null,
    cd_status int not null,
    foreign key(cd_categoria) references tbl_categoria(cd_categoria),
    foreign key(cd_fornecedor) references tbl_fornecedor(cd_fornecedor),
    foreign key(cd_status) references tbl_statusProduto(cd_status)
) default charset utf8;

-- tabela comentarios do site
create table tbl_comentario(
	cd_comentario int primary key auto_increment not null,
    ds_comentario varchar(1000) not null,
    cd_usuario int not null,
    dt_comentario varchar(12) not null,
    foreign key(cd_usuario) references tbl_usuario(cd_usuario)
) default charset utf8;

-- tabela venda
create table tbl_venda(
	cd_venda int primary key auto_increment not null,
    cd_usuario int not null,
    dt_venda varchar(20) not null,
    hr_venda varchar(5) not null,
    vl_venda varchar(50) not null,
    foreign key (cd_usuario) references tbl_usuario (cd_usuario)
)default charset utf8;

-- tabela carrinho
create table tbl_carrinho(
    cd_carrinho int primary key auto_increment not null,
    cd_venda int not null,
    cd_produto int not null,
    qt_produto int not null,
    foreign key (cd_venda) references tbl_venda (cd_venda),
    foreign key (cd_produto) references tbl_produto (cd_produto)
)default charset utf8;

-- consultado as tabelas
select * from tbl_carrinho;
select * from tbl_categoria;
select * from tbl_comentario;
select * from tbl_fornecedor;
select * from tbl_funcionario;
select * from tbl_genero;
select * from tbl_pagamento;
select * from tbl_produto;
select * from tbl_statusProduto;
select * from tbl_usuario;
select * from tbl_venda;

-- excluindo as tabelas
drop table tbl_carrinho;
drop table tbl_categoria;
drop table tbl_comentario;
drop table tbl_fornecedor;
drop table tbl_funcionario;
drop table tbl_genero;
drop table tbl_pagamento;
drop table tbl_produto;
drop table tbl_statusProduto;
drop table tbl_venda;
drop table tbl_usuario;

-- criação de procedures

-- procedure de testar um usuario cadastrado no banco
delimiter //
	drop procedure if exists testarUsuario;
	create procedure testarUsuario(
		in vEmlUsuario varchar(40),
		in vShUsario varchar(15)
	) 
	begin
		select * from `tbl_usuario` where `eml_usuario` = vEmlUsuario and `sh_usuario` = vShUsario;
	end //
delimiter ;

-- procedure de testar um funcionario cadastrado no banco
delimiter //
	drop procedure if exists testarUsuarioFuncionario;
	create procedure testarUsuarioFuncionario(
		in vEmlFuncionario varchar(40),
		in vShFuncionario varchar(15)
	) 
	begin
		select * from `tbl_funcionario` where `eml_funcionario` = vEmlFuncionario and `sh_funcionario` = vShFuncionario;
	end //
delimiter ;

-- procedure de cadastrar uma categoria
delimiter //
	drop procedure if exists cadastrarCategoria;
    create procedure cadastrarCategoria(
		in vNmCategoria varchar(50)
    )
    begin
		insert into tbl_categoria(nm_categoria)
        values(vNmCategoria);
    end //
delimiter ;	

-- procedure de listar as categorias
delimiter //
	 drop procedure if exists listarCategoria;
     create procedure listarCategoria()
     begin
		select * from tbl_categoria;
     end //
delimiter ;

-- procedure de buscar uma categoria
delimiter //
	drop procedure if exists buscarCategoria;
	create procedure buscarCategoria(
		in busca varchar(50)
)
	begin
		select * from tbl_categoria
		where `nm_categoria` like concat('%',busca,'%') or
			`cd_categoria` like concat('%',busca,'%');
	end //
delimiter ;

-- procedure de excluir uma categoria
delimiter //
	 drop procedure if exists excluirCategoria;
     create procedure excluirCategoria(
		in vCdCategoria int
     )
     begin
		delete from tbl_categoria where cd_categoria = vCdCategoria;
     end //
delimiter ;

-- procedure de atualizar uma categoria
delimiter //
	drop procedure if exists atualizarCategoria;
    create procedure atualizarCategoria(
		in vCdCategoria int,
		in vNmCategoria varchar(50)
    )
    begin
		update tbl_categoria set nm_categoria = vNmCategoria where cd_categoria = vCdCategoria;
    end //
delimiter ;

-- procedure de cadastrar um fornecedor
delimiter //
	drop procedure if exists cadastrarFornecedor;
    create procedure cadastrarFornecedor(
		in vNmFornecedor varchar(50),
        in vTelFornecedor varchar(14),
        in vCnpjFornecedor varchar(18),
        in vCepFornecedor varchar(9),
        in vLogFornecedor varchar(70),
        in vBarFornecedor varchar(40),
        in vCidFornecedor varchar(20),
        in vUfFornecedor varchar(2)
    )
    begin
		insert into tbl_fornecedor(nm_fornecedor, tel_fornecedor, cnpj_fornecedor, cep_fornecedor, log_fornecedor, bar_fornecedor, cid_fornecedor, uf_fornecedor)
        values(vNmFornecedor, vTelFornecedor, vCnpjFornecedor, vCepFornecedor, vLogFornecedor, vBarFornecedor, vCidFornecedor, vUfFornecedor);
    end //
delimiter ;

-- procedure de listar os fornecedores
delimiter //
	 drop procedure if exists listarFornecedor;
     create procedure listarFornecedor()
     begin
		select * from tbl_fornecedor;
     end //
delimiter ;

-- procedure de buscar um fornecedor
delimiter //
	drop procedure if exists buscarFornecedor;
	create procedure buscarFornecedor(
		in busca varchar(50)
)
	begin
		select * from tbl_fornecedor
		where `nm_fornecedor` like concat('%',busca,'%') or
			`cd_fornecedor` like concat('%',busca,'%');
	end //
delimiter ;

-- procedure de excluir um fornecedor
delimiter //
	 drop procedure if exists excluirFornecedor;
     create procedure excluirFornecedor(
		in vCdFornecedor int
     )
     begin
		delete from tbl_fornecedor where cd_fornecedor = vCdFornecedor;
     end //
delimiter ;

-- procedure de atualizar um fornecedor
delimiter //
	drop procedure if exists atualizarFornecedor;
    create procedure atualizarFornecedor(
		in vCdFornecedor int,
		in vNmFornecedor varchar(50),
        in vTelFornecedor varchar(14),
        in vCnpjFornecedor varchar(18),
        in vCepFornecedor varchar(9),
        in vLogFornecedor varchar(70),
        in vBarFornecedor varchar(40),
        in vCidFornecedor varchar(20),
        in vUfFornecedor varchar(2)
    )
    begin
		update tbl_fornecedor set nm_fornecedor = vNmFornecedor, 
        tel_fornecedor = vTelFornecedor, 
        cnpj_fornecedor = vCnpjFornecedor, 
        cep_fornecedor = vCepFornecedor, 
        log_fornecedor = vLogFornecedor, 
        bar_fornecedor = vBarFornecedor,
        cid_fornecedor = vCidFornecedor,
        uf_fornecedor = vUfFornecedor where cd_fornecedor = vCdFornecedor;
    end //
delimiter ;

-- procedure de cadastrar um funcionario
delimiter //
	drop procedure if exists cadastrarFuncionario;
    create procedure cadastrarFuncionario(
		in vNmFuncionario varchar(50),
        in vIdaFuncionario varchar(2),
        in vCpfFuncionario varchar(14),
        in vCdGenero int,
        in vCelFuncionario varchar(15),
        in vEmlFuncionario varchar(50),
        in vShFuncionario varchar(15),
        in vImgFuncionario varchar(255),
        in vCepFuncionario varchar(9),
        in vTpFuncionario varchar(11)
    )
    begin
		insert into tbl_funcionario(nm_funcionario, ida_funcionario, cpf_funcionario, cd_genero, cel_funcionario, eml_funcionario, sh_funcionario, img_funcionario, cep_funcionario, tp_funcionario)
        values(vNmFuncionario, vIdaFuncionario, vCpfFuncionario, vCdGenero, vCelFuncionario, vEmlFuncionario, vShFuncionario, vImgFuncionario, vCepFuncionario, vTpFuncionario);
    end //
delimiter ;

-- procedure de listar os funcionarios
delimiter //
	 drop procedure if exists listarFuncionario;
     create procedure listarFuncionario()
     begin
		select * from viewFuncionario;
     end //
delimiter ;

-- procedure de buscar um funcionario
delimiter //
	drop procedure if exists buscarFuncionario;
	create procedure buscarFuncionario(
		in busca varchar(50)
)
	begin
		select * from tbl_funcionario
		where `nm_funcionario` like concat('%',busca,'%') or
			`cd_funcionario` like concat('%',busca,'%');
	end //
delimiter ;

-- procedure de excluir um funcionario
delimiter //
	 drop procedure if exists excluirFuncionario;
     create procedure excluirFuncionario(
		in vCdFuncionario int
     )
     begin
		delete from tbl_funcionario where cd_funcionario = vCdFuncionario;
     end //
delimiter ;

-- procedure de atualizar um funcionario
delimiter //
	drop procedure if exists atualizarFuncionario;
    create procedure atualizarFuncionario(
		in vCdFuncionario int,
		in vNmFuncionario varchar(50),
        in vIdaFuncionario varchar(2),
        in vCpfFuncionario varchar(14),
        in vCdGenero int,
        in vCelFuncionario varchar(15),
        in vEmlFuncionario varchar(50),
        in vShFuncionario varchar(15),
        in vImgFuncionario varchar(255),
        in vCepFuncionario varchar(9),
        in vTpFuncionario varchar(11)
    )
    begin
		update tbl_funcionario set nm_funcionario = vNmFuncionario, 
        ida_funcionario = vIdaFuncionario, 
        cpf_funcionario = vCpfFuncionario, 
        cd_genero = vCdGenero, 
        cel_funcionario = vCelFuncionario, 
        eml_funcionario = vEmlFuncionario,
        sh_funcionario = vShFuncionario,
        img_funcionario = vImgFuncionario,
        cep_funcionario = vCepFuncionario, 
        tp_funcionario = vTpFuncionario where cd_funcionario = vCdFuncionario;
    end //
delimiter ;

-- procedure de cadastrar um usuario
delimiter //
	drop procedure if exists cadastrarUsuario;
    create procedure cadastrarUsuario(
		in vNmUsuario varchar(50),
        in vCpfUsuario varchar(14),
        in vCdGenero int,
        in vCelUsuario varchar(15),
        in vEmlUsuario varchar(50),
        in vImgUsuario varchar(255),
        in vCepUsuario varchar(9),
        in vLogUsuario varchar(70),
        in vBarUsuario varchar(40),
        in vCidUsuario varchar(20),
        in vUfUsuario varchar(2),
        in vShUsuario varchar(15)
    )
    begin
		insert into tbl_usuario(nm_usuario, cpf_usuario, cd_genero, cel_usuario, eml_usuario, img_usuario, cep_usuario, log_usuario, bar_usuario, cid_usuario, uf_usuario, sh_usuario)
        values(vNmUsuario, vCpfUsuario, vCdGenero, vCelUsuario, vEmlUsuario, vImgUsuario, vCepUsuario, vLogUsuario, vBarUsuario, vCidUsuario, vUfUsuario, vShUsuario);
    end //
delimiter ;

-- procedure de listar os usuarios
delimiter //
	 drop procedure if exists listarUsuario;
     create procedure listarUsuario()
     begin
		select * from viewUsuario;
     end //
delimiter ;

-- procedure de buscar um usuario
delimiter //
	drop procedure if exists buscarUsuario;
	create procedure buscarUsuario(
		in busca varchar(50)
)
	begin
		select * from tbl_usuario
		where `cpf_usuario` like concat('%',busca,'%') or
			`cd_usuario` like concat('%',busca,'%');
	end //
delimiter ;

-- procedure de excluir um usuario
delimiter //
	 drop procedure if exists excluirUsuario;
     create procedure excluirUsuario(
		in vCdUsuario int
     )
     begin
		delete from tbl_usuario where cd_usuario = vCdUsuario;
     end //
delimiter ;

-- procedure de atualizar um usuario
delimiter //
	drop procedure if exists atualizarUsuario;
    create procedure atualizarUsuario(
		in vCdUsuario int,
		in vNmUsuario varchar(50),
        in vCpfUsuario varchar(14),
        in vCdGenero int,
        in vCelUsuario varchar(15),
        in vEmlUsuario varchar(50),
        in vImgUsuario varchar(255),
        in vCepUsuario varchar(9),
        in vLogUsuario varchar(70),
        in vBarUsuario varchar(40),
        in vCidUsuario varchar(20),
        in vUfUsuario varchar(2),
        in vShUsuario varchar(15)
    )
    begin
		update tbl_usuario set nm_usuario = vNmUsuario, 
        cpf_usuario = vCpfUsuario, 
        cd_genero = vCdGenero, 
        cel_usuario = vCelUsuario, 
        eml_usuario = vEmlUsuario,
        img_usuario = vImgUsuario,
        cep_usuario = vCepUsuario,
        log_usuario = vLogUsuario,
        bar_usuario = vBarUsuario,
        cid_usuario = vCidUsuario,
        uf_usuario = vUfUsuario,
        sh_usuario = vShUsuario where cd_usuario = vCdUsuario;
    end //
delimiter ;

-- procedure de cadastrar um produto
delimiter //
	drop procedure if exists cadastrarProduto;
    create procedure cadastrarProduto(
		in vNmProduto varchar(120),
        in vCdFornecedor int,
        in vCdCategoria int,
        in vMarProduto varchar(20),
        in vQtProduto int,
        in vVlProduto decimal(12,2),
        in vImgProduto varchar(255),
        in vDsProduto varchar(3000),
        in vCarProduto varchar(2000),
        in vCdStatus int
    )
    begin
		insert into tbl_produto(nm_produto, cd_fornecedor, cd_categoria, mar_produto, qt_produto, vl_produto, img_produto, ds_produto, car_produto, cd_status)
        values(vNmProduto, vCdFornecedor, vCdCategoria, vMarProduto, vQtProduto, vVlProduto, vImgProduto, vDsProduto, vCarProduto, vCdStatus);
    end //
delimiter ;

-- procedure de listar um produto
delimiter //
	 drop procedure if exists listarProduto;
     create procedure listarProduto()
     begin
		select * from viewProduto;
     end //
delimiter ;

-- procedure de listar produtos (Áudio e Tecnologia)
delimiter //
	 drop procedure if exists listarProdutoTecnologia;
     create procedure listarProdutoTecnologia()
     begin
		select * from viewProdutoTecnologia;
     end //
delimiter ;

-- procedure de listar produtos (Instrumentos de Corda)
delimiter //
	 drop procedure if exists listarProdutoCorda;
     create procedure listarProdutoCorda()
     begin
		select * from viewProdutoCorda;
     end //
delimiter ;

-- procedure de listar produtos (Bateria e Percussão)
delimiter //
	 drop procedure if exists listarProdutoPercussao;
     create procedure listarProdutoPercussao()
     begin
		select * from viewProdutoPercussao;
     end //
delimiter ;

-- procedure de listar produtos (Instrumentos de Teclas)
delimiter //
	 drop procedure if exists listarProdutoTeclas;
     create procedure listarProdutoTeclas()
     begin
		select * from viewProdutoTeclas;
     end //
delimiter ;

-- procedure de listar produtos (Arco e Sopro)
delimiter //
	 drop procedure if exists listarProdutoSopro;
     create procedure listarProdutoSopro()
     begin
		select * from viewProdutoSopro;
     end //
delimiter ;

-- procedure de listar produtos (Lançamentos)
delimiter //
	 drop procedure if exists listarProdutoLancamento;
     create procedure listarProdutoLancamento()
     begin
		select * from viewProdutoLancamento;
     end //
delimiter ;

-- procedure de listar produtos (Ofertas)
delimiter //
	 drop procedure if exists listarProdutoOfertas;
     create procedure listarProdutoOfertas()
     begin
		select * from viewProdutoOfertas;
     end //
delimiter ;

-- procedure de listar produtos (Premium)
delimiter //
	 drop procedure if exists listarProdutoPremium;
     create procedure listarProdutoPremium()
     begin
		select * from viewProdutoPremium;
     end //
delimiter ;

-- procedure de listar produtos (Destaques)
delimiter //
	 drop procedure if exists listarProdutoDestaque;
     create procedure listarProdutoDestaque()
     begin
		select * from viewProdutoDestaques;
     end //
delimiter ;

-- procedure de buscar um produto
delimiter //
	drop procedure if exists buscarProduto;
	create procedure buscarProduto(
		in busca varchar(50)
)
	begin
		select * from tbl_produto
		where `nm_produto` like concat('%',busca,'%') or
			`cd_produto` like concat('%',busca,'%');
	end //
delimiter ;

-- procedure de excluir um produto
delimiter //
	 drop procedure if exists excluirProduto;
     create procedure excluirProduto(
		in vCdProduto int
     )
     begin
		delete from tbl_produto where cd_produto = vCdProduto;
     end //
delimiter ;

-- procedure de atualizar um produto
delimiter //
	drop procedure if exists atualizarProduto;
    create procedure atualizarProduto(
		in vCdProduto int,
		in vNmProduto varchar(120),
        in vCdFornecedor int,
        in vCdCategoria int,
        in vMarProduto varchar(20),
        in vQtProduto int,
        in vVlProduto decimal(12,2),
        in vImgProduto varchar(255),
        in vDsProduto varchar(3000),
        in vCarProduto varchar(2000),
        in vCdStatus int
    )
    begin
		update tbl_produto set nm_produto = vNmProduto, 
        cd_fornecedor = vCdFornecedor, 
        cd_categoria = vCdCategoria, 
        mar_produto = vMarProduto, 
        qt_produto = vQtProduto,
        vl_produto = vVlProduto,
        img_produto = vImgProduto,
        ds_produto = vDsProduto,
        car_produto = vCarProduto,
        cd_status = vCdStatus where cd_produto = vCdProduto;
    end //
delimiter ;

-- procedure de cadastrar um comentario
delimiter //
	drop procedure if exists cadastrarComentario;
    create procedure cadastrarComentario(
		in vDsComentario varchar(1000),
        in vCdUsuario int,
        in vDtComentario varchar(12)
    )
    begin
		insert into tbl_comentario(ds_comentario, cd_usuario, dt_comentario)
        values(vDsComentario, vCdUsuario, vDtComentario);
    end //
delimiter ;

-- procedure de listar um comentario
delimiter //
	 drop procedure if exists listarComentario;
     create procedure listarComentario()
     begin
		select * from viewComentario;
     end //
delimiter ;

-- procedure de excluir um comentario
delimiter //
	 drop procedure if exists excluirComentario;
     create procedure excluirComentario(
		in vCdComentario int
     )
     begin
		delete from tbl_comentario where cd_comentario = vCdComentario;
     end //
delimiter ;

-- procedure de cadastrar um venda
delimiter //
	drop procedure if exists cadastrarVenda;
    create procedure cadastrarVenda(
		in vCdUsuario int,
        in vDtVenda varchar(20),
        in vHrVenda varchar(5),
        in vVlVenda varchar(50)
    )
    begin
		insert into tbl_venda(cd_usuario,  dt_venda, hr_venda, vl_venda)
        values(vCdUsuario, vDtVenda, vHrVenda, vVlVenda);
    end //
delimiter ;

-- procedure de listar uma venda
delimiter //
	 drop procedure if exists listarVenda;
     create procedure listarVenda()
     begin
		select * from viewVenda;
     end //
delimiter ;

-- procedure de listar o total de vendas da loja
delimiter //
	 drop procedure if exists listarVendasTotais;
     create procedure listarVendasTotais()
     begin
		select count(cd_venda) from tbl_venda;
     end //
delimiter ;

-- procedure de listas o total de usuarios cadastrados na loja
delimiter //
	 drop procedure if exists listarUsuarioTotais;
     create procedure listarUsuarioTotais()
     begin
		select count(cd_usuario) from tbl_usuario;
     end //
delimiter ;

-- procedure de listar o total de funcionarios cadastrados no sistema
delimiter //
	 drop procedure if exists listarFuncionariosTotais;
     create procedure listarFuncionariosTotais()
     begin
		select count(cd_funcionario) from tbl_funcionario;
     end //
delimiter ;

-- procedure de listar a soma total das vendas da loja
delimiter //
	 drop procedure if exists listarSomaVendas;
     create procedure listarSomaVendas()
     begin
		select sum(vl_venda) from tbl_venda;
     end //
delimiter ;

-- procedure de listar a quantidade de produtos no estoque do sistema
delimiter //
	 drop procedure if exists listarEstoque;
     create procedure listarEstoque()
     begin
		select sum(qt_produto) from tbl_produto;
     end //
delimiter ;

-- criação de triggers

-- trigger de baixa no estoque do produto
delimiter //
	drop trigger if exists tg_baixaEstoque;
	create trigger tg_baixaEstoque after insert
		on tbl_carrinho for each row 
	begin
		update tbl_produto
			set qt_produto = (qt_produto - new.qt_produto)
		where cd_produto = new.cd_produto;
	end //
delimiter ;

-- testando as procedures

-- procedures de cadastrar
call cadastrarCategoria();
call cadastrarComentario();
call cadastrarFornecedor();
call cadastrarFuncionario();
call cadastrarCliente();
call cadastrarProduto();
call cadastrarVenda();
call inserirItem();

-- procedures de listagem
call listarCategoria();
call listarComentario();
call listarFornecedor();
call listarFuncionario();
call listarUsuario();
call listarProduto();
call listarProdutoTecnologia();
call listarProdutoCorda();
call listarProdutoPercussao();
call listarProdutoTeclas();
call listarProdutoSopro();
call listarProdutoDestaque();
call listarProdutoLancamento();
call listarProdutoOfertas();
call listarProdutoPremium();
call listarVenda();
call listarVendasTotais();
call listarUsuarioTotais();
call listarFuncionariosTotais();
call listarSomaVendas();
call listarEstoque();

-- procedures de busca
call buscarCategoria();
call buscarFornecedor();
call buscarFuncionario();
call buscarProduto();
call buscarUsuario();

-- procedures de exclusão
call excluirCategoria();
call excluirComentario();
call excluirFornecedor();
call excluirFuncionario();
call excluirUsuario();
call excluirProduto();
call excluirVenda();

-- procedures de atualização
call atualizarCategoria();
call atualizarFornecedor();
call atualizarFuncionario();
call atualizarUsuario();
call atualizarProduto();

-- criação de views

-- view (funcionario, genero, status)
create view viewFuncionario
as select 
	tbl_funcionario.cd_funcionario,
    tbl_funcionario.nm_funcionario,
    tbl_funcionario.ida_funcionario,
    tbl_funcionario.cpf_funcionario,
	tbl_genero.nm_genero,
    tbl_funcionario.cel_funcionario,
    tbl_funcionario.eml_funcionario,
    tbl_funcionario.sh_funcionario,
    tbl_funcionario.cep_funcionario,
    tbl_funcionario.img_funcionario,
    tbl_funcionario.tp_funcionario
from tbl_funcionario inner join tbl_genero
	on tbl_funcionario.cd_genero = tbl_genero.cd_genero order by cd_funcionario;

-- view (usuario, genero, status)
create view viewUsuario
as select
	tbl_usuario.cd_usuario,
	tbl_usuario.nm_usuario,
	tbl_usuario.cpf_usuario,
	tbl_genero.nm_genero,
	tbl_usuario.cel_usuario,
	tbl_usuario.eml_usuario,
	tbl_usuario.img_usuario,
	tbl_usuario.cep_usuario,
	tbl_usuario.log_usuario,
	tbl_usuario.bar_usuario,
	tbl_usuario.cid_usuario,
	tbl_usuario.uf_usuario,
    tbl_usuario.sh_usuario
from tbl_usuario inner join tbl_genero
	on tbl_usuario.cd_genero = tbl_genero.cd_genero order by cd_usuario;
    
-- view (produto, fornecedor, categoria, status)
create view viewProduto
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status order by cd_produto;
    
-- view (Produtos (Áudio e Tecnologia))
create view viewProdutoTecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status 
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria where tbl_categoria.cd_categoria = '1' order by cd_produto;
    
-- view (Produtos (Instrumentos de Corda))
create view viewProdutoCorda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status 
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria where tbl_categoria.cd_categoria = '2' order by cd_produto;
    
-- view (Produtos (Bateria e Percussão))
create view viewProdutoPercussao
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status 
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria where tbl_categoria.cd_categoria = '3' order by cd_produto;
    
-- view (Produtos (Instrumentos de Teclas))
create view viewProdutoTeclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status 
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria where tbl_categoria.cd_categoria = '4' order by cd_produto;
    
-- view (Produtos (Arco e Sorpo))
create view viewProdutoSopro
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status 
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria where tbl_categoria.cd_categoria = '5' order by cd_produto;
    
-- view (Produtos (Lançamentos))
create view viewProdutoLancamento
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_statusProduto.cd_status = '1' order by cd_produto;
    
-- view (Produtos (Ofertas))
create view viewProdutoOfertas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_statusProduto.cd_status = '2' order by cd_produto;

-- view (Produtos (Premium))
create view viewProdutoPremium
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_statusProduto.cd_status = '3' order by cd_produto;

-- view (Produtos (Destaques))
create view viewProdutoDestaques
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_statusProduto.cd_status = '4' order by cd_produto;
    
-- view (venda)
create view viewVenda
as select
	tbl_venda.cd_venda,
	tbl_usuario.nm_usuario,
    tbl_usuario.cpf_usuario,
    tbl_venda.dt_venda,
    tbl_venda.hr_venda,
    tbl_venda.vl_venda
from tbl_venda inner join tbl_usuario
	on tbl_venda.cd_usuario = tbl_usuario.cd_usuario order by cd_venda;

-- view (itens da compra de um cliente)
create view viewCarrinho
as select
	tbl_usuario.cd_usuario,
    tbl_usuario.nm_usuario,
    tbl_venda.cd_venda,
	tbl_venda.vl_venda,
    tbl_venda.dt_venda,
    tbl_venda.hr_venda,
	tbl_produto.img_produto,
    tbl_produto.nm_produto,
    tbl_produto.vl_produto,
    tbl_carrinho.qt_produto
from tbl_produto inner join tbl_carrinho
	on tbl_produto.cd_produto = tbl_carrinho.cd_produto
inner join tbl_venda
	on tbl_venda.cd_venda = tbl_carrinho.cd_venda
inner join tbl_usuario
	on tbl_usuario.cd_usuario = tbl_venda.cd_usuario;
    
-- view (Comentario e Usuario)
create view viewComentario
as select
	tbl_comentario.cd_comentario,
    tbl_comentario.ds_comentario,
    tbl_usuario.nm_usuario,
    tbl_comentario.dt_comentario,
    tbl_usuario.img_usuario
from tbl_comentario inner join tbl_usuario
	on tbl_comentario.cd_usuario = tbl_usuario.cd_usuario order by cd_comentario;
    
-- view (Produtos Audio e Tecnologia (R$ 0,00 - R$ 1000,00))
create view viewProdutosFiltro1Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '0.00' and tbl_produto.vl_produto <= '1000.00' order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (R$ 1.000,00 - R$ 5.000,00))
create view viewProdutosFiltro2Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '1000.00' and tbl_produto.vl_produto <= '5000.00' order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (R$ 5.000,00 - R$ 10.000,00))
create view viewProdutosFiltro3Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '5000.00' and tbl_produto.vl_produto <= '10000.00' order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (R$ 10.000,00 - R$ 15.000,00))
create view viewProdutosFiltro4Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '10000.00' and tbl_produto.vl_produto <= '15000.00' order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (R$ 15.000,00 - R$ 20.000,00))
create view viewProdutosFiltro5Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '15000.00' and tbl_produto.vl_produto <= '20000.00' order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (R$ 20.000,00 - R$ 30.000,00))
create view viewProdutosFiltro6Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '20000.00' and tbl_produto.vl_produto <= '30000.00' order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (Acima de R$ 30.000,00))
create view viewProdutosFiltro7Tecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.vl_produto >= '30000.00'order by cd_produto;
    
-- view (Produtos Audio e Tecnologia (Lançamentos))
create view viewProdutosLançamentoTecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 and tbl_produto.cd_status = 1 order by cd_produto;
    
-- view (Produtos por maior preço em Audio e Tecnologia)) 
create view viewProdutosMaiorPrecoTecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 order by vl_produto desc;
    
-- view (Produtos por menor preço em Audio e Tecnologia)) 
create view viewProdutosMenorPrecoTecnologia
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 1 order by vl_produto;

-- view (Produtos Instrumentos de corda (R$ 0,00 - R$ 1000,00))
create view viewProdutosFiltro1Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '0.00' and tbl_produto.vl_produto <= '1000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de corda (R$ 1.000,00 - R$ 5.000,00))
create view viewProdutosFiltro2Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '1000.00' and tbl_produto.vl_produto <= '5000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de corda (R$ 5.000,00 - R$ 10.000,00))
create view viewProdutosFiltro3Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '5000.00' and tbl_produto.vl_produto <= '10000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de corda (R$ 10.000,00 - R$ 15.000,00))
create view viewProdutosFiltro4Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '10000.00' and tbl_produto.vl_produto <= '15000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de corda (R$ 15.000,00 - R$ 20.000,00))
create view viewProdutosFiltro5Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '15000.00' and tbl_produto.vl_produto <= '20000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de corda (R$ 20.000,00 - R$ 30.000,00))
create view viewProdutosFiltro6Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '20000.00' and tbl_produto.vl_produto <= '30000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de corda (Acima de R$ 30.000,00))
create view viewProdutosFiltro7Corda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 and tbl_produto.vl_produto >= '30000.00' order by cd_produto;
    
-- view (Produtos por maior preço em Instrumentos de Corda)) 
create view viewProdutosMaiorPrecoCorda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 order by vl_produto desc;

-- view (Produtos por menor preço em Instrumentos de Corda)) 
create view viewProdutosMenorPrecoCorda
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 2 order by vl_produto;
    
-- view (Produtos Instrumentos de Bateria (R$ 0,00 - R$ 1000,00))
create view viewProdutosFiltro1Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '0.00' and tbl_produto.vl_produto <= '1000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Bateria (R$ 1.000,00 - R$ 5.000,00))
create view viewProdutosFiltro2Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '1000.00' and tbl_produto.vl_produto <= '5000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Bateria (R$ 5.000,00 - R$ 10.000,00))
create view viewProdutosFiltro3Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '5000.00' and tbl_produto.vl_produto <= '10000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Bateria (R$ 10.000,00 - R$ 15.000,00))
create view viewProdutosFiltro4Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '10000.00' and tbl_produto.vl_produto <= '15000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Bateria (R$ 15.000,00 - R$ 20.000,00))
create view viewProdutosFiltro5Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '15000.00' and tbl_produto.vl_produto <= '20000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Bateria (R$ 20.000,00 - R$ 30.000,00))
create view viewProdutosFiltro6Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '20000.00' and tbl_produto.vl_produto <= '30000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Bateria (Acima de R$ 30.000,00))
create view viewProdutosFiltro7Bateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 and tbl_produto.vl_produto >= '30000.00' order by cd_produto;
    
-- view (Produtos por maior preço em Bateria e Percussão)) 
create view viewProdutosMaiorPrecoBateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 order by vl_produto desc;

-- view (Produtos por menor preço em Bateria e Percussão)) 
create view viewProdutosMenorPrecoBateria
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 3 order by vl_produto;
    
-- view (Produtos Instrumentos de Teclas (R$ 0,00 - R$ 1000,00))
create view viewProdutosFiltro1Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '0.00' and tbl_produto.vl_produto <= '1000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Teclas (R$ 1.000,00 - R$ 5.000,00))
create view viewProdutosFiltro2Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '1000.00' and tbl_produto.vl_produto <= '5000.00' order by cd_produto;

-- view (Produtos Instrumentos de Teclas (R$ 5.000,00 - R$ 10.000,00))
create view viewProdutosFiltro3Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '5000.00' and tbl_produto.vl_produto <= '10000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Teclas (R$ 10.000,00 - R$ 15.000,00))
create view viewProdutosFiltro4Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '10000.00' and tbl_produto.vl_produto <= '15000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Teclas (R$ 15.000,00 - R$ 20.000,00))
create view viewProdutosFiltro5Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '15000.00' and tbl_produto.vl_produto <= '20000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Teclas (R$ 20.000,00 - R$ 30.000,00))
create view viewProdutosFiltro6Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '20000.00' and tbl_produto.vl_produto <= '30000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Teclas (Acima de R$ 30.000,00))
create view viewProdutosFiltro7Teclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 and tbl_produto.vl_produto >= '30000.00' order by cd_produto;
    
-- view (Produtos por maior preço em Instrumentos de Teclas)) 
create view viewProdutosMaiorPrecoTeclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 order by vl_produto desc;

-- view (Produtos por menor preço em Instrumentos de Teclas)) 
create view viewProdutosMenorPrecoTeclas
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 4 order by vl_produto;
    
-- view (Produtos Instrumentos de Arco e Sopro (R$ 0,00 - R$ 1000,00))
create view viewProdutosFiltro1Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '0.00' and tbl_produto.vl_produto <= '1000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Arco e Sopro (R$ 1.000,00 - R$ 5.000,00))
create view viewProdutosFiltro2Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '1000.00' and tbl_produto.vl_produto <= '5000.00' order by cd_produto;

-- view (Produtos Instrumentos de Arco e Sopro (R$ 5.000,00 - R$ 10.000,00))
create view viewProdutosFiltro3Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '5000.00' and tbl_produto.vl_produto <= '10000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Arco e Sopro (R$ 10.000,00 - R$ 15.000,00))
create view viewProdutosFiltro4Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '10000.00' and tbl_produto.vl_produto <= '15000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Arco e Sopro (R$ 15.000,00 - R$ 20.000,00))
create view viewProdutosFiltro5Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '15000.00' and tbl_produto.vl_produto <= '20000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Arco e Sopro (R$ 20.000,00 - R$ 30.000,00))
create view viewProdutosFiltro6Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '20000.00' and tbl_produto.vl_produto <= '30000.00' order by cd_produto;
    
-- view (Produtos Instrumentos de Arco e Sopro (Acima de R$ 30.000,00))
create view viewProdutosFiltro7Arco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 and tbl_produto.vl_produto >= '30000.00' order by cd_produto;

-- view (Produtos por maior preço em Arco e Sopro)) 
create view viewProdutosMaiorPrecoArco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 order by vl_produto desc;

-- view (Produtos por menor preço em Arco e Sopro)) 
create view viewProdutosMenorPrecoArco
as select
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.mar_produto,
	tbl_produto.qt_produto,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.ds_produto,
	tbl_produto.car_produto,
	tbl_statusProduto.nm_status
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_produto.cd_categoria = tbl_categoria.cd_categoria 
inner join tbl_statusProduto
	on tbl_produto.cd_status = tbl_statusProduto.cd_status where tbl_categoria.cd_categoria = 5 order by vl_produto;

-- consultado as views
select * from viewComentario;
select * from viewFuncionario;
select * from viewProduto;
select * from viewProdutoCorda;
select * from viewProdutoDestaques;
select * from viewProdutoLancamento;
select * from viewProdutoOfertas;
select * from viewProdutoPercussao;
select * from viewProdutoPremium;
select * from viewProdutoSopro;
select * from viewProdutoTeclas;
select * from viewProdutoTecnologia;
select * from viewUsuario;
select * from viewProdutosMaiorPrecoTecnologia;
select * from viewProdutosMenorPrecoTecnologia;
select * from viewProdutosMaiorPrecoArco;
select * from viewProdutosMenorPrecoArco;
select * from viewProdutosMaiorPrecoCorda;
select * from viewProdutosMenorPrecoCorda;
select * from viewProdutosMaiorPrecoBateria;
select * from viewProdutosMenorPrecoBateria;
select * from viewProdutosMaiorPrecoTeclas;
select * from viewProdutosMenorPrecoTeclas;
select * from viewVenda;
select cd_venda, nm_usuario, dt_venda, hr_venda, vl_venda from viewCarrinho where cd_usuario = '2' group by cd_venda;
select img_produto, nm_produto, vl_produto, qt_produto from viewcarrinho where cd_usuario = '2';
    
-- excluindo as views
drop view viewComentario;
drop view viewFuncionario;
drop view viewProduto;
drop view viewProdutoCorda;
drop view viewProdutoDestaques;
drop view viewProdutoLancamento;
drop view viewProdutoOfertas;
drop view viewProdutoPercussao;
drop view viewProdutoPremium;
drop view viewProdutoSopro;
drop view viewProdutoTeclas;
drop view viewProdutoTecnologia;
drop view viewUsuario;
drop view viewProdutosMenorPrecoLancamento;
drop view viewProdutosMaiorPrecoLancamento;
drop view viewProdutosMaiorPrecoTecnologia;
drop view viewProdutosMenorPrecoTecnologia;
drop view viewProdutosMaiorPrecoArco;
drop view viewProdutosMenorPrecoArco;
drop view viewProdutosMaiorPrecoCorda;
drop view viewProdutosMenorPrecoCorda;
drop view viewProdutosMaiorPrecoBateria;
drop view viewProdutosMenorPrecoBateria;
drop view viewProdutosMaiorPrecoTeclas;
drop view viewProdutosMenorPrecoTeclas;
drop view viewVenda;
drop view viewCarrinho;