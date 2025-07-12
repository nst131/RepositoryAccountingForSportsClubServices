Automation of fitness club operators' work includes:

1.maintaining a customer database;

2.creating various types of membership cards;

3.registering client visits and generating visit logs for any time interval, by hall or by client;

4.scheduling client appointments in advance;

5.enabling input, deletion, storage, and editing of information stored in data tables

Backend: ASP.NET Core

Designed and implemented modular Web APIs:

WebApiService (main business logic)

AuthService (authentication and authorization)

Built secure JWT-based authentication and role-based

authorization using ASP.NET Core Identity and policies.

Configured Entity Framework Core with two independent databases: AuthDatabase, ServiceAccountingDatabase

Created and integrated microservices: RedisService, RabbitService

Followed best practices such as layered architecture, dependency injection, and modular configuration

Frontend: Angular (TypeScript) Created a role-based UI for 4 types of users: Admin, User, Trainer, Responsible

Admin login is pre-configured (email: admin@mail.ru, password: admin)

Used Angular features: Router, HTTPClient, and Reactive
