namespace Project.DAL.Data
{
    public interface IUser
    {
        string Email { get; set; }
        string FullName { get; set; }
        string Password { get; set; }
    }
}