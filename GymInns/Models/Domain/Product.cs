namespace GymInns.Models.Domain
{
    public class Product
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string image { get; set; }

        public string categories { get; set; }

    }
}
