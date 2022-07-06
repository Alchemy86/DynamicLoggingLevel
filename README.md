# DynamicLoggingLevel
.net core Serilog dynamic  log level in Docker with environment variables 

## Purpose
To be able to dynamically change the log level of an application using Serilog without code changes.
This allows it to be done locally in config OR within docker deployment using an environement variable, direclty in portainer for example. 

![Pic](https://github.com/Alchemy86/DynamicLoggingLevel/blob/main/Screenshot%20from%202022-07-06%2010-47-20.png?raw=true)

## Docker Compose
docker compose -f 'docker-compose.yml' -f 'docker-compose.debug.yml' up -d --build  

Will now be running

