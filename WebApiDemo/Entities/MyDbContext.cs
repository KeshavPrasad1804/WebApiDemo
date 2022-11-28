using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Entities
{
    public class MyDbContext:DbContext
    {
        public DbSet<City>Cities { get; set; }
        public DbSet<Multiplex> Multiplexes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShows> MovieShows { get; set; }
        public DbSet<User> User { get; set; }
        public MyDbContext(DbContextOptions opts) : base(opts)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Multiplex>()
           .HasOne<City>(s => s.c)
           .WithMany()
           .HasForeignKey(s => s.CID)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class Multiplex
    {
        [Key]
        public int MultiplexID { get; set; }
        [Required]
        public string MultiplexName { get; set; }
        [Required]
        public int Screens { get; set; }

        public int CID { get; set; }
        [ForeignKey("CID")]
        public City c { get; set; }
    }

    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public int PlayLength { get; set; }
    }

    public class MovieShows
    {
        public int MovID { get; set; }
        [Key]
        public int ShowID { get; set; }

        public int MulID { get; set; }
        [ForeignKey("MulID")]
        public Multiplex multiplex { get; set; }
        [ForeignKey("MovID")]
        public Movie movie { get; set; }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
    }
}
