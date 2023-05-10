namespace MyFirstAPI.Models {
    public class User {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool HasACat { get; set; }

        public DateTime DOB { get; set; }

    }
}
