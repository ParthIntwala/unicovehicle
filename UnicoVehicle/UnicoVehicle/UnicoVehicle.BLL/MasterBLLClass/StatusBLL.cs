using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class StatusBLL : IStatusBLL
    {
        private readonly IStatusDAL _statusDAL;
        bool _status;

        public StatusBLL(IStatusDAL statusDAL)
        {
            _statusDAL = statusDAL;
        }

        public List<Status> Get()
        {
            List<Status> _status = _statusDAL.GetStatus();
            return _status;
        }

        public Status GetStatusbyId(int id)
        {
            Status _status = _statusDAL.GetStatusbyId(id);
            return _status;
        }

        public bool InsertStatus(string status)
        {
            _status = _statusDAL.InsertStatus(status);
            return _status;
        }

        public bool DeleteStatus(int id)
        {
            _status = _statusDAL.DeleteStatus(id);
            return _status;
        }

        public bool UpdateStatus(string status, int statusId)
        {
            _status = _statusDAL.UpdateStatus(status, statusId);
            return _status;
        }
    }
}
