alter proc [dbo].[SP_InsPaquetesDisponible]
	@id as varchar(120),
	@idp varchar(120),
	@precio money,
	@cdisp int,
	@cllenos int,
	@finicial datetime,
	@ffinal datetime,
	@estado bit
	as
	begin
		if(exists(select * from paquetesdisponible where idpaqueted=@id))
			begin
				select '-1' as resp
			end
		else
			begin
				begin tran 

					begin try
						insert into paquetesdisponible(idpaqueted,idpaquete,precio,cupos_disp,cuposllenos,fechainicial,fechafinal,estado)
						values (@id,@idp,@precio,@cdisp,@cllenos,@finicial,@ffinal,@estado)
					
						if(@id='')
							begin 
								rollback
								select '-1' as resp
							end
						else
							begin
								commit
								select '1' as resp
							end
					end try
					begin catch
						rollback
						select @@ERROR as resp
					end catch
					
			end
	end
go
alter proc [dbo].[SP_ActuMunicipios]
	@id as varchar(120),
	@nom as varchar(100),
	@idd as varchar(120)
	as
	begin
		begin tran
			begin try
				update municipios
				set nombre=@nom,
					iddepartamento=@idd
				where idmunicipio=@id
				if(@id='')
					begin 
						rollback 
						select '-1' as resp
					end
				else
					begin
						commit
						select '1' as resp
					end
			end try
			begin catch
				rollback
				select @@ERROR as resp
			end catch
	end
	go
	alter proc [dbo].[SP_ActuPaquetesDisponible]
	@id as varchar(120),
	@idp varchar(120),
	@precio money,
	@cdisp int,
	@cllenos int,
	@finicial datetime,
	@ffinal datetime,
	@estado bit
	as
	begin
		begin tran
			begin try
				update paquetesdisponible
				set precio=@precio,
				idpaquete=@idp,
				cupos_disp=@cdisp,
				cuposllenos=@cllenos,
				fechainicial=@finicial,
				fechafinal=@ffinal,
				estado=@estado
				where idpaqueted=@id
				if(@id='')
					begin 
						rollback 
						select '-1' as resp
					end
				else
					begin
						commit
						select '1' as resp
					end
			end try
			begin catch
				rollback
				select @@ERROR as resp
			end catch
	end