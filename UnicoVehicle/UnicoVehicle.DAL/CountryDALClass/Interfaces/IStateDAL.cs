using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IStateDAL
    {
        public bool DeleteState(int id);
        public List<State> GetState(int id);
        public State GetStatebyId(int id);
        public bool InsertState(string state, int countryId);
    }
}