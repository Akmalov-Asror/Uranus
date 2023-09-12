namespace Urnaus.Shared
{
    public class Test : IEntity
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public List<string> Options { get; set; }

        public string RightOption { get; set; }
    }
}
