# RM
 
RMMiddleware Agent - Http Stats Collector
===

POC for using Middleware in .NET Core
---

**Overview**

This is a POC project that uses Middleware for collecting various stats within the Http Request and Response pipeline.  The stats are collected in an MVC project and displayed to the user within the Tests view.    

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

Code Example(s)
```

for(int i = 0; i < 100; i++)
{

}

```