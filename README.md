# IIS_project1 - Person Phone Book with RDF (Mini-Herold - Person Edition)
This project is created in the course of the LVA Integrated Information Systems (exersice 1).
This project was created with visual studio and the nuget dotNetRDF. The application is run on IIS-Express and provides a small UI where phone book entries, representing persons, can be queried by providing either/and first name, last name, email, postal code, street name and/or street number. 

Via the dotNetRDF API a RDF graph is constructed (containing the databases schema and individuals) and saved as a rdfxml file (PhoneBook.rdf) for later use.
The actual query (SPARQL) is executed on the RDF graph containing through a query processor provided by the API.

Created by group 2 (member: Katharina Blaimschein)
