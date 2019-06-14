  CarritoPagedList 1,2,'bbb'
alter PROCEDURE [dbo].[CarritoPagedList]  
@startRow int,  
@endRow int,
@NombreUsuario varchar(50)  
AS  
BEGIN  
WITH ProductoResult AS  
(  
SELECT   
Id,  
NombreUsuario,  
NombreProd,   
Precio,  
Cantidad 
,ROW_NUMBER() OVER (ORDER BY Id) AS RowNum  
FROM  dbo.Carrito where NombreUsuario=@NombreUsuario
)  
SELECT   
Id  
,NombreUsuario  
,NombreProd  
,Precio  
,Cantidad  
FROM ProductoResult  
WHERE RowNum BETWEEN @startRow AND @endRow;  
END