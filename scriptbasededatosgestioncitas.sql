-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PersonasDB')
BEGIN
    CREATE DATABASE PersonasDB;
END
GO

USE PersonasDB;
GO

-- Crear tabla Personas con las restricciones especificadas
CREATE TABLE Personas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    TipoDocumento NVARCHAR(20) NOT NULL,
    NumeroDocumento NVARCHAR(20) NOT NULL,
    TipoPersona NVARCHAR(20) NOT NULL,
    Especialidad NVARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear índices para mejorar el rendimiento
CREATE NONCLUSTERED INDEX IX_Personas_TipoDocumento_NumeroDocumento 
ON Personas(TipoDocumento, NumeroDocumento);

CREATE NONCLUSTERED INDEX IX_Personas_TipoPersona 
ON Personas(TipoPersona);
GO

-- Agregar restricción de unicidad para documento
ALTER TABLE Personas
ADD CONSTRAINT UQ_Personas_TipoDocumento_NumeroDocumento 
UNIQUE (TipoDocumento, NumeroDocumento);
GO

-- Agregar restricción para TipoPersona
ALTER TABLE Personas
ADD CONSTRAINT CK_Personas_TipoPersona 
CHECK (TipoPersona IN ('Medico', 'Paciente'));
GO

  ALTER TABLE Personas ADD Discriminator NVARCHAR(MAX) NOT NULL DEFAULT 'Base';


  Create database CitasDB 
Use CitasDB
CREATE TABLE Citas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    PacienteId INT NOT NULL,
    MedicoId INT NOT NULL,
    Estado NVARCHAR(20) NOT NULL, -- Pendiente, En proceso, Finalizada
    --FOREIGN KEY (PacienteId) REFERENCES Personas(Id),
    --FOREIGN KEY (MedicoId) REFERENCES Personas(Id)
);
    ALTER TABLE [Citas] ADD lugar NVARCHAR(MAX) NOT NULL DEFAULT 'consultorio';
-- ==========================
-- Microservicio: Recetas
-- ==========================
Create database RecetasDB 
Use RecetasDB
-- Tabla Recetas
CREATE TABLE Recetas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(50) NOT NULL,
    PacienteId INT NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    Estado NVARCHAR(20) NOT NULL, -- Activa, Vencida, Entregada
   -- FOREIGN KEY (PacienteId) REFERENCES Personas(Id)
);