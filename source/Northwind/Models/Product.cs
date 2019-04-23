namespace Northwind.Models
{
    public class Product
    {
        public int Id { get; }
        public double Price { get; }
        public string Name { get; }
		public string Description { get; }
		public string ImgUrl { get; }

        public Product(int id, double price, string name, string description, string img)
        {
            Id = id;
            Price = price;
            Name = name;
			Description = description;
			ImgUrl = img;
        }
    }
}