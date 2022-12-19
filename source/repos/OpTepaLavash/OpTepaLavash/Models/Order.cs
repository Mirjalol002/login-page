namespace OpTepaLavash.Models
{
    //[Table("tables")]
    public class Order
    {
        //[Column("id")]
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public int ClinetId { get; set; }

        public virtual Client Client { get; set; }

        public int TotalSum { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime DateTime { get; set; }

        public Order()
        {
            Client = new Client();
            Employee = new Employee();
        }

        //public int OrderDetailId { get; set; }

        //public int ClientId { get; set; }
    }
}
