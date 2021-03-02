using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class StateBLL : IStateBLL
    {
        private readonly IStateDAL _stateDAL;
        private readonly ICountryDAL _countryDAL;
        bool _status;

        public StateBLL(IStateDAL stateDAL, ICountryDAL countryDAL)
        {
            _stateDAL = stateDAL;
            _countryDAL = countryDAL;
        }

        public List<State> Get()
        {
            List<State> _states = _stateDAL.GetState();

            foreach(State state in _states)
            {
                Country country = _countryDAL.GetCountrybyId(state.CountryName.CountryId);
                state.CountryName = country;
            }

            return _states;
        }

        public State GetStatebyId(int id)
        {
            State _state = _stateDAL.GetStatebyId(id);

            if(_state.StateId != 0)
            {
                _state.CountryName = _countryDAL.GetCountrybyId(_state.CountryName.CountryId);
            }
                
            return _state;
        }

        public bool InsertState(string state, int countryId)
        {
            _status = _stateDAL.InsertState(state, countryId);
            return _status;
        }

        public bool DeleteState(int id)
        {
            _status = _stateDAL.DeleteState(id);
            return _status;
        }
    }
}
