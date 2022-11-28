namespace WebApiDemo.Repos
{
    public interface IMovieShows
    {

        List<MovieShowsDTO> GetAll();
        bool Add(MovieShowsDTO movieShows);
        bool Update(MovieShowsDTO movieShows);
        bool Delete(int id);
    }
}
