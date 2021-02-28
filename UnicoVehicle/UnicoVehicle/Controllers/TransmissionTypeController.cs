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
    public class TransmissionTypeController : Controller
    {
        private readonly ITransmissionTypeBLL _transmissionTypeBll;
        bool _status;

        public TransmissionTypeController(ITransmissionTypeBLL transmissionTypeBll)
        {
            _transmissionTypeBll = transmissionTypeBll;
        }

        [HttpGet]
        public List<TransmissionType> GetTransmissionTypes()
        {
            List<TransmissionType> _alltransmissionType = _transmissionTypeBll.Get();
            return _alltransmissionType;
        }

        [HttpGet("{Id}")]
        public TransmissionType GetTransmissionTypebyId(int id)
        {
            TransmissionType _transmissionType = _transmissionTypeBll.GetTransmissionTypebyId(id);
            return _transmissionType;
        }

        [HttpPost]
        public bool Insert_alltransmissionType([FromBody] TransmissionType transmissionType)
        {
            _status = _transmissionTypeBll.InsertTransmissionType(transmissionType.GearTransmission);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteTransmissionType(int id)
        {
            _status = _transmissionTypeBll.DeleteTransmissionType(id);
            return _status;
        }
    }
}
