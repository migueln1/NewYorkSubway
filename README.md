# New York subway entrances challenge

This repository contains an API for retrieving New York subway entrances, saving a user's most frequently used entrances, and calculating the distance between two entrances.

## Technologies and libraries used:
```
NET Core 6
AWS Cognito for User Management
AWS RDS database
AWS EC2
FastEndpoints
MediatR
EF Core
~~ Docker ~~
```

Main solution is splitted into different projects to follow clean architecture best practices. 
Local swagger integration for easy API utilization.
App Service publicly exposed to access the API.
FastEnpoints library used to manage CQRS pattern in API layer.
MediatR library used to manage CQRS pattern in application layer.
Repository and service pattern for retrieving data.
The application and user management were deployed using Amazon and Azure Cloud Services. 

## How to use

- Endpoints are not publicly exposed as a security feature. A Swagger UI is implemented in a local environment, and accessible endpoints running on an Azure App Service can be used loading this Postman collection (which I'll just share here for presentation purposes) [Postman Collection Url](https://www.postman.com/collections/97fe2df9f01087bb2913).

- Setting the RDS Connection String as a local secret is required for local solution deployment. More information on Dotnet User Secrets is available at [Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows)

###### Important
- Allowing inbound IP addresses is required to access the RDS instance for security reasons. You can contact me to enable all connections, which are only required when the deployment is done locally.

## Issues to mention
- Docker compatibility crashed, and I attempted to resolve the certificate-related issue on my machine, but it was impossible. I recommend that you use IIS for local deployment.
- Azure App Configuration stopped working properly in the solution, so I had to store sensitive AWS information in the appsettings.json file (I know, bad practice, but I can't reconnect the service again).

## Things that could be better

- Automapper or Mapster can make entity mapping easier (Because of the entities' simplicity, I did not use it in this case.).
- Sensitive AWS information should be saved in an external secret manager.