namespace ABM.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string DNI { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
    }

}
