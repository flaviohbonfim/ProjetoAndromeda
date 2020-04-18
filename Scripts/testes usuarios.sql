declare @tab_ca_usuario as tp_tab_ca_usuario
insert into @tab_ca_usuario
(
    id_usuario,
    login,
    senha,
    nome_usuario,
    email_usuario,
    cpf_usuario,
    ind_admin,
    ind_inativo,
    ultimo_acesso
)
values
(   1,        -- id_usuario - int
    'flavio',       -- login - varchar(30)
    convert(varchar(32), hashbytes('MD5', 'senha'), 2),       -- senha - varchar(32)
    'Flávio',       -- nome_usuario - varchar(100)
    'flavio@email.com',       -- email_usuario - varchar(100)
    '00000000001',       -- cpf_usuario - varchar(11)
    1,     -- ind_admin - bit
    0,     -- ind_inativo - bit
    null -- ultimo_acesso - datetime
    )
exec sp_manipula_dados_tab_ca_usuario 'U', @tab_ca_usuario, 0

select * from dbo.tab_ca_usuario_audit as tcua with (nolock)
select * from dbo.tab_ca_usuario as tcu with (nolock)


declare @ultimo_acesso datetime = getdate()
exec sp_tab_ca_usuario_ultimo_acesso 0,@ultimo_acesso