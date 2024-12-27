# Documentación de los Microservicios

Este repositorio contiene la documentación para los 3 microservicios desarrollados: **Personas**, **Citas** y **Recetas**.

## Tabla de Contenidos

- [Introducción](#introducción)
- [Arquitectura General](#arquitectura-general)
- [Microservicio Personas](#microservicio-personas)
- [Microservicio Citas](#microservicio-citas)
- [Microservicio Recetas](#microservicio-recetas)
- [Configuración de RabbitMQ](#configuración-de-rabbitmq)
- [Pruebas](#pruebas)

---

## Introducción

Los microservicios están diseñados para gestionar información médica en un sistema modular y desacoplado:

- **Personas:** Gestiona pacientes y médicos.
- **Citas:** Gestiona el agendamiento y seguimiento de citas médicas.
- **Recetas:** Gestiona recetas médicas asociadas a citas finalizadas.

- ## Arquitectura General

### Tecnologías Utilizadas

- **.NET Framework 4.8**
- **Entity Framework** para acceso a datos
- **RabbitMQ** para comunicación entre microservicios
- **MediatR** para CQRS
- **AutoMapper** para mapeo de objetos
- **SQL Server** como base de datos

### Capas del Microservicio
Cada microservicio sigue una arquitectura en capas:

- **API:** Controladores y endpoints.
- **Application:** Lógica de negocio (CQRS).
- **Domain:** Entidades, interfaces y lógica de dominio.
- **Infrastructure:** Persistencia, servicios externos y configuración de RabbitMQ.

---

## Microservicio Personas

### Descripción
Gestiona información de personas:
- **Pacientes:** Información básica de pacientes registrados.
- **Médicos:** Información básica de médicos disponibles.

### Endpoints

| Método | Endpoint               | Descripción                       |
|--------|------------------------|-----------------------------------|
| GET    | `/api/personas/{id}`   | Obtiene una persona por ID.      |
| POST   | `/api/personas`        | Crea una nueva persona.          |

## Microservicio Citas

### Descripción
Gestiona las citas médicas:
- **Agendamiento:** Crear y administrar citas.
- **Estados de citas:** Pendiente, En proceso, Finalizada.
- **Comunicación:** Notifica al microservicio de Recetas cuando una cita finaliza.

### Endpoints

| Método | Endpoint                 | Descripción                              |
|--------|--------------------------|------------------------------------------|
| GET    | `/api/citas/{id}`        | Obtiene una cita por ID.                |
| POST   | `/api/citas`             | Crea una nueva cita.                    |
| PUT    | `/api/citas/{id}`        | Actualiza una cita existente.           |
| PUT    | `/api/citas/{id}/finalizar` | Finaliza una cita y publica un mensaje. |

### Estructura de Base de Datos

**Tabla: Citas**
| Campo         | Tipo       | Descripción                        |
|---------------|------------|------------------------------------|
| `Id`          | INT        | Identificador único.               |
| `Fecha`       | DATETIME   | Fecha de la cita.                  |
| `PacienteId`  | INT        | ID del paciente.                   |
| `MedicoId`    | INT        | ID del médico.                     |
| `Estado`      | VARCHAR(20)| Pendiente, En proceso, Finalizada. |

## Microservicio Recetas

### Descripción
Gestiona las recetas médicas:
- **Creación:** Asociadas a citas finalizadas.
- **Estados:** Activa, Vencida, Entregada.
- **Integración:** Escucha mensajes de RabbitMQ enviados por el microservicio de Citas.

### Endpoints

| Método | Endpoint                 | Descripción                     |
|--------|--------------------------|---------------------------------|
| GET    | `/api/recetas/{id}`      | Obtiene una receta por ID.      |
| POST   | `/api/recetas`           | Crea una nueva receta.          |
| PUT    | `/api/recetas/{id}`      | Actualiza una receta existente. |
| DELETE | `/api/recetas/{id}`      | Elimina una receta.             |

### Estructura de Base de Datos

**Tabla: Recetas**
| Campo            | Tipo       | Descripción                        |
|------------------|------------|------------------------------------|
| `Id`             | INT        | Identificador único.               |
| `Codigo`         | VARCHAR(50)| Código único de la receta.         |
| `PacienteId`     | INT        | ID del paciente asociado.          |
| `FechaCreacion`  | DATETIME   | Fecha de creación de la receta.    |
| `Estado`         | VARCHAR(20)| Activa, Vencida, Entregada.        |

---

## Configuración de RabbitMQ

### Configuración del Exchange
- **Nombre:** `citas_exchange`
- **Tipo:** `Direct`

### Configuración de Claves de Enrutamiento
| Clave de Enrutamiento | Descripción                        |
|------------------------|------------------------------------|
| `cita.finalizada`      | Mensajes enviados al finalizar una cita. |

### Configuración de Colas
| Nombre de la Cola | Clave de Enrutamiento | Exchange        |
|-------------------|-----------------------|-----------------|
| `recetas_queue`   | `cita.finalizada`     | `citas_exchange`|

### Pruebas Manuales
1. **Microservicio Personas:**
   - Crear, obtener, actualizar y eliminar personas mediante Postman.

2. **Microservicio Citas:**
   - Crear una cita.
   - Finalizar una cita y verificar que el mensaje se publique en RabbitMQ.
