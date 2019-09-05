 
RMMiddleware Agent - Http Stats Collector
===

POC for using Middleware in .NET Core
---

**Overview**

This is a POC project that uses Middleware for collecting various stats within the Http Request and Response pipeline.  The stats are collected in an MVC project and displayed to the user within the Test View.

This project was created as a POC to learn and to show how to integrate a Middlware Agent for recording stats on Http Request and Response information.

**Solution Layout**

Files and Descriptions:

* RM - Root Directory 
* RMWeb\RMWeb.sln - ASP .NET Core MVC Application for Runtime Testing RMMiddleware Agent
* RMMiddleware\RMMiddleware.csproj - .NET Standard Class Library - Middleware Agent that enables the collection of Http Requst and Response Data
* RMMiddleware\RMMiddlewareTests.csproj - XUnit Unit Test for testing RMMiddleware Class Library

Dependencies:
* .NET Core SDK 2.2.401 x64
* SDK Downloads: https://dotnet.microsoft.com/download/dotnet-core/2.2
* Nuget Packages for RMMiddleware 

Get Started:

* Open RMWeb\RMWeb.sln
* Build Solution and ensure all nuget packages are installed/restored
* Run RMWeb project in IIS Express or Docker Container
* Browse to (localurl)/test or click on the Main Menu link Stats to review the Stats Middleware Output view
* Browse to (localurl)/home and (localurl)/test2 or use the Main Menu links Home and Record to collect additional Stats during runtime
* NOTE: Stats Recorded inlcude: Average Response Time, Max Response Time, Min Response Time, Total Responses, Response Body Length, and Request Path
* NOTE: Read RMMiddleware\Notes.txt for more information about this project and getting started learning about Middleware in .NET Core

How to Integrate into an existing ASP .NET Core MVC Project:

* RMMiddleware is integrated into the MVC Request Pipeline within Startup.cs
* Include the RMMiddleware project into your MVC Solution and add a reference to the RMMiddlware project.  You may use RMWeb project as an example.
* Add StatsMiddlewareCollector to your Http Pipline by adding the UseStatsMiddleware() extension method in your Startup.cs Configure method (see code example below)
* Add StatsMiddlewareContainerDTO to your DI Container as a Singleton (see code example below)
* Include StatsMiddlwareContainerDTO in an MVC Model to display the stats within a MVC View

Code Example(s)
```
	// TODO: Add StasMiddlewareCollector to your Application 
	public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
	{
		// NOTE: existing MVC code removed in this snippet to avoid clutter
		app.UseStatsMiddleware();
	}

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		// NOTE: existing MVC code removed in this snippet to avoid clutter
		services.AddSingleton<StatsMiddlewareContainerDTO, StatsMiddlewareContainerDTO>();
	}
	
```

Deployment:

* Publish RMWeb to Azure DevOps witin Visual Studio Build > Publish RMWeb 

TO-DO:

* Add more stats and security checks
* Setup CI that is triggered by updates to GitHub Master branch
* Add Logging at the method level
* Add exception handling and custom exceptions
* Determine if using a DTO as a Singleton that is injected as a reference into the Invoke method is best practice.  Many examples use Logging or append to the Response object.
* Cover more code with Unit/Functional Tests
* TBD - Retreive data from Log(s) and display to UI?
* TBD - Save Stats Results to a database?

Bugs:

* Docker for Windows not working locally and therefor cannot setup CI within Azure
