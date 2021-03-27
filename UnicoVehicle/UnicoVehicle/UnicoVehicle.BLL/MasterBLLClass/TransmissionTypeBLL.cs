using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class TransmissionTypeBLL : ITransmissionTypeBLL
    {
        private readonly ITransmissionTypeDAL _transmissionTypeDAL;
        bool _status;

        public TransmissionTypeBLL(ITransmissionTypeDAL transmissionTypeDAL)
        {
            _transmissionTypeDAL = transmissionTypeDAL;
        }

        public List<TransmissionType> Get()
        {
            List<TransmissionType> _transmissionTypes = _transmissionTypeDAL.GetTransmissionType();
            return _transmissionTypes;
        }

        public TransmissionType GetTransmissionTypebyId(int id)
        {
            TransmissionType _transmissionType = _transmissionTypeDAL.GetTransmissionTypebyId(id);
            return _transmissionType;
        }

        public bool InsertTransmissionType(string transmissionType)
        {
            _status = _transmissionTypeDAL.InsertTransmissionType(transmissionType);
            return _status;
        }

        public bool DeleteTransmissionType(int id)
        {
            _status = _transmissionTypeDAL.DeleteTransmissionType(id);
            return _status;
        }
    }
}
