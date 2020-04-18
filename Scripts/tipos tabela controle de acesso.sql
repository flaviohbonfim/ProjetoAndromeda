create type tp_tab_ca_usuario as table
(
id_usuario int not null,
login varchar(30) not null,
senha varchar(32) not null,
nome_usuario varchar(100),
email_usuario varchar(100), 
cpf_usuario varchar(11),
ind_admin bit,
ind_inativo bit,
ultimo_acesso datetime
)

create type tp_tab_ca_perfil as table
(
id_perfil int not null,
nome_perfil varchar(30) not null
)

create type  tp_tab_ca_sistema as table
(
id_sistema int not null,
nome_sistema varchar(30) not null
)

create type tp_tab_ca_versao_sistema as table
(
id_sistema int not null,
id_versao varchar(10) not null,
dta_inicio_versao datetime,
dta_fim_versao datetime
)

create type tp_tab_ca_permissao_perfil as table
(
id_perfil int not null,
id_modulo int not null,
ind_escrita bit,
ind_leitura bit
)

create type tp_tab_ca_permissao_usuario as table
(
id_usuario int not null,
id_perfil int not null
)

create type tp_tab_ca_modulo as table
(
id_modulo int not null,
nome_modulo varchar(30) not null
)
