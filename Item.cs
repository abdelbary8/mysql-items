using System;

namespace MySQLbase
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int CatId { get; set; }
        public int PrinterId { get; set; }

        public virtual Category category { set; get; }
        public virtual Printer printer { set; get; }

    }
}
