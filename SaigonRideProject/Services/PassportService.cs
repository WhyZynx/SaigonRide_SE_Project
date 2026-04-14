namespace SaigonRideProject.Services
{
    public class PassportService
    {
        public bool Validate(string passportNumber)
        {
            return passportNumber.Length >= 6;
        }
    }
}
