

select p.Id,p.Descripcion,p.Kb_Descarga,p.Kb_Subida,p.Minutos,p.UsuarioCreo,p.FechaCreo 
		 ,s.Descripcion Server, s.IP ,s.Puerto,s.Usuario,s.Clave
  from perfil_hotspot p
  left join server s
     on s.Id = p.IdServer