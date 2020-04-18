insert into dbteste.dbo.tab_ca_usuario
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
(   0,        -- id_usuario - int
    'admin',  -- login - varchar(30)
    convert(varchar(32), hashbytes('MD5', 'admin'), 2), -- senha - varchar(32)
    'Administrador',       -- nome_usuario - varchar(100)
    'admin@email.com',       -- email_usuario - varchar(100)
    '00000000000',       -- cpf_usuario - varchar(11)
    1,     -- ind_admin - bit
    0,     -- ind_inativo - bit
    null -- ultimo_acesso - datetime
    );