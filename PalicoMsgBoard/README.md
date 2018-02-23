# Mutant Database Online

**Author**: Ariel R. Pedraza <br />
**Version**: 1.0.0

## Overview
<b>Purpose:</b><br />
This application is a MVC ASP.NET Web App to test Entity Framework Core and Dependency Injection with call CRUD operations. The concept is to be able to add, view, modify, or delete a mutant from the database using get and post methods and routes. 

<b>How to use:</b><br />
In the home page enter your real name, alias, mutant power, and which team you belong to. Pressing "submit" will enter your information into the database and display everyone's information that is in the database. From there you can select details on an individual mutant to show all their info and are given the option to edit or delete the record. Edit brings you to a screen similar to the add new mutant with the fields pre-filled. Delete brings you to a confirmation page to delete the record. 

## Getting Started
The following is required to run the program locally.
1. Visual Studio 2017 
2. The .NET desktop development workload enabled
3. Ensure appsettings.json connection string is set to:
```
"ConnectionStrings": {

    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Cerebro;Trusted_Connection=True;MultipleActiveResultSets=true"
```
4. Install Entity Framework, and build database with the following commands in the Package Manager Console:
```
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration Initial
Update-Database
```

## Example
Add Mutant:<br/>
![Home Page](OnlineMutants/wwwroot/img/index.PNG)<br/>
View All Mutants:<br/>
![View All Page](OnlineMutants/wwwroot/img/viewall.PNG)<br/>
View Details:<br/>
![Details Page](OnlineMutants/wwwroot/img/details.PNG)<br/>
Edit Mutant:<br/>
![Edit Page](OnlineMutants/wwwroot/img/edit.PNG)<br/>
Delete Mutant:<br/>
![Delete Page](OnlineMutants/wwwroot/img/delete.PNG)<br/>

## Architecture
This application is created using ASP.NET Core 2.0 Web applications. <br />
*Language*: C# <br />
*Type of Applicaiton*: Web Application <br />