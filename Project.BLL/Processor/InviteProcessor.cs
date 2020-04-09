using AutoMapper;
using Project.BLL.UserModel;
using Project.DAL;
using Project.DAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Processor
{
    public class InviteProcessor
    {
        RecordContext _context = new RecordContext();

        public InviteEntity InviteToInviteEntity(Invite source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invite, InviteEntity>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Invite, InviteEntity>(source);
        }

        public List<InviteEntity> GetAllInvitedUsers(string email)
        {
            List<InviteEntity> inviteEntityList = new List<InviteEntity>();
            var tempList = _context.Invites.Where(e => e.Email == email).ToList();
            foreach(var item in tempList)
            {
                InviteEntity inviteEntity = InviteToInviteEntity(item);
                var evnt = _context.Events.First(s => s.EventId == item.EventId);
                inviteEntity.Title = evnt.Title;
                inviteEntity.EventDate = evnt.StartTime;
                inviteEntityList.Add(inviteEntity);
            }
            return inviteEntityList;
        }

        public bool CreateInvitation(string email, int eventId)
        {
            string[] emails = email.Split(',');
            for(int i = 0; i < emails.Length; i++)
            {
                emails[i] = emails[i].Trim();
            }

            foreach(var item in emails)
            {
                if (_context.Users.Any(s => s.Email == item))
                {
                    Invite invite = new Invite() { Email = item, EventId = eventId };
                    _context.Invites.Add(invite);
                    _context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsInvitedUser(string email, int eventId)
        {
            return _context.Invites.Any(e => (e.Email == email) && (e.EventId == eventId));
        }

        public int InvitedUsersCount(int eventId)
        {
            return _context.Invites.Count(e => e.EventId == eventId);
        }
    }
}
