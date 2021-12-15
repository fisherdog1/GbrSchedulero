# GbrSchedulero
UNL CSCE361 Capstone Project

Software for scheduling airline crews.

# Contributors
- Mohammed Alwahaibi
- Brian Belt
- Aaron Linnell
- Nhien Nguyen

# Functional Demo

https://www.youtube.com/watch?v=xmwYyWIyXjQ

# Features

Create and manage flights, add or remove Crewmembers, and assign crewmembers to flights.

# Running

GbrSchedulero was developed in Visual Studio 2019, using .NET 5.0. Both are recommended to be used when testing. Some dependencies, listed below will not work on older .NET versions. On rare occasions, running Clean Solution may be required when running for the first time.

This project is dependent on a relational database hosted by AWS. For testing convenience, the connection string is included in appsettings.json. Ideally however, this would be hidden behind some login system, so that users do not have direct admin access to the RDB.

To initialize the database for testing, the user must run the Unit Test Group named "SimpleContextTest". Part of this test involves adding some example data to the database, which can then be viewed from the webpage. The project is not very interesting without this test data, but this must only be done once before viewing the page. Running all the tests with "Run All Tests" is not recommended.

Some unit tests depend on the connection string *also* being stored in Visual Studio User Secrets OR stored as an environment variable. These tests will fail otherwise, but can be ignored.

To launch the webserver, click "IIS Express" from the debug toolbar in Visual Studio. Alternatively, right click GbrWebFrontend in the Solution Explorer, mouse over Debug, and choose Start New Instance. Both options will start the web server, start your default browser and take you to the GbrSchedulero home page.

# Dependencies

Newtonsoft.Json 13.0.1 (Only used for unit testing)\
MySqlConnector 2.1.0\
Entity Framework Core 5.0.12 (SqlServer and Tools)\
MySql EntityFrameworkCore 5.0.8\
Bootstrap 5.1.2 (For flex features and layout on webpages)\
\
Entity Framework Core Triggers is included but not used.