using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class VehicleImagesDAL : IVehicleImagesDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _imageCommand;
        private SqlDataReader _imageReader;
        int _success;

        public VehicleImagesDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public VehicleImages GetVehicleImagesbyId(int id)
        {
            _imageCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetImagesbyId);
            _imageCommand.Parameters.AddWithValue("@vehicleId", id);
            _imageReader = _imageCommand.ExecuteReader();

            VehicleImages _images = new VehicleImages();

            while (_imageReader.Read())
            {
                _images = new VehicleImages
                {
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = id
                    },
                    DoorHandle = _imageReader["DoorHandle"].ToString(),
                    Engine = _imageReader["Engine"].ToString(),
                    FrontPanel = _imageReader["FrontPanel"].ToString(),
                    FrontSeat = _imageReader["FrontSeat"].ToString(),
                    FrontSide = _imageReader["FrontSide"].ToString(),
                    GearMechanism = _imageReader["GearHandBreakMechanism"].ToString(),
                    Grill = _imageReader["Grill"].ToString(),
                    HeadLight = _imageReader["HeadLight"].ToString(),
                    InfotainmentSystem = _imageReader["InfotainmentSystem"].ToString(),
                    LeftSide = _imageReader["LeftSide"].ToString(),
                    MiddleSeat = _imageReader["MiddleSeat"].ToString(),
                    ODOMeter = _imageReader["ODOMeter"].ToString(),
                    RearACVents = _imageReader["RearACVents"].ToString(),
                    RearLight = _imageReader["RearLight"].ToString(),
                    RearSide = _imageReader["RearSide"].ToString(),
                    RearSeat = _imageReader["RearSeat"].ToString(),
                    RightSide = _imageReader["RightSide"].ToString(),
                    SeatsLeftView = _imageReader["SeatsLeftView"].ToString(),
                    SeatsRightView = _imageReader["SeatsRightView"].ToString(),
                    SideMirror = _imageReader["SideMirror"].ToString(),
                    SteeringWheel = _imageReader["SteeringWheel"].ToString(),
                    TopView = _imageReader["TopView"].ToString(),
                    Trunk = _imageReader["Trunk"].ToString(),
                    VehicleImagesId = int.Parse(_imageReader["VehicleImagesId"].ToString()),
                    Wheel = _imageReader["Wheel"].ToString(),
                };
            }

            _imageReader.Close();
            _connection.CloseConnection();

            return _images;
        }

        public bool InsertVehicleImages(VehicleImages image, int id)
        {
            _imageCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertImages);
            _imageCommand.Parameters.AddWithValue("@vehicleId", id);
            _imageCommand.Parameters.AddWithValue("@frontSide", image.FrontSide);
            _imageCommand.Parameters.AddWithValue("@rearSide", image.RearSide);
            _imageCommand.Parameters.AddWithValue("@leftSide", image.LeftSide);
            _imageCommand.Parameters.AddWithValue("@rightSide", image.RightSide);
            _imageCommand.Parameters.AddWithValue("@topView", image.TopView);
            _imageCommand.Parameters.AddWithValue("@seatsLeftView", image.SeatsLeftView);
            _imageCommand.Parameters.AddWithValue("@seatsRightView", image.SeatsRightView);
            _imageCommand.Parameters.AddWithValue("@engine", image.Engine);
            _imageCommand.Parameters.AddWithValue("@frontPanel", image.FrontPanel);
            _imageCommand.Parameters.AddWithValue("@frontSeat", image.FrontSeat);
            _imageCommand.Parameters.AddWithValue("@middleSeat", image.MiddleSeat);
            _imageCommand.Parameters.AddWithValue("@rearSeat", image.RearSeat);
            _imageCommand.Parameters.AddWithValue("@trunk", image.Trunk);
            _imageCommand.Parameters.AddWithValue("@grill", image.Grill);
            _imageCommand.Parameters.AddWithValue("@headLight", image.HeadLight);
            _imageCommand.Parameters.AddWithValue("@rearLight", image.RearLight);
            _imageCommand.Parameters.AddWithValue("@wheel", image.Wheel);
            _imageCommand.Parameters.AddWithValue("@doorHandle", image.DoorHandle);
            _imageCommand.Parameters.AddWithValue("@sideMirror", image.SideMirror);
            _imageCommand.Parameters.AddWithValue("@steeringWheel", image.SteeringWheel);
            _imageCommand.Parameters.AddWithValue("@odoMeter", image.ODOMeter);
            _imageCommand.Parameters.AddWithValue("@gearMechanism", image.GearMechanism);
            _imageCommand.Parameters.AddWithValue("@infotainmentSystem", image.InfotainmentSystem);
            _imageCommand.Parameters.AddWithValue("@rearACVents", image.RearACVents);
            _imageCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _imageCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateVehicleImages(VehicleImages image, int id)
        {
            _imageCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateImages);
            _imageCommand.Parameters.AddWithValue("@vehicleImagesId", id);
            _imageCommand.Parameters.AddWithValue("@frontSide", image.FrontSide);
            _imageCommand.Parameters.AddWithValue("@rearSide", image.RearSide);
            _imageCommand.Parameters.AddWithValue("@leftSide", image.LeftSide);
            _imageCommand.Parameters.AddWithValue("@rightSide", image.RightSide);
            _imageCommand.Parameters.AddWithValue("@topView", image.TopView);
            _imageCommand.Parameters.AddWithValue("@seatsLeftView", image.SeatsLeftView);
            _imageCommand.Parameters.AddWithValue("@seatsRightView", image.SeatsRightView);
            _imageCommand.Parameters.AddWithValue("@engine", image.Engine);
            _imageCommand.Parameters.AddWithValue("@frontPanel", image.FrontPanel);
            _imageCommand.Parameters.AddWithValue("@frontSeat", image.FrontSeat);
            _imageCommand.Parameters.AddWithValue("@middleSeat", image.MiddleSeat);
            _imageCommand.Parameters.AddWithValue("@rearSeat", image.RearSeat);
            _imageCommand.Parameters.AddWithValue("@trunk", image.Trunk);
            _imageCommand.Parameters.AddWithValue("@grill", image.Grill);
            _imageCommand.Parameters.AddWithValue("@headLight", image.HeadLight);
            _imageCommand.Parameters.AddWithValue("@rearLight", image.RearLight);
            _imageCommand.Parameters.AddWithValue("@wheel", image.Wheel);
            _imageCommand.Parameters.AddWithValue("@doorHandle", image.DoorHandle);
            _imageCommand.Parameters.AddWithValue("@sideMirror", image.SideMirror);
            _imageCommand.Parameters.AddWithValue("@steeringWheel", image.SteeringWheel);
            _imageCommand.Parameters.AddWithValue("@odoMeter", image.ODOMeter);
            _imageCommand.Parameters.AddWithValue("@gearMechanism", image.GearMechanism);
            _imageCommand.Parameters.AddWithValue("@infotainmentSystem", image.InfotainmentSystem);
            _imageCommand.Parameters.AddWithValue("@rearACVents", image.RearACVents);
            _imageCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _imageCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
