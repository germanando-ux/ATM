# 🏧 ATM System API – Prueba Técnica

Este proyecto implementa una **API para la gestión de un cajero automático (ATM)**, desarrollada en .NET 10 bajo los principios de **Arquitectura Orientada al Dominio (DDD)** y asegurando la integridad de las reglas de negocio. En favor de la simplicidad, en esta prueba técnica, se ha optado por un modelo de dominio compartido . Esto significa que las entidades de Entity Framework (DbSet) actúan también como entidades de dominio, incorporando la lógica de negocio en el mismo objeto y evitando la complejidad de mapeos adicionales

---

## 🏗️ Arquitectura del Proyecto

La solución está organizada en las siguientes capas:

### 📦 ATM.Domain

Contiene las entidades (BankAccount y Person) y las reglas de negocio.

---

### 🗄️ ATM.Data

Contiene el DBContext y el repositorio de datos. En este caso con Entity Framework con datos en memoria

---

### ⚙️ ATM.Application

 Capa de orquestación con los servicios, que consume los repositorios y las entidades de dominio

---

### 🌐 ATM.Api

Punto de entrada de la aplicación. Gestiona los controladores REST y la seguridad mediante JWT (JSON Web Tokens).

---

## 👥 Datos Iniciales en Memoria

Los datos se cargan dinámicamente al iniciar la aplicación:

| DNI | Nombre    | Apellido   | PIN   | Cuenta | Saldo  |
|-----|----------|------------|-------|--------|--------|
| 1   | Atilano  | Ceferino   | 0000  | ES1    | 5000   |
| 2   | Pepe     | Gotera     | 0000  | ES2    | 8000   |
| 3   | Filemón  | Pi         | 0000  | ES3    | 12000  |

---
# 🚀 Casos de Uso


La autenticación se realiza mediante **JWT**.

El primer endpoint que debe invocarse es el de login:

## 🔑 Login

**POST**

```
https://localhost:7163/api/Auth/login
```

### Body:

```json
{
  "dni": "1",
  "pin": "0000"
}
```

Este endpoint devuelve un **token JWT**, que debe enviarse en la cabecera `Authorization` de las siguientes peticiones:

```
Authorization: Bearer {token}
```

---

## ➕ Ingreso (Deposit)

**POST**

```
https://localhost:7163/api/Bank/deposit
```

### Body:

```json
{
  "accountNumber": "ES1",
  "amount": 1000.00
}
```

---

## ➖ Disposición (Withdraw)

**POST**

```
https://localhost:7163/api/Bank/withdraw
```

### Body:

```json
{
  "accountNumber": "ES1",
  "amount": 1000.00
}
```

---

# 📝 Notas de la Implementación

- Se adjunta en el repositorio un **JSON de exportación de endpoints de Postman**.
- El control de errores, dado el alcance de la prueba, es básico con validaciones en los endpoints.
- No se ha implementado un middleware global de gestión de errores.
- Los datos se almacenan únicamente en memoria.