alter procedure sp_manipula_dados_tab_ca_usuario
    @operacao varchar(1),
    @tab_ca_usuario tp_tab_ca_usuario readonly,
    @id_usuario_audit int
as
begin

    declare @msg_retorno varchar(500) = 'OK',
            @id_usuario int,
            @login varchar(30),
            @senha varchar(32),
            @nome_usuario varchar(100),
            @email_usuario varchar(100),
            @cpf_usuario varchar(11),
            @ind_admin bit,
            @ind_inativo bit,
            @ultimo_acesso datetime,
			@proximo_id int;

    select @id_usuario = id_usuario,
           @login = login,
           @senha = senha,
           @nome_usuario = nome_usuario,
           @email_usuario = email_usuario,
           @cpf_usuario = cpf_usuario,
           @ind_admin = ind_admin,
           @ind_inativo = ind_inativo
    from @tab_ca_usuario;

    if (@operacao = 'I')
    begin
        if exists
        (
            select top 1
                   tcu.id_usuario
            from dbo.tab_ca_usuario as tcu with (nolock)
            where tcu.cpf_usuario = @cpf_usuario
        )
        begin
            set @msg_retorno = 'Já existe um usuário cadastrado para este CPF!';
        end;
        else
        begin
		select @proximo_id = max(id_usuario) + 1 from tab_ca_usuario as x with (nolock)
            insert into dbteste.dbo.tab_ca_usuario
            (
                id_usuario,
                login,
                senha,
                nome_usuario,
                email_usuario,
                cpf_usuario,
                ind_admin,
                ind_inativo
            )
            select isnull(@proximo_id,0),
                   login,
                   senha,
                   nome_usuario,
                   email_usuario,
                   cpf_usuario,
                   ind_admin,
                   ind_inativo
            from @tab_ca_usuario;
        end;
    end;
    if (@operacao = 'U')
    begin
        if not exists
        (
            select top 1
                   1
            from dbo.tab_ca_usuario as tcu with (nolock)
            where tcu.id_usuario = @id_usuario
        )
        begin
            set @msg_retorno = 'Não existe usuário cadastrado para este ID!';
        end;
        else
        begin
            update tcu
            set tcu.login = tp.login,
                tcu.senha = tp.senha,
                tcu.nome_usuario = tp.nome_usuario,
                tcu.email_usuario = tp.email_usuario,
                tcu.cpf_usuario = tp.cpf_usuario,
                tcu.ind_admin = tp.ind_admin,
                tcu.ind_inativo = tp.ind_inativo
            from dbteste.dbo.tab_ca_usuario as tcu with (nolock)
                inner join @tab_ca_usuario as tp
                    on tp.id_usuario = tcu.id_usuario;
        end;
    end;
    if (@operacao = 'D')
    begin
        if
        (
            select isnull(tcu.ultimo_acesso, '19000101')
            from dbteste.dbo.tab_ca_usuario as tcu with (nolock)
                inner join @tab_ca_usuario as tp
                    on tp.id_usuario = tcu.id_usuario
        ) > '19000101'
        begin
            set @msg_retorno = 'Não é possível excluir o usuário, pois ele já efetuou login no sistema!';
        end;
        else
        begin
            delete tcu
            from dbteste.dbo.tab_ca_usuario as tcu with (nolock)
                inner join @tab_ca_usuario as tp
                    on tp.id_usuario = tcu.id_usuario;
        end;
    end;

    select @ultimo_acesso = tcu.ultimo_acesso
    from dbteste.dbo.tab_ca_usuario as tcu with (nolock)
        inner join @tab_ca_usuario as tp
            on tp.id_usuario = tcu.id_usuario;
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
    select @id_usuario_audit,
           @operacao,
           getdate(),
           @msg_retorno,
           isnull(id_usuario,@proximo_id),
           login,
           senha,
           nome_usuario,
           email_usuario,
           cpf_usuario,
           ind_admin,
           ind_inativo,
           @ultimo_acesso
    from @tab_ca_usuario;

    select msg_retorno = @msg_retorno;

end;