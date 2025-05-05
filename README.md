# Notifications Service

Este microservicio en C# con .NET 8 se encarga de enviar notificaciones por correo electrónico (SMTP) para confirmar el registro de usuarios.

## Tecnologías y dependencias clave

- [.NET 8 Worker Service](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers)
- [Confluent.Kafka](https://www.nuget.org/packages/Confluent.Kafka): integración con Apache Kafka para recibir eventos.
- [Serilog](https://serilog.net/): logging estructurado con almacenamiento en archivos y configuración flexible.
- [Entity Framework Core (SQL Server)](https://learn.microsoft.com/en-us/ef/core/)

## Funcionalidad principal

- Escucha eventos de confirmación desde un topic de Kafka.
- Envía correos electrónicos mediante SMTP.
- Loguea la actividad con Serilog para seguimiento.