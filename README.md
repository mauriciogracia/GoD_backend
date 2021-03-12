# GoD_backend

The backend of **Game of Drones** was developed using .NET CORE version 5.0.200

There are two main folders
   - src - contains the source code of the aplication
   - UniTesting - contains the tests that were creted to test the functionality


This backend supports configurable gameEngine rules they are in the folder `gameEngine` and two files exist there:
 - PaperRockScissors.json
 - SheldonRules.json
 
The default one is SheldonRules.json, if you modify any of the rules in the file you need to restart this backend

# Deploy Process

Deploy requieres docker to be installed.

1. Go to the GoD_backend folder and run the command `$docker build .`
2. Then you need to run the docker container `docker run -d -p 5000:5000 --name GoD app`
3. Now you can Deploy the front end https://github.com/mauriciogracia/GoD_frontend
