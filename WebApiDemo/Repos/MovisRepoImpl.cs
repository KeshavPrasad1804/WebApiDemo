using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public class MovisRepoImpl : IMovie
    {
        MyDbContext context = null;
        public MovisRepoImpl(MyDbContext ctx)
        {
            context = ctx;
        }
        public bool Add(MoviesDTO movies)
        {
            Movie m = new Movie();
            m.MovieName = movies.MName;
            m.PlayLength = movies.MPlayLength;
            context.Movies.Add(m);
            return true;
        }

        public bool Delete(int id)
        {
            var res = (from c in context.Movies
                       where c.MovieID == id
                       select c).FirstOrDefault();
            if (res != null)
            {
                context.Movies.Remove(res);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MoviesDTO> GetAll()
        {
            List<MoviesDTO> list = new List<MoviesDTO>();
            var res = from c in context.Movies
                      select c;
            foreach (var item in res)
            {
                MoviesDTO dto = new MoviesDTO();
                dto.MID = item.MovieID;
                dto.MName = item.MovieName;
                dto.MPlayLength = item.PlayLength;
                list.Add(dto);
            }
            return list;
        }

        public bool Update(MoviesDTO movies)
        {
            var res = (from c in context.Movies
                       where c.MovieID == movies.MID
                       select c).FirstOrDefault();

            if (res != null)
            {
                
                res.MovieName = movies.MName;
                res.PlayLength = movies.MPlayLength;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
