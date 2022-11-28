using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public class MovieShowsRepoImpl : IMovieShows
    {
        MyDbContext context = null;
        public MovieShowsRepoImpl(MyDbContext ctx)
        {
            context = ctx;
        }
        public bool Add(MovieShowsDTO movieShows)
        {
            MovieShows m = new MovieShows();
            m.MulID = movieShows.MulID;
            m.MovID = movieShows.MovID;
           context.MovieShows.Add(m);
            return true;
        }

        public bool Delete(int id)
        {
            var res = (from c in context.MovieShows
                       where c.ShowID == id
                       select c).FirstOrDefault();
            if (res != null)
            {
                context.MovieShows.Remove(res);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MovieShowsDTO> GetAll()
        {
            List<MovieShowsDTO> list = new List<MovieShowsDTO>();
            var res = from c in context.MovieShows
                      select c;
            foreach (var item in res)
            {
                MovieShowsDTO dto = new MovieShowsDTO();
                dto.ShowID = item.ShowID;
                dto.MulID = item.MulID;
                dto.MovID = item.MovID;
                list.Add(dto);
            }
            return list;
        }

        public bool Update(MovieShowsDTO movieShows)
        {
            var res = (from c in context.MovieShows
                       where c.ShowID == movieShows.ShowID
                       select c).FirstOrDefault();

            if (res != null)
            {
                res.MovID = movieShows.MovID;
                res.MulID = movieShows.MulID;
              

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
