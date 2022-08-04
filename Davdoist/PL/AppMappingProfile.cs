using AutoMapper;
using System.Threading.Tasks;

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

            CreateMap<Task<DAL.Entities.ToDoTask>, Task<BLL.Entities.ToDoTask>>().ReverseMap();
            CreateMap<Task<BLL.Entities.ToDoTask>, Task<PL.Models.ToDoTask>>().ReverseMap();
            CreateMap<Task<DAL.Entities.Folder>,Task<BLL.Entities.Folder>>().ReverseMap();
            CreateMap<Task<BLL.Entities.Folder>, Task<PL.Models.Folder>>().ReverseMap();

        }
    }
}
