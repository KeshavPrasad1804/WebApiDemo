using System.ComponentModel.DataAnnotations;

namespace WebApiDemo
{
    public class MultiplexDTO
    {
        public int MulplexID { get; set; }
        [Required]
        public string MulplexName { get; set; }
        [Required]
        public int MulplexScreens { get; set; }

        public int MulplexCID { get; set; }
    }
}
