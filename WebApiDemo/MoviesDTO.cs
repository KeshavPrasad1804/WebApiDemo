using System.ComponentModel.DataAnnotations;

namespace WebApiDemo
{
    public class MoviesDTO
    {
        public int MID { get; set; }
        [Required]
        public string MName { get; set; }
        [Required]
        public int MPlayLength { get; set; }
    }
}
