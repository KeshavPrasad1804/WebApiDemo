using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public class MultiplexRepoImpl : IMultiplex
    {
        MyDbContext context = null;
        public MultiplexRepoImpl(MyDbContext ctx)
        {
            context = ctx;
        }
        public bool Add(MultiplexDTO multiplex)
        {
            Multiplex m = new Multiplex();
            m.MultiplexName = multiplex.MulplexName;
            m.CID = multiplex.MulplexCID;
            context.Multiplexes.Add(m);
            return true;
        }

        public bool Delete(int id)
        {
            var res = (from c in context.Multiplexes
                       where c.MultiplexID == id
                       select c).FirstOrDefault();
            if (res != null)
            {
                context.Multiplexes.Remove(res);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MultiplexDTO> GetAll()
        {
            List<MultiplexDTO> list = new List<MultiplexDTO>();
            var res = from c in context.Multiplexes
                      select c;
            foreach (var item in res)
            {
                MultiplexDTO dto = new MultiplexDTO();
                dto.MulplexID = item.MultiplexID;
                dto.MulplexName = item.MultiplexName;
                dto.MulplexScreens = item.Screens;
                dto.MulplexCID = item.CID;
                list.Add(dto);
            }
            return list;
        }

        public bool Update(MultiplexDTO multiplex)
        {
            var res = (from c in context.Multiplexes
                       where c.MultiplexID == multiplex.MulplexID
                       select c).FirstOrDefault();

            if (res != null)
            {
                res.MultiplexName = multiplex.MulplexName;
                res.Screens = multiplex.MulplexScreens;
                res.CID=multiplex.MulplexCID;
               
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
