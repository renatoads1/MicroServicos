namespace AulaMSFront.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

        public string SubstringName() { 
        
            if (Name.Length > 20)
            {
                return Name.Substring(0, 20) + "...";
            }
            return Name;
        }
        public string SubstringDescription()
        {
            if (Description.Length > 50)
            {
                return Description.Substring(0, 50) + "...";
            }
            return Description;
        }
    }
}
