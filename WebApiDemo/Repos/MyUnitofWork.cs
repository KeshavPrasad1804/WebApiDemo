using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public class MyUnitofWork
    {
        MyDbContext context = null;
        private ICityRepo cityRepo = null;
        private IMultiplex multiplexRepo = null;
        private IMovie movieRepo = null;
        private IMovieShows movieShowsRepo = null;
        private IUser userRepo = null;
        public MyUnitofWork(MyDbContext ctx)
        {
            context = ctx;
        }

        public ICityRepo CityRepo
        {
            get
            {
                if (cityRepo == null)
                {
                    cityRepo = new CityRepoImpl(context);
                }
                return cityRepo;
            }
        }
        public IMultiplex MultiplexRepo
        {
            get
            {
                if (multiplexRepo == null)
                {
                    multiplexRepo = new MultiplexRepoImpl(context);
                }
                return multiplexRepo;
            }
        }
        public IMovie MovieRepo
        {
            get
            {
                if (movieRepo == null)
                {
                    movieRepo = new MovisRepoImpl(context);
                }
                return movieRepo;
            }
        }
        public IMovieShows MovieShowsRepo
        {
            get
            {
                if (movieShowsRepo == null)
                {
                    movieShowsRepo = new MovieShowsRepoImpl(context);
                }
                return movieShowsRepo;
            }
        } 
        public IUser UserRepo
        {
            get
            {
                if (userRepo == null)
                {
                    userRepo = new UserRepoImpl(context);
                }
                return userRepo;
            }
        }

        public bool SaveAll()
        {
            context.SaveChanges();
            return true;
        }

    }
}
