namespace library
{
    public class ENCategory
    {
        // Atributos privados 
        private int _id;
        private string _name;

        // Propiedades públicas 
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        // Constructores
        public ENCategory() { }

        public ENCategory(int id, string name)
        {
            _id = id;
            _name = name;
        }

        // Métodos 
        public bool Read()
        {
            CADCategory cad = new CADCategory();
            return cad.Read(this);
        }

        public static List<ENCategory> ReadAll()
        {
            return new CADCategory().ReadAll();
        }
    }
}