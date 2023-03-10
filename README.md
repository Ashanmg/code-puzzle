# Overview

This Project solution is created for code puzzle testing and included three projects which are
1. Asp.Net MVC Web Application (.Net Framework 4.7.2)
2. Console Application (.Net 6 (Long term support))
3. xUnit Test Library Application (.Net 6 (Long term support))

There were some issues identified and fixed while I am using VS2022 for cloned webappentityframework repo.
* Update the visual studio using package manager console command: Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
* Update the EF6 version from 6.1.3 to 6.4.4 to avoid migration issues.

## Prerequisites
To run the application, you need the following:
1. You need to install .NET 4.7.2 and .NET 6 version to compile the different applications
   [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
   [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
2. Open the project solution (prefer vs2022) and restore the packages.
3. Change web application connectionString in the Web.Config file (application has been setup for MSSQL database. You can change it to your own!)
```xml
 <connectionStrings>
    <add name="SQLConnection" connectionString="Data Source=[Your server ];Initial Catalog=[Your MSSQL database];Integrated Security=False;Persist Security Info=False;User ID=[UserName];Password=[Password];" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
4. Run the Migration file. Todo that you might need to enable migration first. Select correct project Puzzle.WebApp Run following command in package console manager
  "Enable-Migrations"
  "Update-Database"
5. Set Puzzle.WebApp as Startup Project to run the web application.
6. Set Puzzle.ConsoleApp as Startup Project to run the web console app. (You can setup multiple project to start with the properties section of solution)

## Used frameworks and libraries
* xUnit for service testing.
* Moq for Mock database.
* Autofac for Dependency Injection.
* EF 6 for ORM
