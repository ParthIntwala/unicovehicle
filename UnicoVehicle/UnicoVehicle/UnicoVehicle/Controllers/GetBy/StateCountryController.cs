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
    public class StateCountryController : Controller
    {
        private readonly IStateBLL _stateBll;

        public StateCountryController(IStateBLL stateBll)
        {
            _stateBll = stateBll;
        }

        [HttpGet("{id}")]
        public List<State> GetStatesbyCountry(int id)
        {
            List<State> _allStates = _stateBll.Get(id);
            return _allStates;
        }
    }
}
