Brief Explanation About Project and Architecture:

- .NET Core 5.0 and Entity Framework 5.0.2 were used in the project.
- Basically, the architecture consists of controllers, data access with repositories and business layers.
- Dependency Injection pattern has been applied in the project.
- Controllers as slim as possible and only transfer data between clients and services.
- Services communicate with DB through Repositories.
- Fault, error and success response models for system and business errors were defined and the client was returned with a fixed response model.
- Custom exceptions were created, system and business exceptions were handled by creating middleware.
- Logical database design and relations between tables were established and created. 
- Database indexes were created in accordance with the most used queries in the application.
- Sensitive information security was taken into account in client - backend communication. 
- Communication between tables was provided via server-side IDs. (Unique GUID PK's in every table).
- Naming conventions were followed and clean, understandable code was used.
- Error messages and codes are dynamically stored in the database with application and language variables. 
- Error messages were transmitted to the Client by reading from the database. Information security was given importance in error messages. System and business errors were separated in appropriate cases. Cache will be added for messages.
- Development of Jwt authentication in progres...

How To Run Application: 

1) Create Empty Database.
2) Execute Database.sql script.
3) Clone the project.
4) Set Connection String in app.config 
5) You can edit OnlineBanking.ApplicationConstants > GeneralConstants.cs > "public static readonly string DefaultSchema = "dbo";" according to your database schema.
6) Click on project solution and open it.
7) Start the project with IIS Express, the project will be running when you see Swagger page.


