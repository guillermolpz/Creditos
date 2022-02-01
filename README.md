# Proyecto ejemplo Creditos
Proyecto de ejemplo de ASP.NET Core

### Prerequisites
Crear una bd en SqlServer con las siquientes sentencias

```
CREATE DATABASE creditos
use creditos;

CREATE TABLE Clientes (
    id_cliente int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    nombre varchar(255) NOT NULL,
    no_identificacion int
);

CREATE TABLE CuentaAhorro (
    id_cuenta int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    cuenta int NOT NULL,
    saldo_actual decimal,
	id_cliente int,
	CONSTRAINT FK_ClienteCuenta FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);

CREATE TABLE Transaccion (
    id_transaccion int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    monto decimal(6,2) NOT NULL,
    tipo varchar(255),
	id_cuenta int,
	id_cliente int,
	CONSTRAINT FK_ClienteTransaccion FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente),
	CONSTRAINT FK_CuentaTransaccion FOREIGN KEY (id_cuenta) REFERENCES CuentaAhorro(id_cuenta)
);
```

### Como compilar proyecto
* Descargar la solució
* Cambiar las cadenas de conexion de ADO.NET en las clases de la capa CreditoNeg > Negocio 
* Colocar el proyecto "WebAplication"
