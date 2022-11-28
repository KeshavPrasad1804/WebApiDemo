using System.ComponentModel.DataAnnotations;

namespace WebApiDemo
{
    public class CityDTO
    {
        public int CID { get; set; }
        [Required]
        [StringLength(10)]
        public string CityName { get; set; }
    }
    public class LoginDTO
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
