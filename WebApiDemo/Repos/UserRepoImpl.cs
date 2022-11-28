using WebApiDemo.Entities;

namespace WebApiDemo.Repos
{
    public class UserRepoImpl : IUser
    {
        MyDbContext context = null;
        public UserRepoImpl(MyDbContext ctx)
        {
            context = ctx;
        }
        public bool Login(LoginDTO login)
        {
            if (login == null)
                return false;
            else
            {
                var res = (from c in context.User
                           where c.Phone == login.Phone
                           select c).FirstOrDefault();
                if (res == null)
                {
                    return false;
                }
                else
                {
                    if (res.Password == login.Password)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }


                }
            }
        }

        public bool Register(User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                context.User.Add(user);
                return true;
            }
        }
    }
}
