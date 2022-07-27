using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BLL.Interfaces;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBlTaskServicer businessLogic;

        public HomeController(IMapper mapper, IBlTaskServicer blServicer)
        {
            businessLogic = blServicer;
            this.mapper = mapper;
            businessLogic.Mapper = this.mapper;

        }

        // TODO: Set load folders in layout layer, not an index
        public IActionResult Index()
        {
            //TaskAndFolder taskAndFolder = new();

            //IEnumerable<PL.Models.Folder> folders = mapper.Map<IEnumerable<PL.Models.Folder>>(businessLogic.GetFolders());
            //taskAndFolder.Folders = folders;
            return View(/*taskAndFolder*/);
        }
    }
}
