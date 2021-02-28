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
    public class StatusController : Controller
    {
        private readonly IStatusBLL _statusBll;
        bool _status;

        public StatusController(IStatusBLL statusBll)
        {
            _statusBll = statusBll;
        }

        [HttpGet]
        public List<Status> GetAccessoriesTypes()
        {
            List<Status> _status = _statusBll.Get();
            return _status;
        }

        [HttpGet("{Id}")]
        public Status GetAccessoriesTypebyId(int id)
        {
            Status _status = _statusBll.GetStatusbyId(id);
            return _status;
        }

        [HttpPost]
        public bool InsertAccessoriesType([FromBody] Status status)
        {
            _status = _statusBll.InsertStatus(status.TransactionStatus);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteAccessoriesType(int id)
        {
            _status = _statusBll.DeleteStatus(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateAccessoriesType(int id, [FromBody] Status status)
        {
            _status = _statusBll.UpdateStatus(status.TransactionStatus, id);
            return _status;
        }
    }
}
