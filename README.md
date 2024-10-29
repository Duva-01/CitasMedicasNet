# CitasMedicasNet API

## Overview

**CitasMedicasNet** is a RESTful API developed with ASP.NET Core that manages a medical appointment system, enabling operations on entities such as doctors, patients, appointments, and diagnoses. This API supports bidirectional relationships between entities to provide a seamless experience when managing healthcare data. The system is designed to handle patient records, doctor information, medical appointments, and diagnostic details securely and efficiently.

## Features

- CRUD operations on key entities:
  - **Doctors** (Medico)
  - **Patients** (Paciente)
  - **Appointments** (Cita)
  - **Diagnoses** (Diagnostico)
  - **Doctor-Patient Relationships** (MedicoPaciente)
- Bidirectional relationships to simplify data navigation between related entities
- Robust validation for each model to ensure data integrity
- Error handling and logging for enhanced debugging and maintainability

## Entity Relationships

The API models a set of core relationships:

- **Doctor-Patient Relationship**: Represents multiple patients associated with multiple doctors.
- **Appointment**: Tied to both a patient and a doctor, supporting a one-to-many relationship.
- **Diagnosis**: One-to-one relationship with an appointment to store diagnostic details for a specific consultation.

## Technologies Used

- **ASP.NET Core** - Web framework for building APIs
- **Entity Framework Core** - ORM for database management and migrations
- **AutoMapper** - For mapping between entities and DTOs
- **SQL Server** - Relational database for storage
- **Swagger** - API documentation

## Setup and Installation

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database provider

### Installation Steps

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/CitasMedicasNet.git
   cd CitasMedicasNet
    ```
2. Configure the Database Connection

Update the database connection string in appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_SQL_Server_Connection_String"
  }
}
```

3. Run Migrations

Apply the migrations to set up the database schema:

```bash
dotnet ef database update
```

4. Run the Application

* Start the API server:

```bash
dotnet run
```

The API will be available at https://localhost:5001 or http://localhost:5000.

### Endpoints

#### Medico

* GET /Medico/{id} - Get doctor details by ID
* POST /Medico - Create a new doctor
* PUT /Medico - Update doctor information
* DELETE /Medico/{id} - Delete doctor by ID
  
#### Paciente

* GET /Paciente/{id} - Get patient details by ID
* POST /Paciente - Create a new patient
* PUT /Paciente - Update patient information
* DELETE /Paciente/{id} - Delete patient by ID
  
#### Cita

* GET /Cita/{id} - Get appointment details by ID
* POST /Cita - Create a new appointment
* PUT /Cita - Update appointment details
* DELETE /Cita/{id} - Delete appointment by ID
  
#### Diagnostico

* GET /Diagnostico/{id} - Get diagnosis details by ID
* POST /Diagnostico - Create a new diagnosis
* PUT /Diagnostico - Update diagnosis details
* DELETE /Diagnostico/{id} - Delete diagnosis by ID
