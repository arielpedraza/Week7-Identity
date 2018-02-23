# Palico Message Board

**Website**: [Deployed Web site](https://palicomsgboard.azurewebsites.net/) <br />
**Author**: Ariel R. Pedraza <br />
**Version**: 1.0.0

## Overview
<b>Purpose:</b><br />
This application is a MVC ASP.NET core Web App to test the use of Identity Framework. The concept is to be able to register and login with a user then add, view, modify, or delete a messages from the database. 

<b>How to use:</b><br />
In the home page register with your name, Email, and password, or login with Email and password. You are able to create a new message and mark it as public if you would like it to be shown on the home page for users not registered with the website. From there you can select details on an individual message and are given the option to edit or delete the message.

## Getting Started
The following is required to run the program locally.
1. Visual Studio 2017 
2. The .NET desktop development workload enabled
3. Ensure appsettings.json connection string is set to:
```
"ConnectionStrings": {

    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MsgBoard;Trusted_Connection=True;MultipleActiveResultSets=true"
```
4. Install Entity Framework, and build database with the following commands in the Package Manager Console:
```
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration Initial
Update-Database
```

## Grading Criteria
3 points - Create 2 different types of users (Member-type and Admin-type)
<br />- Palico (normal user) - Views/Account/Register.cshtml
<br />- Hunter (admin) - Views/Account/RegisterAdmin.cshtml
<br />4 points - Create a different registration page for the Admin page (this can be a hidden link)
<br />- http://palicomsgboard.azurewebsites.net/Account/RegisterAdmin
<br />4 points - Attach at least 4 claims (including their Role) to the registration process.
<br />- Controllers/AccountController - RegisterAdmin()
<br />4 points - Redirect the user, dependant on their role, to a specific page, upon login (can you figure out how to lock down a page dependant on their Role?)
<br />- Logged in users redirect to palicomsgboard.azurewebsites.net/Messages - locked down to only "registered users"
<br />4 points (1 point for each CRUD operation) - Create a standard CRUD controller to manipulate data within your site.
<br />- palicomsgboard.azurewebsites.net/Messages - after being logged in
<br />4 points - Restrict your CRUD controller to specific access.
<br />- palicomsgboard.azurewebsites.net/Messages - locked down to only "registered users"
<br />3 points - Update your application to include at least 2 roles.
<br />- Palico and Hunter are configured in the Startup.cs. Models/AppRoles.cs is the file that declares them as consts. Used when declaring the Policy "RequireAccount" in Startup, requiring one of these two roles.
<br />3 points - Add at least one role based policy and one custom Authorization Handler policy to your application.
<br />- Startup.cs has RequireAccount policy that is role based. No custom handler policy.
<br />3 points - Implement both of these policies in your site.
<br />- Entire MessageController has [Authorize(Policy = "RequireAccount")]
<br />3 points - Update your application to include a View Component.
<br />- Located on the home page, displays latest 5 public msgs.


## Architecture
This application is created using ASP.NET Core 2.0 Web applications. <br />
*Language*: C# <br />
*Type of Applicaiton*: Web Application <br />
