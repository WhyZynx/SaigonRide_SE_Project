namespace SaigonRideProject.ViewModels
{
    public class TopUpViewModel
    {
        public decimal Balance { get; set; }
        public List<string> Methods { get; set; } = new List<string>();

        public decimal Amount { get; set; }
        public string Method { get; set; } = string.Empty;
    }
}