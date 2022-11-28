namespace WebApiDemo.Repos
{
    public interface IMultiplex
    {
        List<MultiplexDTO> GetAll();
        bool Add(MultiplexDTO multiplex);
        bool Update(MultiplexDTO multiplex);
        bool Delete(int id);
    }
}
