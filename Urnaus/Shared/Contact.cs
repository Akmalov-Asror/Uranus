namespace Urnaus.Shared
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string DateTime { get; set; }
    }
}
