using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ITransmissionTypeBLL
    {
        public bool DeleteTransmissionType(int id);
        public List<TransmissionType> Get();
        public TransmissionType GetTransmissionTypebyId(int id);
        public bool InsertTransmissionType(string transmissionType);
    }
}