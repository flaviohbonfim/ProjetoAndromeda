create procedure sp_tab_ca_usuario_ultimo_acesso
    @id_usuario int,
    @ultimo_acesso datetime
as
begin
    declare @msg_retorno varchar(500) = 'OK';
    update dbteste.dbo.tab_ca_usuario
    set ultimo_acesso = @ultimo_acesso
    where id_usuario = @id_usuario;

    --audit
    insert into dbteste.dbo.tab_ca_usuario_audit
    (
        audit_usuario,
        audit_operacao,
        audit_data,
        msg_retorno,
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
    select 0,
           'U',
           getdate(),
           @msg_retorno,
           id_usuario,
           login,
           senha,
           nome_usuario,
           email_usuario,
           cpf_usuario,
           ind_admin,
           ind_inativo,
           @ultimo_acesso
    from dbteste.dbo.tab_ca_usuario
    where id_usuario = @id_usuario;
end;