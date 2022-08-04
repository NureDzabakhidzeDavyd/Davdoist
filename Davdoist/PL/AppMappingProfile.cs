using AutoMapper;

namespace BLL
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DAL.Entities.ToDoTask, BLL.Entities.ToDoTask>().ReverseMap();
            CreateMap<BLL.Entities.ToDoTask, PL.Models.ToDoTask>().ReverseMap();
            CreateMap<DAL.Entities.Folder, BLL.Entities.Folder>().ReverseMap();
            CreateMap<BLL.Entities.Folder, PL.Models.Folder>().ReverseMap();

        }
    }
}
