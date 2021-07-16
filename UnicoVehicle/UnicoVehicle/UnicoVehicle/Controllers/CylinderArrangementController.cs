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
    public class CylinderArrangementController : Controller
    {
        private readonly ICylinderArrangementBLL _cylinderArrangementBll;
        bool _status;

        public CylinderArrangementController(ICylinderArrangementBLL cylinderArrangementBll)
        {
            _cylinderArrangementBll = cylinderArrangementBll;
        }

        [HttpGet]
        public List<CylinderArrangement> GetCylinderArrangement()
        {
            List<CylinderArrangement> _cylinderArrangement = _cylinderArrangementBll.Get();
            return _cylinderArrangement;
        }

        [HttpPost]
        public bool InsertCylinderArrangement([FromBody] CylinderArrangement cylinderArrangement)
        {
            _status = _cylinderArrangementBll.InsertCylinderArrangement(cylinderArrangement.CylinderArrangementName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteCylinderArrangement(int id)
        {
            _status = _cylinderArrangementBll.DeleteCylinderArrangement(id);
            return _status;
        }
    }
}
