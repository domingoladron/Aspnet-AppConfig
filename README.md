# PulledConfig (.NET Core)

## What is it?
This demo is showing the use of AWS AppConfig inside a .net core web application and worker service.  It shows a possible pattern we could use to use pulled config rather than relying on environment variables or the appsettings.json file

## Getting started

You'll need to do a few things to get up and running with this demo.

1. If you don't have an .env file yet (it is NOT kept in source control, and do not add it), you can copy the template.env file to be your .env file
1. Edit this new .env file and fill in the appropriate variables with the correct details (see Environment Varibales below for more detials)
1. Using either Visual Studio or Ubuntu Bash, you can start the docker-compose app to start the application


## What is in this solution?

There are two apps running in this solution:
- **MyApi**  A barebones API which exposes a single endpoint @ ``` http://localhost:54436/config ```  This will retrieve the config this API is using.
- **MyWorker** A barebones Worker process which publishes its configuration data to the local docker.splunk instance

Note:  At present all AppConfig details are hard-coded in both the worker and the api to point at AWS region ```ap-southeast-2```

## Environment Variables
To run this sln, you will need to provide the following environment variables in the .env file for this solution to work

| env var | what is it? |
| --------| ----------- |
| APPCONFIG_APPID | The Id of our AWS AppConfig Application |
| APPCONFIG_ENVID | The Environment Id of our AWS AppConfig Application |
| APPCONFIG_API_PROFILEID | The Configuration Profile Id for the MyApi configuration  |
| APPCONFIG_WORKER_PROFILEID | The Configuration Profile Id for the MyWorker configuration |
| AWS_ACCESS_KEY_ID | Your AWS ACCESS KEY ID |
| AWS_SECRET_ACCESS_KEY | Your AWS SECRET ACCESS KEY |
| USE_LOCAL_CONFIG_FILE | The toggle to use either local config via appsetting.json (true) or AWS AppConfig (false) |