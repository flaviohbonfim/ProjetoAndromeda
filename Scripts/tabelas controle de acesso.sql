create table tab_ca_usuario
(
id_usuario int not null,
login varchar(30) not null,
senha varchar(32) not null,
nome_usuario varchar(100),
email_usuario varchar(100), 
cpf_usuario varchar(11),
ind_admin bit,
ind_inativo bit,
ultimo_acesso datetime,
constraint [pk_tab_ca_usuario] primary key clustered (id_usuario)
)

create table tab_ca_perfil
(
id_perfil int not null,
nome_perfil varchar(30) not null,
constraint [pk_tab_ca_perfil] primary key clustered (id_perfil)
)

create table tab_ca_sistema
(
id_sistema int not null,
nome_sistema varchar(30) not null,
constraint [pk_tab_ca_sistema] primary key clustered (id_sistema)
)

create table tab_ca_versao_sistema
(
id_sistema int not null,
id_versao varchar(10) not null,
dta_inicio_versao datetime,
dta_fim_versao datetime,
constraint [pk_pk_tab_ca_versao_sistema] primary key clustered (id_sistema,id_versao)
)

create table tab_ca_permissao_perfil
(
id_perfil int not null,
id_modulo int not null,
ind_escrita bit,
ind_leitura bit,
constraint [pk_tab_ca_permissao_perfil] primary key clustered (id_perfil,id_modulo)
)

create table tab_ca_permissao_usuario
(
id_usuario int not null,
id_perfil int not null,
constraint [pk_tab_ca_permissao_usuario] primary key clustered (id_usuario,id_perfil)
)

create table tab_ca_modulo
(
id_modulo int not null,
nome_modulo varchar(30) not null,
constraint [pk_tab_ca_modulo] primary key clustered (id_modulo)
)
