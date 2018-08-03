namespace TA.MVC.Models
{
    public class Order
    {
        public decimal TotalSum { get; set; }
        public int ProductsCount { get; set; }
        public bool MayHaveIssues { get; set; }
    }
}