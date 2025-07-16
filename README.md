NOTES

We have to download the project first and use Visual Stusdio. For the site to work, you need to type update-database in the Package Manager Console. The command will create a local database. Database seeding is performed during the first run of the program (https profile) in the CompanySeeder file.

DESCRIPTION

The application serves as a support tool for managing a construction company. It contains database entities related to employee costs, order/material costs, and project revenues. Based on the collected data, a summary of costs is generated. The report file is created automatically and is ready to download in xlsx (Excel) format.

DESIGN ELEMENTS

- ASP.NET MVC
- Entity Framework
- T-SQL queries
- EPPlus package for generating xlsx files
