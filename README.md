# CwkEnvApi
This repository contains a very basic ASP.NET Core 3.0 API that showcases how to work with different environments and settings files. It might be as a good starting point for beginner developers or developers that are just starting out with ASP.Net Core 3.0. 

## What is the idea of this API?
The API contains 3 different settings files:
1. appsettings.json
2. appsettings.Development.json
3. appsettings.QA.json

Each file contains a JSON object called Env:
```
  "Env": {
    "Name": "QA",
    "SettingsFileName": "appsettings.QA.json"
  }
```
Depending on the value `ASPNETCORE_ENVIRONMENT` environment variable, the API endpoint will display the current environment configuration which will make it easy to pin point which settings file is used. 

### Example
GET /env
```
{
    "name": "QA",
    "settingsFileName": "appsettings.QA.json"
}
```
## Playing around in Visual Studio
If you want to play around in Visual Studio and see how the different files are used, you need to change the `ASPNETCORE_ENVIRONMENT` in the project properties. 

![image](https://user-images.githubusercontent.com/16518928/69176599-af7eec80-0b0e-11ea-96a3-f2e881f7e45b.png)

If you change the value to "QA", the output will be
```
{
    "name": "QA",
    "settingsFileName": "appsettings.QA.json"
}
```

...because the appsettings.QA.json file will be used. 

If you delete the environment variable entirely, you will get the following output: 
```
{
    "name": "Probably production",
    "settingsFileName": "appsettings.json"
}
```
... because in this case the appsettings.json file is used. 
If you change it to "Development", then the settings from the appsettings.Development.json file will be used. 

## Playing around in an Azure Web App
In my discussion I noticed that the whole concept of environment variables is misunderstood. The whole idea about these variables it these are provided by the host. Therefore they are not inherent to the code we write. It's just a value that's passed to our code as the host executes our application. 

Fromo Azure perspective, having different environments means that you'll most probably have different Azure Web Apps. On each Azure Web App you have full control to customize the environment variables that the host will pass to your application. Here's a screenshot that shows how you can do that:

![image](https://user-images.githubusercontent.com/16518928/69177347-020cd880-0b10-11ea-94a3-9b6c11e6b043.png)

In this screenshot I passed "QA" as value to the ASPNETCORE_ENVIRONMENT variable and therefore if you execute the following request:
GET: https://cwkenvapi.azurewebsites.net/env
... you'll get the following response:
```
{
    "name": "QA",
    "settingsFileName": "appsettings.QA.json"
}
```
You can, of course, create your own Azure Web App and play around with the variable. Don't forget to restart the web app each time after you change the value of the variable. 

This is the most basic way to configure different environments for your ASP.NET Core app, each with its own connection strings and specific settings. Things can, of course get a little bit more complicated but in a lot of real life project having this basic knowledge already helps you get the job done. 
