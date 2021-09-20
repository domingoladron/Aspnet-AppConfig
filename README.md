# Hooking up ASP.NET Core and AWS AppConfig

## What is it?
This demo is showing the use of AWS AppConfig inside a .net core web application and worker service.  This is based on the medium article of the same name


## Getting started

You'll need to do a few things to get up and running with this demo.

1. Clone the repo
1. Launch the app in Visual Studio
1. Edit the docker-compose.override.yml to update our AppConfig variables
1. Edit the docker-compose.override.yml to use either local appsettings.json or pull config from AWS AppConfig.


## What is in this solution?

There are two apps running in this solution:
- **MyApi**  A barebones API which exposes a single endpoint @ ``` http://localhost:54436/config ```  This will retrieve the config this API is using.
- **MyWorker** A barebones Worker process which publishes its configuration data to the local docker.splunk instance

## Environment Variables
To run this sln, you will need to provide the following environment variables in the .env file for this solution to work

| env var | what is it? |
| --------| ----------- |
| APPCONFIG_APPID | The Id of our AWS AppConfig Application |
| APPCONFIG_ENVID | The Environment Id of our AWS AppConfig Application |
| APPCONFIG_API_PROFILEID | The Configuration Profile Id for the MyApi configuration  |
| APPCONFIG_WORKER_PROFILEID | The Configuration Profile Id for the MyWorker configuration |
| USE_LOCAL_CONFIG_FILE | The toggle to use either local config via appsettings.json (true) or AWS AppConfig (false) |