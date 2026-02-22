# 🏧 ATM System API – Prueba Técnica

Este proyecto implementa una **API para la gestión de un cajero automático (ATM)**, desarrollada bajo los principios de **Arquitectura Orientada al Dominio (DDD)** y asegurando la integridad de las reglas de negocio.

---

## 🏗️ Arquitectura del Proyecto

La solución está organizada en las siguientes capas:

### 📦 ATM.Domain
Contiene:
- Entidades principales:
  - `BankAccount`
  - `Person`
- Reglas de negocio del dominio.

---

### 🗄️ ATM.Data
Contiene:
- `DbContext`
- Implementación del repositorio de datos.
- Uso de **Entity Framework Core** con base de datos **InMemory**.

---

### ⚙️ ATM.Application
Capa de orquestación:
- Servicios de aplicación.
- Consumo de repositorios.
- Interacción con entidades de dominio.

---

### 🌐 ATM.Api
Punto de entrada de la aplicación:
- Controladores REST.
- Gestión de seguridad mediante **JWT (JSON Web Tokens)**.

---

## 👥 Datos Iniciales en Memoria

Los datos se cargan dinámicamente al iniciar la aplicación:

| DNI | Nombre    | Apellido   | PIN   | Cuenta | Saldo  |
|-----|----------|------------|-------|--------|--------|
| 1   | Atilano  | Ceferino   | 0000  | ES1    | 5000   |
| 2   | Pepe     | Gotera     | 0000  | ES2    | 8000   |
| 3   | Filemón  | Pi         | 0000  | ES3    | 12000  |

---

# 🔐 Seguridad

La autenticación se realiza mediante **JWT**.

El primer endpoint que debe invocarse es el de login:

## 🔑 Login

**POST**
