using AutoMapper;
using Project.BLL.UserModel;
using Project.DAL;
using Project.DAL.Data;
using System.Linq;

namespace Project.BLL.Processor
{
    public class UserProcessor
    {
        RecordContext _rc = new RecordContext();

        /// <summary>
        /// Automapping User to UserEntity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public UserEntity UserToUserEntity(User source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserEntity>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<User, UserEntity>(source);
        }

        /// <summary>
        /// Automapping UserEntity to User
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public User UserEntityToUser(UserEntity source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, User>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<UserEntity, User>(source);
        }

        /// <summary>
        /// For registering a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUser(UserEntity user)
        {
            var t = UserEntityToUser(user);

            if (_rc.Users.Any(u => u.Email == user.Email)) return false;

            _rc.Users.Add(UserEntityToUser(user));
            _rc.SaveChanges();

            return true;
        }

        /// <summary>
        /// For login validation
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidUser(UserEntity user)
        {
            return _rc.Users.Any(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}
