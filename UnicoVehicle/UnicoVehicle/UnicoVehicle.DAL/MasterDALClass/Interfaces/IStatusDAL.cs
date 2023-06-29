using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IStatusDAL
    {
        public bool DeleteStatus(int id);
        public List<Status> GetStatus();
        public Status GetStatusbyId(int id);
        public bool InsertStatus(string status);
        public bool UpdateStatus(string accessoriesType, int accessoriesTypeId);
    }
}