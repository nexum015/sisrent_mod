USE SisRent
GO

INSERT  INTO Usuarios
        ( Rut, Nombres, ApPaterno, ApMaterno, Telefono, Email, IdRol, Clave, Estado )
VALUES  ( '159888207', 'Omar', 'Carmona', 'Rivas', '987654321', 'ocarmona@gmail.com', 1, '123456', 1 )
GO

INSERT  INTO Vehiculos
        ( IdModelo, Anio, Valor, Patente, RutaImagen, Observaciones, Estado )
VALUES  ( 138, 2010, 22000, 'ABCD12', '/Images/Aveo_2010.png', '5 Puertas, Frenos ABS, Cierre centralizado', 1 )
GO
