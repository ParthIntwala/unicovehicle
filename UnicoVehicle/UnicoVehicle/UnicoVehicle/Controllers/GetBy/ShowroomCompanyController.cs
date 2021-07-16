using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowroomCompanyController : Controller
    {
        private readonly IShowroomBLL _showroomBll;

        public ShowroomCompanyController(IShowroomBLL showroomBll)
        {
            _showroomBll = showroomBll;
        }

        [HttpGet("{Id}")]
        public List<Showroom> GetShowroombyCompany(int Id)
        {
            List<Showroom> _showroom = _showroomBll.GetCompany(Id);
            return _showroom;
        }
    }
}
