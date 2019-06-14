ProductoPagedList 1,5
alter PROCEDURE [dbo].[ProductoPagedList]
@startRow int,
@endRow int
AS
BEGIN
WITH ProductoResult AS
(
SELECT 
Id,
Nombre,
Descripcion, 
Precio,
ImagePath,
Estado,
Stock
,ROW_NUMBER() OVER (ORDER BY Id) AS RowNum
FROM dbo.Producto 
)
SELECT 
Id
,Nombre
,Descripcion
,Precio
,ImagePath
,Estado
,Stock
FROM ProductoResult
WHERE RowNum BETWEEN @startRow AND @endRow;
END