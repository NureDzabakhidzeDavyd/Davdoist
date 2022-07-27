using AutoMapper;

namespace BLL.Interfaces
{
    public interface IBaseServicer
    {
        public IMapper Mapper { get; set; }
    }
}
