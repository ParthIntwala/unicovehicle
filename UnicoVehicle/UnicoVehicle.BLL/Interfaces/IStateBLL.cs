using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IStateBLL
    {
        bool deleteState(int id);
        List<State> get();
        State getStatebyId(int id);
        bool insertState(string state, int countryId);
    }
}