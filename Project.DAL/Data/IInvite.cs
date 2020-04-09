namespace Project.DAL.Data
{
    public interface IInvite
    {
        string Email { get; set; }
        Event Event { get; set; }
        int EventId { get; set; }
        int InviteId { get; set; }
        User User { get; set; }
    }
}