# Proyecto: Sistema de Gestión de Reservas

Este proyecto es una aplicación web que permite gestionar reservas de distintos servicios.

Incluye:
- **Backend en .NET 8 y C#** con SQL Server.
- **Frontend en React con Vite** y Material UI.
- **Base de Datos en SQL Server** con Entity Framework para la gestión de reservas.

## Requisitos Previos

Para ejecutar correctamente este proyecto, necesitas:

- **Backend:**
  - .NET 8 SDK ([Descargar](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
  - SQL Server ([Descargar](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
  - SQL Server Management Studio (opcional, para administrar la base de datos)
  - Git (opcional, para clonar el repositorio)
  
- **Frontend:**
  - Node.js (versión 18 o superior) ([Descargar](https://nodejs.org/))
  - Git (opcional, para clonar el repositorio)

---

## Instalación y Configuración

### 1. Clonar los repositorios

Clonar el backend:
```sh
git clone https://github.com/TU_USUARIO/reserva-api.git
cd reserva-api
```

Clonar el frontend:
```sh
git clone https://github.com/TU_USUARIO/reserva-app.git
cd reserva-app
```

---

## Configuración del Backend

### 2. Configurar la base de datos en SQL Server

1. Abre **SQL Server Management Studio** o Azure Data Studio.
2. Crea una nueva base de datos ejecutando el siguiente comando:
   ```sql
   CREATE DATABASE ReservaDB;
   ```
3. Configura la conexión en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=ReservaDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```
   Si usas autenticación de SQL Server con usuario y contraseña:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=ReservaDB;User Id=sa;Password=TU_CONTRASEÑA;TrustServerCertificate=True;"
   }
   ```

### 3. Ejecutar migraciones para generar la base de datos

Ejecuta estos comandos en la terminal dentro del backend:
```sh
dotnet ef database update
```
Esto creará las tablas automáticamente en la base de datos.

---

## Configuración del Frontend

### 4. Instalar dependencias del frontend

```sh
npm install
```

### 5. Configurar la conexión con el backend

1. Crea un archivo `.env` en la raíz del frontend.
2. Agrega la siguiente variable:
   ```env
   VITE_API_URL=http://localhost:5000/api
   ```
   Si el backend está en un servidor remoto, usa su URL en lugar de `localhost`.

---

## Ejecución de la Aplicación

### 6. Iniciar el backend

Ejecuta en la terminal dentro de la carpeta del backend:
```sh
dotnet run
```
La API estará disponible en:
- `http://localhost:5000/swagger` (Swagger UI para probar la API)
- `http://localhost:5000/api/`

### 7. Iniciar el frontend

Ejecuta en la terminal dentro de la carpeta del frontend:
```sh
npm run dev
```
La aplicación estará disponible en:
- `http://localhost:5173`

---

## Endpoints del Backend

| Método | Endpoint               | Descripción                              |
|--------|------------------------|------------------------------------------|
| GET    | `/api/reserva`         | Obtiene todas las reservas              |
| GET    | `/api/reserva/servicios` | Obtiene la lista de servicios           |
| POST   | `/api/reserva`         | Crea una nueva reserva                  |

Ejemplo de solicitud `POST /api/reserva`:
```json
{
  "cliente": "Juan Pérez",
  "servicio": "Peluquería",
  "horario": "10:00",
  "fecha": "2025-03-01"
}
```

---

## Notas Finales

- Asegúrate de que SQL Server esté corriendo antes de iniciar el backend.
- Si cambias la URL del backend, actualiza el archivo `.env` en el frontend.
- Puedes probar la API con Postman o directamente en Swagger.
- Para detener la aplicación, presiona `Ctrl + C` en la terminal.

---

Con estos pasos, el sistema estará completamente funcional en tu entorno local.

