using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public class CityRepoImpl : ICityRepo
    {
        MyDbContext context = null;
        public CityRepoImpl(MyDbContext ctx)
        {
            context = ctx;
        }

        public bool Add(CityDTO city)
        {
          City c=new City();
            c.Name = city.CityName;
            context.Cities.Add(c);
            return true;
        }

        public bool Delete(int id)
        {
            var res = (from c in context.Cities
                       where c.CityId == id
                       select c).FirstOrDefault();
            if (res != null)
            {
                context.Cities.Remove(res);
                return true;
            }
            else
            {
                return false;
            }
         }

        public List<CityDTO> GetAll()
        {
            List<CityDTO> list = new List<CityDTO>();
            var res = from c in context.Cities
                      select c;
            foreach (var item in res)
            {
                CityDTO dto = new CityDTO();
                dto.CID = item.CityId;
                dto.CityName = item.Name;
                list.Add(dto);
            }
            return list;
        }

        public bool Update(CityDTO city)
        {
            var res = (from c in context.Cities
                       where c.CityId == city.CID
                       select c).FirstOrDefault();

            if (res != null)
            {
                res.Name = city.CityName;
                //context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
