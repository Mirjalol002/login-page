namespace OpTepaLavash.Models
{
    //[Table("orderdetail")]
    public class OrderDetail
    {
        //[Column("id")]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int TableNamber { get; set; }  // bu yerda gu vaqtinchalik keyinroq o'chirib yuvoraman
        public int Count { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public OrderDetail()
        {
            Product = new Product();
            Order = new Order();
        }


        //public Drink Drink { get; set; }

        //public Food Food { get; set; }
    }
}
