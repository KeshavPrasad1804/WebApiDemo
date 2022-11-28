using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public interface IUser
    {
        bool Register(User user);
        bool Login(LoginDTO login);
    }
}
