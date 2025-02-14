# hogent-logging

This repository was originally created for a workshop at HoGent on logging best practices in .NET/C#.

The workshop consists of 3 parts where participants work through several exercises to evolve an application without any logging into an application that includes different best practices to automate logging as much as possible.

Each part has its own branch to start from (part1, part2, part3). Each branch has a set of todo's, visible in the task pane of Visual Studio, and also includes a solution for the todo's of the previous step. There's also a "complete" branch with the last set of solutions and also includes the PowerPoint presentation that includes some slides used in the workshop as well as the slides from my talk "Log it like it's hot" that I've given at several conferences.

# getting started

## get Seq
To go through the exercises you'll need to install Seq, https://datalust.co/download. The code expects a default installation of SEQ, if you're using different settings (i.e. port number) then you'll need to make changes to the code.

## configure api keys in Seq
Next you will also need to configure Seq with the api keys that are used in the code, this is mainly used to change the minimum logging level dynamically from SEQ while the application is running. 

These are the keys that are used in the application:
- client: 1bJXLdO4yIMfIP9Kx5Q3
- api: yMblo58lvf2SWwxAamYJ

For each of these keys do the following:
- in Seq go to [settings] -> [api keys] -> press button [add key]
- give it a name
- for the token, press the link "specify a token..."
- enter the corresponding token mentioned above
- save your changes

## running the application
The application consists of a client, representing a customer, and an api representing the barista/coffee shop.

Depending on your IDE, start debugging should start both projects. If not change the startup settings or start both manually.
