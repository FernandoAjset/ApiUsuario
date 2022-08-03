USE ManejoUsuarios
CREATE TABLE Empleado
(  
	Id INT NOT NULL IDENTITY(1,1),
	CodigoEmpleado VARCHAR(10) NOT NULL PRIMARY KEY,
   Pais VARCHAR(50) NOT NULL,
   Titulo VARCHAR(15) NOT NULL CHECK( Titulo IN('Señor','Señora', 'Señorita') ),
   PrimerNombre VARCHAR(15) NOT NULL,
   SegundoNombre VARCHAR(15) NOT NULL,
      PrimerApellido VARCHAR(15) NOT NULL,
   SegundoApellido VARCHAR(15) NOT NULL,
   Email VARCHAR(50) NOT NULL,
   FechaNacimiento VARCHAR(15) NOT NULL,
   TelefonoMovil  VARCHAR(15) NOT NULL
);
INSERT INTO Empleado
VALUES('ABC123','Guatemala','Señor','Edgar','Fernando','Ajset','Nimacache','eajset@mail.com','26-09-1995',40405050)

INSERT INTO Empleado
VALUES('EFG345','Guatemala','Señor','Carlos','Enrique','Cabrera','Sosa','cecs@mail.com','03-01-2000',30451122)

CREATE TABLE Usuario
(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NombreUsuario VARCHAR(20) NOT NULL,
Contrasenia VARCHAR(200) NOT NULL
)
ALTER TABLE Usuario ALTER COLUMN Contrasenia varchar(200)
INSERT INTO Usuario
VALUES('ferajset','AQAAAAEAACcQAAAAEHRV2KPjzmZR5eNCeP0IJ/FNOkIIQhYaQZiEHfUwtU9qaH16nghFDDsci8PDO1ragQ==')