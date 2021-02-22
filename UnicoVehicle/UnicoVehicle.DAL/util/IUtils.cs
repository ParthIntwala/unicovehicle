using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public interface IUtils
    {
        SqlCommand CommandGenerator(string query);
    }
}