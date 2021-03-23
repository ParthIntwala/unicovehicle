﻿using System;
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
    public class VehicleController : Controller
    {
        private readonly IVehicleBLL _vehicleBll;
        bool _status;

        public VehicleController(IVehicleBLL vehicleBLL)
        {
            _vehicleBll = vehicleBLL;
        }

        [HttpGet("{id}")]
        public Vehicle GetVehiclebyId(int id)
        {
            Vehicle vehicle = _vehicleBll.GetVehiclebyId(id);
            return vehicle;
        }

        [HttpPost]
        public bool InsertVehicle([FromBody] Vehicle vehicle)
        {
            _status = _vehicleBll.InsertVehicle(vehicle);
            return _status;
        }

        [HttpDelete("{id}")]
        public bool DeleteVehicle(int id)
        {
            _status = _vehicleBll.DeleteVehicle(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateVehicle([FromBody] Vehicle vehicle, int id)
        {
            _status = _vehicleBll.UpdateVehicle(vehicle, id);
            return _status;
        }
    }
}
