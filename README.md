# ASP.NET Core with the dotnet CLI, VUEJS, EntityFramework, OpenIddict

This is an opinionated single page app (work in progress)

Includes:
   1. ASP.NET Core 1.1
   2. EF Core for database management (including migration support)
   3. OpenIddict for token based auth (includes refresh token management)
   4. VUEJS isomorphic front-end
   5. Vue-router for client side route management
   6. Webpack with hot reload
   7. Image upload support via Dropzone (uploads to azure storage)
   8. Visual Studio 2015 support

## How to run

1. Get the .NET Core SDK http://dot.net
2. Clone this repo
3. run `dotnet restore` in the root folder
4. From root folder, navigate to `src\web\appsettings.json` and set DB connection string and azure storage connection string 
5. Still in web folder run `npm install` and `bower install` and `webpack`
6. From root folder, navigate to `src\data` and run `dotnet ef database update` to create the database if it doesn't exist
7. Navigate to the web folder `src\web` and run `dotnet run`
8. Navigate to `http://localhost:5000` in the browser


## Screenshot
![Containers](https://raw.githubusercontent.com/jdosullivan/aspnetcorevuejs/master/screenshot.png)
