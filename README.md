# RM
 
RMMiddleware Agent - Http Stats Collector
===

POC for using Middleware in .NET Core
---

**Overview**

This is a POC project that uses Middleware for collecting various stats within the Http Request and Response pipeline.  The stats are collected in an MVC project and displayed to the user within the Tests view.

This project was created as a POC to learn and to show how to integrate a Middlware Agent for recording stats on Http Request and Response information.

**Solution Layout**

Files and Descriptions:

* RM - Root Directory 
* RMWeb\RMWeb.sln - ASP .NET Core MVC Application for Runtime Testing RMMiddleware Agent
* RMMiddleware\RMMiddleware.csproj - .NET Standard Class Library - Middleware Agent that enables the collection of Http Requst and Response Data
* RMMiddleware\RMMiddlewareTests.csproj - XUnit Unit Test for testing RMMiddleware Class Library

Get Started:

* Open RMWeb\RMWeb.sln
* Build Solution and ensure all nuget packages are installed/restored
* Run RMWeb project in IIS Express or Docker Container
* Browse to (localurl)/test or click on the Main Menu line Stats to review the Stats Middleware Output View
* Browse to (localurl)/home and (localurl)/test2 or use the Main Menu links Home and Record to collect additional stats
* NOTE: Stats Record inlcude: Average Response Time, Max Response Time, Min Response Time, Total Responses, Response Body Length, and Request Path
* NOTE: Read RMMiddleware\Notes.txt for more information about this project and getting started learning about Middleware in .NET Core

How to Integrate:

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

* Deploying with Azure DevOps - Deatils TBD

TO-DO:

* See RMMiddleware\Notes.txt for a list of remaining items to code




