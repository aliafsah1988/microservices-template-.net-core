# Simple Microservices sample architecture for .Net Core Application
### .Net Core 2.2 Sample With C#.Net, EF Core and SQL Server
* [Introduction](#Introduction)
* [Application Architecture](#Application-Architecture)
* [Security : JWT Token based Authentication](#Security--JWT-Token-based-Authentication)
* [Technologies](#Technologies)
* [Opensource Tools Used](#Opensource-Tools-Used)
* [Swagger: API Documentation](#Swagger-API-Documentation)
* [Postman Collection](#Postman-Collection)
* [How to run the application](#How-to-run-the-application)

## Introduction
This is a .Net Core sample application and an example of how to build and implement a microservices based back-end ASP.NET Core Web API with C#.Net, Entity Framework and SQL Server. 

## Application Architecture
The sample application is build based on the microservices architecture. There are serveral advantages in building a application using Microservices architecture like Services can be developed, deployed and scaled independently.The below diagram shows the high level design of Back-end architecture.

- **Identity Microservice** - Authenticates user based on username, password and issues a JWT Bearer token which contains Claims-based identity information in it.
- **Service A** - It's sample service with classic CRUD on sample entity.
- **API Gateway** - Acts as a center point of entry to the back-end application, Provides data aggregation and communication path to microservices.

## Security : JWT Token based Authentication
JWT Token based authentication is implementated to secure the WebApi services. **Identity Microservice** acts as a Auth server and issues a valid token after validating the user credentitals. The API Gateway sends the token to the client. The client app uses the token for the subsequent request.

## Technologies
- C#.NET
- ASP.NET WEB API Core
- EF Core
- SQL Server

## Opensource Tools Used
- Automapper (For object-to-object mapping)
- Entity Framework Core (For Data Access)
- Swashbucke (For API Documentation)
- Ocelot (For API Gateway Aggregation)

## Swagger: API Documentation

Swashbuckle Nuget package added to the "Transaction Microservice" and Swagger Middleware configured in the startup.cs for API documentation. when running the WebApi service, the swagger UI can be accessed through the swagger endpoint "/swagger".

## Postman Collection
There is an up to date postman collection in project

## How to run the application

1. Open the solution (.sln) in Visual Studio 2017 or later version
2. Configure the SQL connection string in ServiceA.WebApi -> Appsettings.json file
3. Configure the AppInsights Instrumentation Key in Transaction.WebApi -> Appsettings.json file. If you dont  have a key or don't require logs then comment the AppInsight related code in Startup.cs file 
4. Check the Identity.WebApi -> UserService.cs file for Identity info. User details are hard coded for few accounts in Identity service which can be used to run the app. Same details shown in the below table.
5. Run the following projects in the solution
    - Identity.WebApi
    - ServiceA.WebApi
    - Gateway.WebApi
6. EF Core configuared to make database if not existed, so after first time running, it will generate the database.
7. Idenity and ServiceA service host and port should be configured correctly in the gateway -> configuration.json 