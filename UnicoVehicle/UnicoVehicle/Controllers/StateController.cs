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
            List<State> _allStates = _stateBll.Get();
            return _allStates;
        }

        [HttpGet("{Id}")]
        public State GetStatesbyId(int id)
        {
            State _state = _stateBll.GetStatebyId(id);
            return _state;
        }

        [HttpPost]
        public bool InsertState([FromBody] State state)
        {
            _status = _stateBll.InsertState(state.StateName, state.CountryName.CountryId);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteState(int id)
        {
            _status = _stateBll.DeleteState(id);
            return _status;
        }
    }
}
