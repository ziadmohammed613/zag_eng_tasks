1. What are the fundamental differences between the original ASP.NET and ASP.NET Core?
ASP.NET : the official framework supported by .NET platform whose goal is to create web applications
ASP.NET CORE : the new version of ASP.NET that is multi-platform (supports windows , macOS , linux)
2. What does it mean for an API to be "Stateless"?
every request is independant (api doesn't store the previoues states)
3. Break down the anatomy of an HTTP Request URL?
scheme , host , path , query string
4. What are the primary HTTP Methods (Verbs) and their standard uses?
GET : get data
POST : create new data
PUT : update existing data
DELETE : delete existing data
5. What is the role of Program.cs in an ASP.NET Core application?
configuring and building api
6. Why is Swagger/OpenAPI typically enabled only in the "Development" environment?
descriping api in specific format
7. What is the core concept of "Dependency Injection" (DI)?
reducing components depending on each other internal implementation
8. Explain the three Service Lifetimes in ASP.NET Core DI?
singleton , scoped , transeint
9. Why is it a "Best Practice" to register services against an Interface rather than a concrete Class?
interface adds more flexibility if multiple classes found doing the same service
10. What are the "Launch Profiles" found in launchSettings.json ?
configuration for running web app
11. How does JSON facilitate data exchange in APIs
exchange it to key , values notation