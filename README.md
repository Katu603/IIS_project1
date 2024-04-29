# IIS_project1 - Person Phone Book with RDF
### (Mini-Herold - Person Edition)
This project is created in the course of the LVA Integrated Information Systems (exersice 1).
This project was created with Visual Studio 2022 and the nuget dotNetRDF v3.1.1. The application is run on IIS-Express and provides a small UI where phone book entries, representing persons, can be queried. If either/and first name, last name, email, postal code, street name and/or street number the query will be executed and the results will displayed as a table. If nothing is entered, all entries of the peron phone book will be listed.

Via the dotNetRDF API a RDF graph is constructed (containing the databases schema and individuals) and saved as a rdfxml file (PhoneBook.rdf) for later use.
The actual query (SPARQL) is executed on the RDF graph containing through a query processor provided by the API.

![rdf-grapher_person_phone_book](https://github.com/Katu603/IIS_project1/assets/81974491/c8f76af6-89b9-4aff-9254-200008ab116e)
The graphic above shows the RDF graph with its schema and one instance.


Project created by group 2 (member: Katharina Blaimschein)

