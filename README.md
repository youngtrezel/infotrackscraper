# infotrackscraper

READ ME

About
This search engine scraping application allows a user to select from either Google Search or Bing Search, enter word or phrase to search for with an accompanying URL and will display the URL’s position in the returned search results. The application will also store each search instance and save a record in a database, allowing the user to display searched results over a given date range.
This application has been developed using .Net 8 for the back end application and Angular 17 for the single page application UI. 

Prerequisites:
SQL Express installed
Application targets .Net 8 so make sure is also that is installed.
node.js and npm installed

How to run application
The start the API, open the InfoTrackSeo.sln in Visual Studio.
Open package manage console and enter ‘Update-Database’.
Set the API project as start up project press the http start button to run API.

For the front end application make sure node.jas and npm is intalls
Open the infotrackSeo.Spa folder in Visual Studio Code, open a terminal and run ‘npm i’ and ‘npm update’. Once all packages are installed run ‘ng serve’ and browse to localhost:4200.
