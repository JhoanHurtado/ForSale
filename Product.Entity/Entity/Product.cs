namespace Product.Entity.Entity
{
    public class Product
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Amount { get; set; }
        public string Picture { get; set; }

        ////Agregar campo CreateAut
        //public DateTime CreateAt { get; set; }
        ////Agregar campo UpdateAut
        //public DateTime UpdateAt { get; set; }

    }
}
