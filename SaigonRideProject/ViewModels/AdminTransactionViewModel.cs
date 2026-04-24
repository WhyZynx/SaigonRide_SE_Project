namespace SaigonRideProject.ViewModels 
{    public class AdminTransactionViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }
        public string Method { get; set; } 

        public DateTime CreatedAt { get; set; }
    }

}

