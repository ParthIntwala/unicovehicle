using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : Controller
    {
        private readonly IStateBLL _stateBll;
        bool _status;

        public StateController(IStateBLL stateBll)
        {
            _stateBll = stateBll;
        }

        [HttpGet]
        public List<State> GetStates()
        {
            List<State> _allStates = _stateBll.get();
            return _allStates;
        }

        [HttpGet("{Id}")]
        public State GetCountriesbyId(int id)
        {
            State _country = _stateBll.getStatebyId(id);
            return _country;
        }

        [HttpPost]
        public bool insertCountry([FromBody] State state)
        {
            _status = _stateBll.insertState(state.StateName, state.CountryName.CountryId);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool deleteCountry(int id)
        {
            _status = _stateBll.deleteState(id);
            return _status;
        }
    }
}
