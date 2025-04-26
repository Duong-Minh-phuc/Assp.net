namespace DuonMinhPhuc_2122110594.Model
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;

        // Một Brand có thể có nhiều Product
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
