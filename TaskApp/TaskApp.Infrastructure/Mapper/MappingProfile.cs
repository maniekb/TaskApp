using AutoMapper;
using TaskApp.Domain.Entities;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserTask, UserTaskDTO>();
            CreateMap<UserTaskDTO, UserTask>();
            CreateMap<TaskGroup, TaskGroupDTO>();
            CreateMap<TaskGroupDTO, TaskGroup>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
