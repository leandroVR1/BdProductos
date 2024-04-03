namespace Bdproductos.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }

        // Propiedad de navegación para la relación con User
        public User? User { get; set; }


    }
}