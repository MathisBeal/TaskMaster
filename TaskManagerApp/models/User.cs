using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp
{
    public class User
    {
        [Key] 
        public int idUsers { get; set; }

        [StringLength(45)]
        public string email { get; set; }

        [StringLength(45)]
        public string password { get; set; }

        [StringLength(45)]
        public string nom { get; set; }
        
        [StringLength(45)]
        public string prenom { get; set; }
    }
}
