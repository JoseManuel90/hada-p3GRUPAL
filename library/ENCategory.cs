namespace library
{
    public class ENCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ENCategory() { }

        public ENCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
