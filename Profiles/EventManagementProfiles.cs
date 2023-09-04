using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using AutoMapper;
using Event_management_System.Model;
using Event_management_System.Requests;
using Event_management_System.Responses;

namespace Event_management_System.Profiles
{
    public class EventManagementProfiles: Profile
    {
        public EventManagementProfiles(){
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<Event, AddEvent>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Event, UserEventsResponseDTO>().ReverseMap();
            CreateMap<Event, EventUserResponseDTO>().ReverseMap();
        }
    }
}