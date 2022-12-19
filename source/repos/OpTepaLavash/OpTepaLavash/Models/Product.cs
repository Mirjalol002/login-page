namespace OpTepaLavash.Models
{
    //[Table("product")]
    public class Product
    {

        //[Column("id")]
        public int Id { get; set; }

        //[Column("name")]
        public string Name { get; set; } = string.Empty;

        //[Column("price")]
        public int Price { get; set; }


        //[Column("food")]
        //public Food Food { get; set; }

        //[Column("drink")]
        //public Drink Drink { get; set; }


    }
}
