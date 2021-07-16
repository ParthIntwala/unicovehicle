using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ITransmissionTypeDAL
    {
        public bool DeleteTransmissionType(int id);
        public List<TransmissionType> GetTransmissionType();
        public TransmissionType GetTransmissionTypebyId(int id);
        public bool InsertTransmissionType(string transmissionType);
    }
}