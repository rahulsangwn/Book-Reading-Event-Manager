using AutoMapper;
using Project.BLL.UserModel;
using Project.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventEntity>();
            CreateMap<EventEntity, Event>();
        }
    }
}
