using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IStateDAL
    {
        bool deleteState(int id);
        List<State> getState();
        State getStatebyId(int id);
        bool insertState(string state, int countryId);
    }
}