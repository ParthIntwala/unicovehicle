using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IStatusBLL
    {
        public bool DeleteStatus(int id);
        public List<Status> Get();
        public Status GetStatusbyId(int id);
        public bool InsertStatus(string status);
        public bool UpdateStatus(string status, int statusId);
    }
}