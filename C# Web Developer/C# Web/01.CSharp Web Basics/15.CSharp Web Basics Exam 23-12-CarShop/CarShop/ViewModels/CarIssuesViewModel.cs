namespace CarShop.ViewModels
{
    public class CarIssuesViewModel
    {
        public bool IsAuthenticated { get; set; } = true;

        public string CarId { get; set; }

        public string Year { get; set; }

        public string Model { get; set; }
    }
}