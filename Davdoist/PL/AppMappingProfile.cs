using AutoMapper;

namespace BLL
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DAL.Entities.ToDoTask, BLL.Entities.ToDoTask>();
            CreateMap<DAL.Entities.Folder, BLL.Entities.Folder>();
            CreateMap<BLL.Entities.Folder, PL.Models.Folder>();
            CreateMap<BLL.Entities.ToDoTask, PL.Models.ToDoTask>();

        }
    }
}
