create table tab_ca_usuario_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
msg_retorno varchar(500),
id_usuario int not null,
login varchar(30) not null,
senha varchar(32) not null,
nome_usuario varchar(100),
email_usuario varchar(100), 
cpf_usuario varchar(11),
ind_admin bit,
ind_inativo bit,
ultimo_acesso datetime,
constraint [pk_tab_ca_usuario_audit] primary key clustered (id_audit)
)

create table tab_ca_perfil_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
id_perfil int not null,
nome_perfil varchar(30) not null,
constraint [pk_tab_ca_perfil_audit] primary key clustered (id_audit)
)

create table tab_ca_sistema_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
id_sistema int not null,
nome_sistema varchar(30) not null,
constraint [pk_tab_ca_sistema_audit] primary key clustered (id_audit)
)

create table tab_ca_versao_sistema_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
id_sistema int not null,
id_versao varchar(10) not null,
dta_inicio_versao datetime,
dta_fim_versao datetime,
constraint [pk_pk_tab_ca_versao_sistema_audit] primary key clustered (id_audit)
)

create table tab_ca_permissao_perfil_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
id_perfil int not null,
id_modulo int not null,
ind_escrita bit,
ind_leitura bit,
constraint [pk_tab_ca_permissao_perfil_audit] primary key clustered (id_audit)
)

create table tab_ca_permissao_usuario_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
id_usuario int not null,
id_perfil int not null,
constraint [pk_tab_ca_permissao_usuario_audit] primary key clustered (id_audit)
)

create table tab_ca_modulo_audit
(
id_audit int identity (1,1) not null,
audit_usuario int not null,
audit_operacao varchar(1),
audit_data datetime,
id_modulo int not null,
nome_modulo varchar(30) not null,
constraint [pk_tab_ca_modulo_audit] primary key clustered (id_audit)
)
