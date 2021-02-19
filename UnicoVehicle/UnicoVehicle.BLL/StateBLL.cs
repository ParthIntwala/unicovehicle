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

        public List<State> get()
        {
            List<State> _states = _stateDAL.getState();

            foreach(State state in _states)
            {
                Country country = _countryDAL.getCountrybyId(state.CountryName.CountryId);
                state.CountryName = country;
            }

            return _states;
        }

        public State getStatebyId(int id)
        {
            State _state = _stateDAL.getStatebyId(id);

            Country country = _countryDAL.getCountrybyId(_state.CountryName.CountryId);
            _state.CountryName = country;

            return _state;
        }

        public bool insertState(string state, int countryId)
        {
            _status = _stateDAL.insertState(state, countryId);
            return _status;
        }

        public bool deleteState(int id)
        {
            _status = _stateDAL.deleteState(id);
            return _status;
        }
    }
}
