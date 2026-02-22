🏧 ATM System API – Prueba Técnica

Este proyecto implementa una API para la gestión de un cajero automático (ATM), desarrollada bajo los principios de Arquitectura Orientada al Dominio (DDD) y asegurando la integridad de las reglas de negocio.

🏗️ Arquitectura del Proyecto

La solución está organizada en las siguientes capas:

📦 ATM.Domain

Contiene:

Entidades principales:

BankAccount

Person

Reglas de negocio del dominio.

🗄️ ATM.Data

Contiene:

DbContext

Implementación del repositorio de datos.

Uso de Entity Framework con base de datos en memoria.

⚙️ ATM.Application

Capa de orquestación:

Servicios de aplicación.

Consumo de repositorios.

Interacción con entidades de dominio.

🌐 ATM.Api

Punto de entrada de la aplicación:

Controladores REST.

Gestión de seguridad mediante JWT (JSON Web Tokens).

👥 Datos Iniciales en Memoria

Los datos se cargan dinámicamente al iniciar la aplicación:

DNI	Nombre	Apellido	PIN	Cuenta	Saldo
1	Atilano	Ceferino	0000	ES1	5000
2	Pepe	Gotera	0000	ES2	8000
3	Filemón	Pi	0000	ES3	12000
🔐 Seguridad

La autenticación se realiza mediante JWT.

El primer endpoint que debe invocarse es el de login:

🔑 Login

POST

https://localhost:7163/api/Auth/login
Body:
{
  "dni": "1",
  "pin": "0000"
}

Este endpoint devuelve un token JWT, que debe enviarse en la cabecera Authorization de las siguientes peticiones:

Authorization: Bearer {token}
💰 Operaciones Disponibles
➕ Ingreso (Deposit)

POST

https://localhost:7163/api/Bank/deposit
Body:
{
  "accountNumber": "ES1",
  "amount": 1000.00
}
➖ Disposición (Withdraw)

POST

https://localhost:7163/api/Bank/withdraw
Body:
{
  "accountNumber": "ES1",
  "amount": 1000.00
}
📝 Notas de la Implementación

Se adjunta en GitHub un JSON de exportación de endpoints de Postman.

El control de errores, dado el alcance de la prueba, es básico y se realiza directamente en los endpoints.

No se ha implementado un middleware específico de gestión global de errores.