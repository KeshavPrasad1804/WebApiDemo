using System.ComponentModel.DataAnnotations;

namespace WebApiDemo
{
    public class MovieShowsDTO
    {
        public int ShowID { get; set; }
        [Required]
        public int MovID { get; set; }        
       
        [Required]
        public int MulID { get; set; }
    }
}
