using telephoneBook_RDF.Models;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Query.Datasets;
using VDS.RDF.Writing;

namespace telephoneBook_RDF.Data
{
    public class RDFDataManagement
    {
        private Graph g = new Graph();
        private int currentFreeId = 0;

        public RDFDataManagement()
        {
            if (File.Exists("C:\\Users\\katha\\Documents\\GitHub\\IIS_project1\\telephoneBook_RDF\\telephoneBook_RDF\\PhoneBook.rdf"))
            {
                System.Diagnostics.Debug.WriteLine("Debug: RDF-File already exists");
                try
                {
                    g = new Graph();

                    //Load using Filename
                    FileLoader.Load(g, "PhoneBook.rdf");
                }
                catch (RdfParseException parseEx)
                {
                    //This indicates a parser error e.g unexpected character, premature end of input, invalid syntax etc.
                    System.Diagnostics.Debug.WriteLine("Parser Error");
                    System.Diagnostics.Debug.WriteLine(parseEx.Message);
                }
                catch (RdfException rdfEx)
                {
                    //This represents a RDF error e.g. illegal triple for the given syntax, undefined namespace
                    System.Diagnostics.Debug.WriteLine("RDF Error");
                    System.Diagnostics.Debug.WriteLine(rdfEx.Message);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Debug: Creating graph.");
                createGraph();
            }


            /*foreach (Triple t in g.Triples)
            {
                System.Diagnostics.Debug.WriteLine(t.ToString());
            }*/
        }

        public List<string> getGraph()
        {
            List<string> triples = new List<string>();
            foreach (Triple t in g.Triples)
            {
                triples.Add(t.ToString());
            }
            return triples;
        }

        private void createGraph()
        {
            g = new Graph();

            // Add namespaces (RDF and RDFS are already declared)
            g.NamespaceMap.AddNamespace("owl", UriFactory.Create("http://www.w3.org/2002/07/owl#"));
            g.NamespaceMap.AddNamespace("exv", UriFactory.Create("http://example.org/vocabulary/"));
            g.NamespaceMap.AddNamespace("exi", UriFactory.Create("http://example.org/instances/"));

            IUriNode PersonPhoneBookEntry = g.CreateUriNode("exv:PersonPhoneBookEntry");
            IUriNode represents = g.CreateUriNode("exv:Represents");
            IUriNode Person = g.CreateUriNode("exv:Person");
            IUriNode a = g.CreateUriNode("rdf:type");
            IUriNode owlClass = g.CreateUriNode("owl:Class");
            IUriNode owlProperty = g.CreateUriNode("owl:Property");
            IUriNode range = g.CreateUriNode("rdfs:range");
            IUriNode domain = g.CreateUriNode("rdfs:domain");
            IUriNode stringType = g.CreateUriNode("xsd:string");
            IUriNode intType = g.CreateUriNode("xsd:int");
            IUriNode listType = g.CreateUriNode("rdf:Bag");
            IUriNode firstName = g.CreateUriNode("exv:firstName");
            IUriNode lastName = g.CreateUriNode("exv:lastName");
            IUriNode country = g.CreateUriNode("exv:country");
            IUriNode postalCode = g.CreateUriNode("exv:postalCode");
            IUriNode street = g.CreateUriNode("exv:street");
            IUriNode streetNo = g.CreateUriNode("exv:streetNo");
            IUriNode email = g.CreateUriNode("exv:email");
            IUriNode phoneNo = g.CreateUriNode("exv:phoneNo");


            g.Assert(new Triple(PersonPhoneBookEntry, a, owlClass));
            g.Assert(new Triple(PersonPhoneBookEntry, represents, Person));
            g.Assert(new Triple(represents, a, owlProperty));
            g.Assert(new Triple(represents, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(represents, range, Person));
            g.Assert(new Triple(Person, a, owlClass));

            g.Assert(new Triple(firstName, a, owlProperty));
            g.Assert(new Triple(firstName, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(firstName, range, stringType));
            g.Assert(new Triple(lastName, a, owlProperty));
            g.Assert(new Triple(lastName, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(lastName, range, stringType));
            g.Assert(new Triple(country, a, owlProperty));
            g.Assert(new Triple(country, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(country, range, stringType));
            g.Assert(new Triple(postalCode, a, owlProperty));
            g.Assert(new Triple(postalCode, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(postalCode, range, intType));
            g.Assert(new Triple(street, a, owlProperty));
            g.Assert(new Triple(street, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(street, range, stringType));
            g.Assert(new Triple(streetNo, a, owlProperty));
            g.Assert(new Triple(streetNo, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(streetNo, range, intType));
            g.Assert(new Triple(email, a, owlProperty));
            g.Assert(new Triple(email, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(email, range, stringType));
            g.Assert(new Triple(phoneNo, a, owlProperty));
            g.Assert(new Triple(phoneNo, domain, PersonPhoneBookEntry));
            g.Assert(new Triple(phoneNo, range, stringType));

            addIndividual("Ernst", "Haft", "Austria", 4040, "Mengerstraße", 8, "+43 664 134684", "ernst.haft@gmail.at");
            addIndividual("Hella", "Wahnsinn", "Austria", 5140, "Rheinstraße", 44, "+43 664 1283371", "hella.wahnsinn@gmail.at");
            addIndividual("Earl E.", "Bird", "Austria", 5071, "Bankgasse", 65, "+43 660 3123206", "earle.bird@gmail.at");
            addIndividual("Al", "Dente", "Austria", 1010, "Alxingergasse", 182, "+43 660 956314", "al.dente@gmail.at");
            addIndividual("Anna", "Conda", "Austria", 2002, "Grabengassl", 178, "+43 660 751265", "anna.conda@gmail.at");
            addIndividual("Anna", "Conda", "Austria", 2002, "Grabengassl", 66, "+43 660 751236", "anna.conda35@gmail.at");
            addIndividual("Al", "Bino", "Austria", 2135, "Gartengasse", 12, "+43 664 798852", "al.bino@gmail.at");
            addIndividual("Bill", "Ding", "Austria", 3353, "Trefflinggasse", 83, "+43 664 123456", "bill.ding@gmail.at");
            addIndividual("Cara", "Van", "Austria", 9900, "Adolf-Pichler-Platz", 3, "+43 664 789523", "cara.vab@gmail.at");
            addIndividual("D.", "Liver", "Austria", 6991, "Weinberggasse", 17, "+43 660 567132", "d.liver@gmail.at");
            addIndividual("Don", "Key", "Austria", 7000, "Burgstallgasse", 88, "+43 664 632121", "don.key@gmail.at");
            addIndividual("Earl Lee", "Riser", "Austria", 9872, "Sandgrube", 13, "+43 664 897124", "earllee.riser@gmail.at");
            addIndividual("Jack", "Pott", "Austria", 8523, "Bozener Gasse", 101, "+43 660 112354", "jack.pot@gmail.at");
            addIndividual("Lucy", "Fer", "Austria", 1170, "Buchenweg", 122, "+43 660 238412", "lucy.fer@gmail.at");
            addIndividual("Fiona", "Schreck", "Austria", 3324, "Buchenweg", 16, "+43 660 267951", "fiona.schreck@gmail.at");
            addIndividual("Al", "Dente", "Austria", 2210, "Am Waldrand", 77, "+43 660 197252", "al.dente@outlook.at");
            addIndividual("Anna", "MixMax", "Austria", 3390, "Am Waldweg", 65, "+43 660 199672", "anna.mixmax@gmail.at");
            addIndividual("Marina", "MixMax", "Austria", 3390, "Unter der Eiche", 5, "+43 660 389314", "marina.mixmax@gmail.at");

            foreach (Triple t in g.Triples)
            {
                Console.WriteLine(t.ToString());
            }

            RdfXmlWriter rdfxmlwriter = new RdfXmlWriter();
            rdfxmlwriter.Save(g, "PhoneBook.rdf");

        }

        private void addIndividual(string firstNameVal, string lastNameVal, string countryVal, int postalCodeVal, string streetVal, int streetNoVal, string phoneNoVal, string emailVal)
        {
            IUriNode entryIndividual = g.CreateUriNode("exi:person" + currentFreeId);
            currentFreeId++;
            IUriNode PersonPhoneBookEntry = g.CreateUriNode("exv:PersonPhoneBookEntry");
            IUriNode Person = g.CreateUriNode("exv:Person");
            IUriNode a = g.CreateUriNode("rdf:type");
            IUriNode represents = g.CreateUriNode("exv:represents");
            IUriNode firstName = g.CreateUriNode("exv:firstName");
            IUriNode lastName = g.CreateUriNode("exv:lastName");
            IUriNode country = g.CreateUriNode("exv:country");
            IUriNode postalCode = g.CreateUriNode("exv:postalCode");
            IUriNode street = g.CreateUriNode("exv:street");
            IUriNode streetNo = g.CreateUriNode("exv:streetNo");
            IUriNode email = g.CreateUriNode("exv:email");
            IUriNode phoneNo = g.CreateUriNode("exv:phoneNo");

            g.Assert(new Triple(entryIndividual, a, PersonPhoneBookEntry));
            g.Assert(new Triple(entryIndividual, represents, Person));
            g.Assert(new Triple(entryIndividual, firstName, g.CreateLiteralNode(firstNameVal)));
            g.Assert(new Triple(entryIndividual, lastName, g.CreateLiteralNode(lastNameVal)));
            g.Assert(new Triple(entryIndividual, country, g.CreateLiteralNode(countryVal)));
            g.Assert(new Triple(entryIndividual, postalCode, g.CreateLiteralNode(postalCodeVal.ToString(), UriFactory.Create(XmlSpecsHelper.XmlSchemaDataTypeInteger))));
            g.Assert(new Triple(entryIndividual, street, g.CreateLiteralNode(streetVal)));
            g.Assert(new Triple(entryIndividual, streetNo, g.CreateLiteralNode(streetNoVal.ToString(), UriFactory.Create(XmlSpecsHelper.XmlSchemaDataTypeInteger))));
            g.Assert(new Triple(entryIndividual, email, g.CreateLiteralNode(emailVal)));
            g.Assert(new Triple(entryIndividual, phoneNo, g.CreateLiteralNode(phoneNoVal)));
        }

        public List<PersonPhoneBookEntry> getEntries()
        {
            //First we need an instance of the SparqlQueryParser
            SparqlQueryParser parser = new SparqlQueryParser();

            //Then we can parse a SPARQL string into a query
            string prefixes = "PREFIX exv:<http://example.org/vocabulary/> PREFIX exi:<http://example.org/instances/> PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd:<http://www.w3.org/2001/XMLSchema#> PREFIX owl:<http://www.w3.org/2002/07/owl#>";
            SparqlQuery q = parser.ParseFromString(prefixes + " SELECT ?PersonPhoneBookEntry ?firstName ?lastName ?email ?phoneNo ?country ?postalCode ?street ?streetNo WHERE { ?PersonPhoneBookEntry rdf:type exv:PersonPhoneBookEntry. ?PersonPhoneBookEntry exv:firstName ?firstName. ?PersonPhoneBookEntry exv:lastName ?lastName. ?PersonPhoneBookEntry exv:phoneNo ?phoneNo. ?PersonPhoneBookEntry exv:email ?email. ?PersonPhoneBookEntry exv:country ?country. ?PersonPhoneBookEntry exv:postalCode ?postalCode. ?PersonPhoneBookEntry exv:street ?street. ?PersonPhoneBookEntry exv:streetNo ?streetNo.}");
            ISparqlDataset ds = new InMemoryDataset(g);
            LeviathanQueryProcessor processor = new LeviathanQueryProcessor(ds);
            Object results = processor.ProcessQuery(q);

            //Turn result into List of Row-Dictionaries
            List<PersonPhoneBookEntry> resultRows = new List<PersonPhoneBookEntry>();
            foreach (SparqlResult result in (SparqlResultSet)results)
            {
                PersonPhoneBookEntry resultModel = new PersonPhoneBookEntry();
                resultModel.FirstName = getValueOfINode(result["firstName"]);
                resultModel.LastName = getValueOfINode(result["lastName"]);
                resultModel.EmailAdress = getValueOfINode(result["email"]);
                resultModel.PhoneNumber = getValueOfINode(result["phoneNo"]);
                resultModel.State = getValueOfINode(result["country"]);
                resultModel.PostalCode = Int32.Parse(getValueOfINode(result["postalCode"]));
                resultModel.StreetName = getValueOfINode(result["street"]);
                resultModel.StreetNo = Int32.Parse(getValueOfINode(result["streetNo"]));
                
                resultRows.Add(resultModel);
                System.Diagnostics.Debug.WriteLine(result.ToString());
            }
            return resultRows;
        }

        private string getValueOfINode(INode node)
        {
            String text;
            switch (node.NodeType)
            {
                case NodeType.Literal:
                    // Cast to more specific ILiteralNode in order to extract just the value
                    ILiteralNode lit = (ILiteralNode)node;
                    text = lit.Value;
                    break;

                case NodeType.Uri:
                    // Case to more specific IUriNode in order to extract final segment of URI
                    IUriNode uri = (IUriNode)node;

                    // Depending on the URI format this might be in the Fragment, 
                    // the last Path Segment or just the URI
                    text = !String.IsNullOrEmpty(uri.Uri.Fragment) ? uri.Uri.Fragment : (uri.Uri.Segments.Length > 0 ? uri.Uri.Segments[uri.Uri.Segments.Length - 1] : uri.Uri.ToString());
                    break;

                default:
                    // For anything else default to ToString()
                    text = node.ToString();
                    break;
            }
            return text;
        }

        public List<PersonPhoneBookEntry> getEntriesBy(string SearchFirstName, string SearchLastName, string SearchEmailAddress, string SearchPostalCode, string SearchStreetName, string SearchStreetNumber)
        {
            //First we need an instance of the SparqlQueryParser
            SparqlQueryParser parser = new SparqlQueryParser();

            //Then we can parse a SPARQL string into a query
            string prefixes = "PREFIX exv:<http://example.org/vocabulary/> PREFIX exi:<http://example.org/instances/> PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd:<http://www.w3.org/2001/XMLSchema#> PREFIX owl:<http://www.w3.org/2002/07/owl#>";
            string stringtype = "\"^^xsd:string.";
            string inttype = "\"^^xsd:integer.";
            string querySelect = prefixes + "SELECT ?PersonPhoneBookEntry ?firstName ?lastName ?email ?phoneNo ?country ?postalCode ?street ?streetNo ";
            string queryWhere = " WHERE { ?PersonPhoneBookEntry rdf:type exv:PersonPhoneBookEntry.";

            queryWhere += " ?PersonPhoneBookEntry exv:firstName ?firstName.";
            if (SearchFirstName != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:firstName \"" + SearchFirstName + stringtype;
            }

            queryWhere += " ?PersonPhoneBookEntry exv:lastName ?lastName.";
            if (SearchLastName != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:lastName \"" + SearchLastName + stringtype;
            }

            queryWhere += " ?PersonPhoneBookEntry exv:email ?email.";
            if (SearchEmailAddress != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:email \"" + SearchEmailAddress + stringtype;
            }

            queryWhere += " ?PersonPhoneBookEntry exv:phoneNo ?phoneNo.";
            /*if (SearchEmailAddress != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:phoneNo \"" + SearchEmailAddress + stringtype;
            }*/
            queryWhere += " ?PersonPhoneBookEntry exv:country ?country.";

            queryWhere += " ?PersonPhoneBookEntry exv:postalCode ?postalCode.";
            if (SearchPostalCode != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:postalCode \"" + SearchPostalCode + inttype;
            }
            
            queryWhere += " ?PersonPhoneBookEntry exv:street ?street.";
            if (SearchStreetName != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:street \"" + SearchStreetName + stringtype;
            }
            
            queryWhere += " ?PersonPhoneBookEntry exv:streetNo ?streetNo.";
            if (SearchStreetNumber != null)
            {
                queryWhere += " ?PersonPhoneBookEntry exv:streetNo \"" + SearchStreetNumber + inttype;
            }

            SparqlQuery q = parser.ParseFromString(querySelect + queryWhere + "}");
            //SparqlQuery q = parser.ParseFromString(prefixes + " SELECT ?PersonPhoneBookEntry ?firstName ?lastName ?email ?phoneNo ?country ?postalCode ?street ?streetNo WHERE { ?PersonPhoneBookEntry rdf:type exv:PersonPhoneBookEntry. ?PersonPhoneBookEntry exv:lastName ?lastName. ?PersonPhoneBookEntry exv:firstName ?firstName. ?PersonPhoneBookEntry exv:lastName \"" + SearchLastName + stringtype + ". ?PersonPhoneBookEntry exv:phoneNo ?phoneNo. ?PersonPhoneBookEntry exv:email ?email. ?PersonPhoneBookEntry exv:country ?country. ?PersonPhoneBookEntry exv:postalCode ?postalCode. ?PersonPhoneBookEntry exv:street ?street. ?PersonPhoneBookEntry exv:streetNo ?streetNo.}");
            ISparqlDataset ds = new InMemoryDataset(g);
            LeviathanQueryProcessor processor = new LeviathanQueryProcessor(ds);
            Object results = processor.ProcessQuery(q);

            //Turn result into List of Row-Dictionaries
            List<PersonPhoneBookEntry> resultRows = new List<PersonPhoneBookEntry>();
            foreach (SparqlResult result in (SparqlResultSet)results)
            {
                PersonPhoneBookEntry resultModel = new PersonPhoneBookEntry();
                resultModel.FirstName = getValueOfINode(result["firstName"]);
                resultModel.LastName = getValueOfINode(result["lastName"]);
                resultModel.EmailAdress = getValueOfINode(result["email"]);
                resultModel.PhoneNumber = getValueOfINode(result["phoneNo"]);
                resultModel.State = getValueOfINode(result["country"]);
                resultModel.PostalCode = Int32.Parse(getValueOfINode(result["postalCode"]));
                resultModel.StreetName = getValueOfINode(result["street"]);
                resultModel.StreetNo = Int32.Parse(getValueOfINode(result["streetNo"]));

                resultRows.Add(resultModel);
                System.Diagnostics.Debug.WriteLine(result.ToString());
            }
            return resultRows;
        }
    }
}
