# Plane Simulation
This project is a web API developed using Angular, ASP.NET, and MSSQL, which simulates planes arriving and flying in and out of an airport. The project includes features such as music, a console, UI, and button controllers to interact with the simulation. The main components of the project are the FlightsController and the Plane class.
 
## Configuration
### Asp.Net Core Web API
- Go To `ConfiguredValues.cs`.
- Change the values to your local ports, `GetClient` will be Angulars Default port and `GetServer` will be the server default port, they are defaulty set to: `https://localhost:7099` (server) and `http://localhost:4200` (client).
- Change servername from DESKTOP-OJ4FU91\\VICTORSERVER to your local mssql server name, in `appsettings.json`.
- Go to tools in VS studio > nuget package manager > package manager console > write: `Update-Database`

### Angular
- Open the Client using cmd and enter `npm install`.
- Go To `myEnvironment.ts`.
- Change the `ServerUrl` to your server default port, it is defaulty set to: `https://localhost:7026`.

## Running The Project
- Make sure you've configured everything.
- Open the Server Project and run it (it will also show you the swagger).
- Open the Client using cmd and enter `ng serve`.
- Enter your Angular port url in the browser, it is usually `http://localhost:4200/`.

## Technologies I've Used for the Project
- ASP.Net core 6 Web Api.
- Angular 15.
- Microsoft SQL Server.
