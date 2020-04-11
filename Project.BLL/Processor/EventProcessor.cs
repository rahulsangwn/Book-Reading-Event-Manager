using Project.DAL;
using System.Linq;
using AutoMapper;
using Project.BLL.UserModel;
using Project.DAL.Data;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Project.BLL.Processor
{
    public class EventProcessor
    {
        RecordContext _context = new RecordContext();
        
        //------------------------Methods for Mapping-----------------------------------------------
        
        /// <summary>
        /// Automapping of Event to EventEntity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public EventEntity EventToEventEntity(Event source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventEntity>()
                    .ForMember(dest => dest.Comments, act => act.Ignore());
            });

            //IMapper mapper = config.CreateMapper();
            var mapper = new Mapper(config);
            return mapper.Map<Event, EventEntity>(source);
        }

        /// <summary>
        /// Automapping of EventEntity to Event
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Event EventEntityToEvent(EventEntity source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventEntity, Event>().
                    ForMember(dest => dest.Comments, act => act.Ignore());
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<EventEntity, Event>(source);
        }

        //----------------------For CURD operations on events------------------------------------------

        /// <summary>
        /// Get EventEntity type object based on event Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EventEntity GetEvent(int Id)
        {
            var evnt = _context.Events.FirstOrDefault(s => s.EventId == Id);
            return EventToEventEntity(evnt);
        }

        /// <summary>
        /// Inserting a event in database
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns></returns>
        public int CreateEvent(EventEntity evnt)
        {
            Event myEvent = EventEntityToEvent(evnt);
            _context.Events.Add(myEvent);
            _context.SaveChanges();

            return myEvent.EventId; // Return Id of newly generated event
        }

        /// <summary>
        /// Updating an event
        /// </summary>
        /// <param name="evnt"></param>
        public void UpdateEvent(EventEntity evnt)
        {
            var obj = _context.Events.First(e => e.EventId == evnt.EventId);

            obj.Title       = evnt.Title;
            obj.Location    = evnt.Location;
            obj.Date        = evnt.StartTime.Date;
            obj.StartTime   = evnt.StartTime;
            obj.Duration    = evnt.Duration;
            obj.Description = evnt.Description;
            obj.Type        = evnt.Type;
            obj.Others      = evnt.Others;

            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// To get list of all Events in EventEntity type
        /// </summary>
        /// <param name="email"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        public IList<EventEntity> GetAll(string email, bool admin)
        {
            var _econtext = _context.Events;
            var temp = !admin ? _econtext.Where(s => s.Email == email).ToList() : _econtext.ToList();
            List<EventEntity> result = new List<EventEntity>();
            foreach(var evnt in temp)
            {
                result.Add(EventToEventEntity(evnt));
            }

            List<EventEntity> sortedResult = result.OrderByDescending(d => d.StartTime).ToList();
            return sortedResult;
        }

        /// <summary>
        /// To get list of all public events
        /// </summary>
        /// <returns></returns>
        public IList<EventEntity> GetPublicAll()
        {
            var temp = _context.Events.Where(s => s.Type == "Public").ToList();
            List<EventEntity> result = new List<EventEntity>();
            foreach (var evnt in temp)
            {
                result.Add(EventToEventEntity(evnt));
            }

            return result;
        }
    }
}
