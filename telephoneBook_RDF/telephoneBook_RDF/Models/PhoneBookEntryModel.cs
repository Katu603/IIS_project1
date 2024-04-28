namespace telephoneBook_RDF.Models
{
    public class PhoneBookEntryModel
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? State { get; set; }
        public int? PostalCode { get; set; }
        public string? StreetName { get; set; }
        public int? StreetNo { get; set; }
        public string? EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        
        public PhoneBookEntryModel() {}
    }
}
