ر# 🐾 PetClinic API (ASP.NET Core)

# A simple **PetClinic REST API** built using **ASP.NET Core Web API**.  
This project demonstrates basic REST concepts using **in-memory data storage** with two related resources: Pets and Appointments.

---

## 📌 Project Description

This API allows users to:
- Register pets in a clinic
- Create appointments for registered pets

The project uses **static lists** to store data in memory (no database).  
All data is lost when the application stops.

---

## 🚀 Features

- RESTful API structure
- Two controllers:
  - PetsController
  - AppointmentsController
- GET / POST / DELETE operations
- Basic validation
- Appointment creation requires an existing PetId


---

## 🛠 Technologies Used

- ASP.NET Core Web API
- C#
- In-memory storage using static lists


---

## 📂 API Endpoints

### 🐶 PetsController

Handles pet registration.

| Method | Endpoint | Description |
|------|---------|-------------|
| GET | `/api/pets` | Retrieve all pets |
| POST | `/api/pets` | Create a new pet |
| DELETE | `/api/pets/{id}` | Delete a pet |


ذذ
## 📅 AppointmentsController

Manages clinic appointments.

| Method | Endpoint | Description |
|------|---------|-------------|
| GET | `/api/appointments` | Retrieve all appointments |
| POST | `/api/appointments` | Create a new appointment |
| DELETE | `/api/appointments/{id}` | Delete an appointment |

🔒 **Validation Rule**  
An appointment can only be created if the provided `PetId` already exists.

---
## Clone the Repository

```bash
git clone https://github.com/USERNAME/PetClinicAPI.git
