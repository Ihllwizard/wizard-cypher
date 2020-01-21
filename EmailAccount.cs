namespace EmailSender
{
    public class EmailAccount
    {
        public string smtp { get; set; }
        public string username { get; set; }
        public bool isSSL { get; set; }
        public int port { get; set; }
        public string password { get; set; }
    }
}