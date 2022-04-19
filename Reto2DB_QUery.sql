CREATE DATABASE BibliotecaR2;

USE BibliotecaR2;

CREATE TABLE Libros (
	codigo int,
	titulo varchar(50),
	autor varchar(50),
	editorial varchar(50),
	precio int,
	cantidad int,
	primary key (codigo)
);
go

CREATE PROC sp_ver_libros --Procedimiento para mostrar todos los libros almacenados
AS SELECT * FROM Libros 
ORDER BY codigo;
GO

CREATE PROC sp_buscar_libro --Procedimiento para buscar un libro por nombre
@titulo varchar(50),
@editorial varchar(50),
@autor varchar(50)
AS SELECT * FROM Libros 
WHERE (titulo LIKE @titulo) or (editorial LIKE @editorial) or (autor LIKE @autor);
go

CREATE PROC sp_modificar_libro --Procedimiento para modificar un libro
@codigo int,
@titulo varchar(50),
@autor varchar(50),
@editorial varchar(50),
@precio int,
@cantidad int,
@accion varchar(50) OUTPUT 
AS
IF (@accion = '1')
BEGIN --AQUÍ SE PUEDE COLOCAR UNA PARTE DE CÓDIGO OARA HACER QUE SE GENERE AUTOMÁTICAMENTE CON UN FORMATO DISTINTO
	INSERT INTO Libros (codigo, titulo, autor, editorial, precio, cantidad)
	VALUES (@codigo, @titulo, @autor, @editorial, @precio, @cantidad)
	SET @accion = 'Libro ingresado correctamente'
END

ELSE IF (@accion = '2')
BEGIN
	UPDATE LIBROS SET titulo = @titulo, autor = @autor, editorial = @editorial, precio = @precio, cantidad = @cantidad WHERE codigo = @codigo;
	SET @accion = 'Libro modificado correctamente'
END

ELSE IF (@accion = '3')
BEGIN
	DELETE FROM Libros WHERE codigo = @codigo;
	SET @accion = 'Se ha eliminado el libro'
END