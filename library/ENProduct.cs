using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int Category { get; set; }
        public DateTime CreationDate { get; set; }

        public ENProduct() { }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Category = category;
            this.CreationDate = creationDate;
        }

        public bool Create()
        {
            CADProduct cad = new CADProduct();
            return cad.Create(this);
        }

        public bool Update()
        {
            CADProduct cad = new CADProduct();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADProduct cad = new CADProduct();
            return cad.Delete(this);
        }

        public bool Read()
        {
            CADProduct cad = new CADProduct();
            return cad.Read(this);
        }

        public bool ReadFirst()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadFirst(this);
        }

        public bool ReadNext()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadNext(this);
        }

        public bool ReadPrev()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadPrev(this);
        }
    }
}