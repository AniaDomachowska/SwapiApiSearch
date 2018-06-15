# Starwars character browser remarks

There are two web servers:
- StarWarsUI that shows list of characters in StarWars movies
- StarWarsApi - API that returns list of characters.

*After cloning the files from github please run 
**
npm install
npm install --save-dev webpack
node_modules\.bin\webpack --config webpack.config.js

** 

in the StarWarsUI folder*

I still need to sort out how to download the node packages in VS build.

To run the page, please set up both websites and if neccessary change the API URL in the ClientApp\app\components\home\home.component.ts file. (sorry for lack of configuration)

Api connects to https://swapi.co and returns Starwars characters under People resource. This resource  can be invoked by querying /People url:

- /People - iterates through all pages on swapi and returns all characters from the database.
- /People?search=Che - filters StarWars people by names
- /People/[id] - returns person of given Id

Only GET action is supported rest of actions (POST, PUT, DELETE) were disabled.

In the project I've used:
- Angular 4 and typescript for the front-end.
- Asp.Net Core 2.0 WebApi for the backend.
- Asp.Net Core Cors nuget library, to handle cors.
- "SharpTrooper" library that does all the calls to swapi and returns strongly typed object. I had to modify the library the way it supports searching.
- AutoMapper to map ugly People class to a decent Person, which uses camel case for properties.
- MSUnit for tests (I couldn't run NUnit in resharper so I gave up)
- Moq for mocking objects
- Autofac for dependency injections into controllers.
- I've tried to implement OData controller but failed. The swapi "search" clause would require me to parse the OData filter or even my own IQueryable + I never used it with angular 4. (I used angularjs so far)

What is missing:
- configuration of API url in StarWarsUi (0,5h)
- more integration tests (0,5-1h)
- getting the node packages in VS build (1-2h)