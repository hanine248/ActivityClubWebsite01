namespace ActivityClub.API.Requests
{
    public class LoginRequest
    {
        public int Userid { get; set; }
        public string? Password { get; set; }
        public int Roleid { get; set; } 
    }
}
