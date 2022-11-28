namespace WebApiDemo.Repos
{
    public interface ICityRepo
    {
        List<CityDTO> GetAll();
        bool Add(CityDTO city);
        bool Update(CityDTO city);
        bool Delete(int id);
    }
}
