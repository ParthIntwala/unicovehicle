using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class StateDAL : IStateDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _stateCommand;
        private SqlDataReader _stateReader;
        int _success;

        public StateDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<State> getState()
        {
            _stateCommand = _utils.CommandGenerator(DALResources.GetState);
            _stateReader = _stateCommand.ExecuteReader();

            State _state;
            List<State> _states = new List<State>();

            while (_stateReader.Read())
            {
                _state = new State()
                {
                    StateId = int.Parse(_stateReader["StateId"].ToString()),
                    StateName = _stateReader["State"].ToString(),
                    CountryName = new Country()
                    {
                        CountryId = int.Parse(_stateReader["CountryId"].ToString()),
                    },
                };

                _states.Add(_state);
            }

            _stateReader.Close();
            _connection.CloseConnection();

            return _states;
        }

        public State getStatebyId(int id)
        {
            _stateCommand = _utils.CommandGenerator(DALResources.GetStatebyId);
            _stateCommand.Parameters.AddWithValue("@stateId", id);
            _stateReader = _stateCommand.ExecuteReader();
            State _state = new State();

            while (_stateReader.Read())
            {
                _state = new State
                {
                    StateName = _stateReader["State"].ToString(),
                    StateId = id,
                    CountryName = new Country()
                    {
                        CountryId = int.Parse(_stateReader["CountryId"].ToString()),
                    }
                };
            }

            _stateReader.Close();
            _connection.CloseConnection();

            return _state;

        }

        public bool insertState(string state, int countryId)
        {
            _stateCommand = _utils.CommandGenerator(DALResources.InsertState);
            _stateCommand.Parameters.AddWithValue("@state", state);
            _stateCommand.Parameters.AddWithValue("@countryId", countryId);
            _stateCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _stateCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteState(int id)
        {
            _stateCommand = _utils.CommandGenerator(DALResources.DeleteState);
            _stateCommand.Parameters.AddWithValue("@stateId", id);
            _stateCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _stateCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
