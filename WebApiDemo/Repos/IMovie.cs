namespace WebApiDemo.Repos
{
    public interface IMovie
    {
        List<MoviesDTO> GetAll();
        bool Add(MoviesDTO movies);
        bool Update(MoviesDTO movies);
        bool Delete(int id);
    }
}
