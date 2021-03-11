# GoD_backend

The backend of **Game of Drones** was developed using .NET CORE version 5.0.200. If you have a .NET core SDK or Runtime compatible with that version you should be able to compile it from the source code or run it from the buil. 

There are two main folders
   - src - contains the source code of the aplication
   - UniTesting - contains the tests that were creted to test the functionality
   

Steps to Deploy and configure

Deploy requieres docker to be installed.

1. Go to the GoD_backend folder and run the command `$docker build .`
2. Then you need to run the docker container `docker run -d -p 5000:5000 --name GoD GoD_backend`
3. Now you can Deploy the front end https://github.com/mauriciogracia/GoD_frontend
