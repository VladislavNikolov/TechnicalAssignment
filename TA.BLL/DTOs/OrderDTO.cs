namespace TA.BLL.DTOs
{
    public class OrderDTO
    {
        public decimal TotalSum { get; set; }

        public int ProductsCount { get; set; }

        public bool MayHaveIssues { get; set; }
    }
}
