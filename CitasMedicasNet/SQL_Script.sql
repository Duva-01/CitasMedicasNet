IF OBJECT_ID('Usuario', 'U') IS NULL
BEGIN
    CREATE TABLE Usuario (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(100) NOT NULL,
        apellidos NVARCHAR(100) NOT NULL,
        usuario NVARCHAR(100) UNIQUE NOT NULL,
        clave NVARCHAR(100) NOT NULL
    );
END;

IF OBJECT_ID('Paciente', 'U') IS NULL
BEGIN
    CREATE TABLE Paciente (
        id INT PRIMARY KEY,  
        NSS NVARCHAR(50) UNIQUE NOT NULL,
        num_tarjeta NVARCHAR(50) NOT NULL,
        telefono NVARCHAR(50),
        direccion NVARCHAR(200),
        CONSTRAINT FK_Paciente_Usuario FOREIGN KEY (id) REFERENCES Usuario(id) ON DELETE CASCADE
    );
END;

IF OBJECT_ID('Medico', 'U') IS NULL
BEGIN
    CREATE TABLE Medico (
        id INT PRIMARY KEY,  
        num_colegiado NVARCHAR(50) UNIQUE NOT NULL,
        CONSTRAINT FK_Medico_Usuario FOREIGN KEY (id) REFERENCES Usuario(id) ON DELETE CASCADE
    );
END;


IF OBJECT_ID('Medico_Paciente', 'U') IS NULL
BEGIN
    CREATE TABLE Medico_Paciente (
        id INT IDENTITY(1,1) PRIMARY KEY,
        medico_id INT FOREIGN KEY REFERENCES Medico(id) ON DELETE NO ACTION,
        paciente_id INT FOREIGN KEY REFERENCES Paciente(id) ON DELETE NO ACTION
    );
END;

IF OBJECT_ID('Cita', 'U') IS NULL
BEGIN
    CREATE TABLE Cita (
        id INT IDENTITY(1,1) PRIMARY KEY,
        fecha_hora DATETIME NOT NULL,
        motivo_cita NVARCHAR(255) NOT NULL,
        paciente_id INT FOREIGN KEY REFERENCES Paciente(id) ON DELETE NO ACTION,
        medico_id INT FOREIGN KEY REFERENCES Medico(id) ON DELETE NO ACTION
    );
END;

IF OBJECT_ID('Diagnostico', 'U') IS NULL
BEGIN
    CREATE TABLE Diagnostico (
        id INT IDENTITY(1,1) PRIMARY KEY,
        valoracion_especialista NVARCHAR(255),
        enfermedad NVARCHAR(255),
        cita_id INT UNIQUE FOREIGN KEY REFERENCES Cita(id) ON DELETE CASCADE
    );
END;
-- Inserciones de datos de ejemplo
INSERT INTO Usuario (nombre, apellidos, usuario, clave)
VALUES ('Pablo', 'Gutierrez', 'pablog1', 'clave123');

INSERT INTO Usuario (nombre, apellidos, usuario, clave)
VALUES ('Alvaro', 'Garcia', 'alvarito34', 'clave123');

SELECT * FROM Usuario;

INSERT INTO Paciente (NSS, num_tarjeta, telefono, direccion, id)
VALUES ('12345678988', '9876543210', '555-1234', 'Calle Falsa 123, Ciudad', 1);

INSERT INTO Paciente (NSS, num_tarjeta, telefono, direccion, id)
VALUES ('987654321', '1234567890', '555-5678', 'Avenida Siempre Viva 742', 2);

SELECT * FROM Paciente;

INSERT INTO Usuario (nombre, apellidos, usuario, clave)
VALUES ('Maria', 'Rosales', 'marey1', 'clave123');

INSERT INTO Usuario (nombre, apellidos, usuario, clave)
VALUES ('Carlota', 'Guerrero', 'carlota5', 'clave123');

INSERT INTO Medico (num_colegiado, id)
VALUES ('12345678', 3);

INSERT INTO Medico (num_colegiado, id)
VALUES ('87654321', 4);

INSERT INTO Medico_Paciente (medico_id, paciente_id)
VALUES ('3', '1');

INSERT INTO Medico_Paciente (medico_id, paciente_id)
VALUES ('4', '2');


SELECT * FROM Medico_Paciente;

-- Insertar citas utilizando el formato correcto de fecha y hora
INSERT INTO Cita (fecha_hora, motivo_cita, paciente_id, medico_id)
VALUES ('2024-10-22T10:00:00', 'Consulta general', '1', '3');

INSERT INTO Cita (fecha_hora, motivo_cita, paciente_id, medico_id)
VALUES ('2024-10-23T11:00:00', 'Chequeo médico', '2', '4');

-- Insertar diagnósticos asegurando que el cita_id hace referencia a una Cita válida
INSERT INTO Diagnostico (valoracion_especialista, enfermedad, cita_id)
VALUES ('Valoración positiva', 'Gripe', 1);

INSERT INTO Diagnostico (valoracion_especialista, enfermedad, cita_id)
VALUES ('Valoración negativa', 'Migraña', 2);

SELECT * FROM Diagnostico;
