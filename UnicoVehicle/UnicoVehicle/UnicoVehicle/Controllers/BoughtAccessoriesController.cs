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
    public class BoughtAccessoriesController : Controller
    {
        private readonly IBoughtAccessoriesBLL _boughtAccessoriesBLL;
        bool _status;

        public BoughtAccessoriesController(IBoughtAccessoriesBLL boughtAccessoriesBLL)
        {
            _boughtAccessoriesBLL = boughtAccessoriesBLL;
        }

        [HttpGet("{Id}")]
        public List<BoughtAccessories> GetBoughtAccessoriesbyId(int id)
        {
            List<BoughtAccessories> boughtAccessories = _boughtAccessoriesBLL.GetbyId(id);
            return boughtAccessories;
        }

        [HttpPost("{Id}")]
        public bool InsertBoughtAccessories([FromBody] List<BoughtAccessories> boughtAccessories, int id)
        {
            _status = _boughtAccessoriesBLL.InsertPostBuyingDetail(boughtAccessories, id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateBoughtAccessories([FromBody] List<BoughtAccessories> boughtAccessories, int id)
        {
            _status = _boughtAccessoriesBLL.UpdatePostBuyingDetail(boughtAccessories, id);
            return _status;
        }
    }
}
