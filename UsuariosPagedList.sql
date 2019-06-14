
UsuariosPagedList 1,1

alter PROCEDURE [dbo].[UsuariosPagedList]
@startRow int,
@endRow int
AS
BEGIN
WITH CustomerResult AS
(
SELECT 
U.Id,
U.NombreUsuario,
U.Apellidos, 
U.Nombres,
U.FechaNacimiento,
U.Telefono,
U.EstadoCivil,
U.Estado,
R.descripcion as Rol,
U.contraseña
,ROW_NUMBER() OVER (ORDER BY U.Id) AS RowNum
FROM dbo.Usuario U
Inner join dbo.Rol R ON U.RolId=R.Id
)
SELECT 
Id
,NombreUsuario
,Apellidos
,Nombres
,FechaNacimiento
,Telefono
,EstadoCivil
,Estado
,Rol
,contraseña
FROM CustomerResult
WHERE RowNum BETWEEN @startRow AND @endRow;
END