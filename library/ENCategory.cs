namespace library
{
    public class ENCategory
    {
        // Atributos privados
        private int id;
        private string name;

        // Propiedades públicas con campos de respaldo
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Constructores
        public ENCategory() { }

        public ENCategory(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        // Métodos para acceso a datos
        public bool Read()
        {
            CADCategory cad = new CADCategory();
            return cad.Read(this);
        }

        public static List<ENCategory> ReadAll()
        {
            CADCategory cad = new CADCategory();
            return cad.ReadAll();
        }
    }
}