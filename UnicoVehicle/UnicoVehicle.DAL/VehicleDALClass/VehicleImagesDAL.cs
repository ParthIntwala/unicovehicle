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
                        VehicleId = int.Parse(_imageReader["VehicleId"].ToString())
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
                    VehicleImagesId = int.Parse(_imageReader["VehicleImageId"].ToString()),
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
            //_imageCommand.Parameters.AddWithValue("@vehicleId", id);
            //_imageCommand.Parameters.AddWithValue("@airbagCount", image.AirbagCount);
            //_imageCommand.Parameters.AddWithValue("@hasPowerSteering", image.HasPowerSteering);
            //_imageCommand.Parameters.AddWithValue("@hasPowerFrontWindow", image.HasPowerFrontWindow);
            //_imageCommand.Parameters.AddWithValue("@hasPowerRearWindow", image.HasPowerRearWindow);
            //_imageCommand.Parameters.AddWithValue("@hasSunRoof", image.HasSunRoof);
            //_imageCommand.Parameters.AddWithValue("@hasSeatCover", image.HasSeatCover);
            //_imageCommand.Parameters.AddWithValue("@hasBluetooth", image.HasBluetooth);
            //_imageCommand.Parameters.AddWithValue("@hasWIFI", image.HasWIFI);
            //_imageCommand.Parameters.AddWithValue("@hasAUXSupport", image.HasAUXSupport);
            //_imageCommand.Parameters.AddWithValue("@hasUSB", image.HasUSB);
            //_imageCommand.Parameters.AddWithValue("@hasiPod", image.HasiPod);
            //_imageCommand.Parameters.AddWithValue("@hasRadio", image.HasRadio);
            //_imageCommand.Parameters.AddWithValue("@hasCarPlay", image.HasCarPlay);
            //_imageCommand.Parameters.AddWithValue("@hasAndroidAuto", image.HasAndroidAuto);
            //_imageCommand.Parameters.AddWithValue("@hasNavigation", image.HasNavigation);
            //_imageCommand.Parameters.AddWithValue("@hasCompass", image.HasCompass);
            //_imageCommand.Parameters.AddWithValue("@hasFrontSpeaker", image.HasFrontSpeaker);
            //_imageCommand.Parameters.AddWithValue("@hasMiddleSpeaker", image.HasMiddleSpeaker);
            //_imageCommand.Parameters.AddWithValue("@hasRearSpeaker", image.HasRearSpeaker);
            //_imageCommand.Parameters.AddWithValue("@hasClimateControl", image.HasClimateControl);
            //_imageCommand.Parameters.AddWithValue("@hasWeatherSensingWiper", image.HasWeatherSensingWiper);
            //_imageCommand.Parameters.AddWithValue("@hasAC", image.HasAC);
            //_imageCommand.Parameters.AddWithValue("@hasHeater", image.HasHeater);
            //_imageCommand.Parameters.AddWithValue("@hasRemoteTrunkOpener", image.HasRemoteTrunkOpener);
            //_imageCommand.Parameters.AddWithValue("@hasRemoteEngineStart", image.HasRemoteEngineStart);
            //_imageCommand.Parameters.AddWithValue("@hasLowFuelLight", image.HasLowFuelLight);
            //_imageCommand.Parameters.AddWithValue("@hasOilChangeLight", image.HasOilChangeLight);
            //_imageCommand.Parameters.AddWithValue("@hasVehicleServiceLight", image.HasVehicleServiceLight);
            //_imageCommand.Parameters.AddWithValue("@hasRangeMeter", image.HasRangeMeter);
            //_imageCommand.Parameters.AddWithValue("@hasMileageMeter", image.HasMileageMeter);
            //_imageCommand.Parameters.AddWithValue("@hasTemperatureScale", image.HasTemperatureScale);
            //_imageCommand.Parameters.AddWithValue("@hasTrunkLight", image.HasTrunkLight);
            //_imageCommand.Parameters.AddWithValue("@hasRearACDuct", image.HasRearACDucts);
            //_imageCommand.Parameters.AddWithValue("@hasAdjustableHeadRest", image.HasAdjustableHeadRest);
            //_imageCommand.Parameters.AddWithValue("@hasHeadRest", image.HasHeadRest);
            //_imageCommand.Parameters.AddWithValue("@hasBucketSeat", image.HasBucketSeat);
            //_imageCommand.Parameters.AddWithValue("@hasSeatBelt", image.HasSeatBelt);
            //_imageCommand.Parameters.AddWithValue("@hasCupHolder", image.HasCupHolder);
            //_imageCommand.Parameters.AddWithValue("@hasABS", image.HasABS);
            //_imageCommand.Parameters.AddWithValue("@hasFrontHeatedSeat", image.HasFrontHeatedSeat);
            //_imageCommand.Parameters.AddWithValue("@hasRearHeatedSeat", image.HasRearHeatedSeat);
            //_imageCommand.Parameters.AddWithValue("@hasMassageChair", image.HasMassageChair);
            //_imageCommand.Parameters.AddWithValue("@hasSeatInfotainment", image.HasSeatInfotainment);
            //_imageCommand.Parameters.AddWithValue("@hasCruiseControl", image.HasCruiseControl);
            //_imageCommand.Parameters.AddWithValue("@hasFoldableSeat", image.HasFoldableSeat);
            //_imageCommand.Parameters.AddWithValue("@hasKeylessEntry", image.HasKeylessEntry);
            //_imageCommand.Parameters.AddWithValue("@hasFingerprintDoorUnlock", image.HasFingerprintDoorUnlock);
            //_imageCommand.Parameters.AddWithValue("@numberofUSBPorts", image.USBPorts);
            //_imageCommand.Parameters.AddWithValue("@hasCigaretteLighter", image.HasCigaretteLighter);
            //_imageCommand.Parameters.AddWithValue("@hasLuggageNet", image.HasLuggageNet);
            //_imageCommand.Parameters.AddWithValue("@hasConvertibleRoof", image.HasConvertibleRoof);
            //_imageCommand.Parameters.AddWithValue("@hasLaneChangeIndicator", image.HasLaneChangeIndicator);
            //_imageCommand.Parameters.AddWithValue("@hasGearShiftIndicator", image.HasGearShiftIndicator);
            //_imageCommand.Parameters.AddWithValue("@hasFogLamp", image.HasFogLamp);
            //_imageCommand.Parameters.AddWithValue("@hasDigitalWatch", image.HasDigitalWatch);
            //_imageCommand.Parameters.AddWithValue("@hasDrivingMode", image.HasDrivingModes);
            //_imageCommand.Parameters.AddWithValue("@hasGloveCompartment", image.HasGloveCompartment);
            //_imageCommand.Parameters.AddWithValue("@hasHeadLightCleaner", image.HasHeadLightCleaner);
            //_imageCommand.Parameters.AddWithValue("@hasRearLightCleaner", image.HasRearLightCleaner);
            //_imageCommand.Parameters.AddWithValue("@hasRearViewAdjustmentSwitch", image.HasRearViewAdjustmentSwitch);
            //_imageCommand.Parameters.AddWithValue("@hasAlloyWheel", image.HasAlloyWheel);
            //_imageCommand.Parameters.AddWithValue("@hasCarCover", image.HasCarCover);
            //_imageCommand.Parameters.AddWithValue("@hasCentralLock", image.HasCentralLock);
            //_imageCommand.Parameters.AddWithValue("@hasChildSafety", image.HasChildSafety);
            //_imageCommand.Parameters.AddWithValue("@hasNightModeMirror", image.HasNightVisionMirror);
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

        public bool UpdateVehicleImages(VehicleImages image)
        {
            _imageCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateImages);
            //_imageCommand.Parameters.AddWithValue("@vehicleId", image.VehicleimagesId);
            //_imageCommand.Parameters.AddWithValue("@airbagCount", image.AirbagCount);
            //_imageCommand.Parameters.AddWithValue("@hasPowerSteering", image.HasPowerSteering);
            //_imageCommand.Parameters.AddWithValue("@hasPowerFrontWindow", image.HasPowerFrontWindow);
            //_imageCommand.Parameters.AddWithValue("@hasPowerRearWindow", image.HasPowerRearWindow);
            //_imageCommand.Parameters.AddWithValue("@hasSunRoof", image.HasSunRoof);
            //_imageCommand.Parameters.AddWithValue("@hasSeatCover", image.HasSeatCover);
            //_imageCommand.Parameters.AddWithValue("@hasBluetooth", image.HasBluetooth);
            //_imageCommand.Parameters.AddWithValue("@hasWIFI", image.HasWIFI);
            //_imageCommand.Parameters.AddWithValue("@hasAUXSupport", image.HasAUXSupport);
            //_imageCommand.Parameters.AddWithValue("@hasUSB", image.HasUSB);
            //_imageCommand.Parameters.AddWithValue("@hasiPod", image.HasiPod);
            //_imageCommand.Parameters.AddWithValue("@hasRadio", image.HasRadio);
            //_imageCommand.Parameters.AddWithValue("@hasCarPlay", image.HasCarPlay);
            //_imageCommand.Parameters.AddWithValue("@hasAndroidAuto", image.HasAndroidAuto);
            //_imageCommand.Parameters.AddWithValue("@hasNavigation", image.HasNavigation);
            //_imageCommand.Parameters.AddWithValue("@hasCompass", image.HasCompass);
            //_imageCommand.Parameters.AddWithValue("@hasFrontSpeaker", image.HasFrontSpeaker);
            //_imageCommand.Parameters.AddWithValue("@hasMiddleSpeaker", image.HasMiddleSpeaker);
            //_imageCommand.Parameters.AddWithValue("@hasRearSpeaker", image.HasRearSpeaker);
            //_imageCommand.Parameters.AddWithValue("@hasClimateControl", image.HasClimateControl);
            //_imageCommand.Parameters.AddWithValue("@hasWeatherSensingWiper", image.HasWeatherSensingWiper);
            //_imageCommand.Parameters.AddWithValue("@hasAC", image.HasAC);
            //_imageCommand.Parameters.AddWithValue("@hasHeater", image.HasHeater);
            //_imageCommand.Parameters.AddWithValue("@hasRemoteTrunkOpener", image.HasRemoteTrunkOpener);
            //_imageCommand.Parameters.AddWithValue("@hasRemoteEngineStart", image.HasRemoteEngineStart);
            //_imageCommand.Parameters.AddWithValue("@hasLowFuelLight", image.HasLowFuelLight);
            //_imageCommand.Parameters.AddWithValue("@hasOilChangeLight", image.HasOilChangeLight);
            //_imageCommand.Parameters.AddWithValue("@hasVehicleServiceLight", image.HasVehicleServiceLight);
            //_imageCommand.Parameters.AddWithValue("@hasRangeMeter", image.HasRangeMeter);
            //_imageCommand.Parameters.AddWithValue("@hasMileageMeter", image.HasMileageMeter);
            //_imageCommand.Parameters.AddWithValue("@hasTemperatureScale", image.HasTemperatureScale);
            //_imageCommand.Parameters.AddWithValue("@hasTrunkLight", image.HasTrunkLight);
            //_imageCommand.Parameters.AddWithValue("@hasRearACDuct", image.HasRearACDucts);
            //_imageCommand.Parameters.AddWithValue("@hasAdjustableHeadRest", image.HasAdjustableHeadRest);
            //_imageCommand.Parameters.AddWithValue("@hasHeadRest", image.HasHeadRest);
            //_imageCommand.Parameters.AddWithValue("@hasBucketSeat", image.HasBucketSeat);
            //_imageCommand.Parameters.AddWithValue("@hasSeatBelt", image.HasSeatBelt);
            //_imageCommand.Parameters.AddWithValue("@hasCupHolder", image.HasCupHolder);
            //_imageCommand.Parameters.AddWithValue("@hasABS", image.HasABS);
            //_imageCommand.Parameters.AddWithValue("@hasFrontHeatedSeat", image.HasFrontHeatedSeat);
            //_imageCommand.Parameters.AddWithValue("@hasRearHeatedSeat", image.HasRearHeatedSeat);
            //_imageCommand.Parameters.AddWithValue("@hasMassageChair", image.HasMassageChair);
            //_imageCommand.Parameters.AddWithValue("@hasSeatInfotainment", image.HasSeatInfotainment);
            //_imageCommand.Parameters.AddWithValue("@hasCruiseControl", image.HasCruiseControl);
            //_imageCommand.Parameters.AddWithValue("@hasFoldableSeat", image.HasFoldableSeat);
            //_imageCommand.Parameters.AddWithValue("@hasKeylessEntry", image.HasKeylessEntry);
            //_imageCommand.Parameters.AddWithValue("@hasFingerprintDoorUnlock", image.HasFingerprintDoorUnlock);
            //_imageCommand.Parameters.AddWithValue("@numberofUSBPorts", image.USBPorts);
            //_imageCommand.Parameters.AddWithValue("@hasCigaretteLighter", image.HasCigaretteLighter);
            //_imageCommand.Parameters.AddWithValue("@hasLuggageNet", image.HasLuggageNet);
            //_imageCommand.Parameters.AddWithValue("@hasConvertibleRoof", image.HasConvertibleRoof);
            //_imageCommand.Parameters.AddWithValue("@hasLaneChangeIndicator", image.HasLaneChangeIndicator);
            //_imageCommand.Parameters.AddWithValue("@hasGearShiftIndicator", image.HasGearShiftIndicator);
            //_imageCommand.Parameters.AddWithValue("@hasFogLamp", image.HasFogLamp);
            //_imageCommand.Parameters.AddWithValue("@hasDigitalWatch", image.HasDigitalWatch);
            //_imageCommand.Parameters.AddWithValue("@hasDrivingMode", image.HasDrivingModes);
            //_imageCommand.Parameters.AddWithValue("@hasGloveCompartment", image.HasGloveCompartment);
            //_imageCommand.Parameters.AddWithValue("@hasHeadLightCleaner", image.HasHeadLightCleaner);
            //_imageCommand.Parameters.AddWithValue("@hasRearLightCleaner", image.HasRearLightCleaner);
            //_imageCommand.Parameters.AddWithValue("@hasRearViewAdjustmentSwitch", image.HasRearViewAdjustmentSwitch);
            //_imageCommand.Parameters.AddWithValue("@hasAlloyWheel", image.HasAlloyWheel);
            //_imageCommand.Parameters.AddWithValue("@hasCarCover", image.HasCarCover);
            //_imageCommand.Parameters.AddWithValue("@hasCentralLock", image.HasCentralLock);
            //_imageCommand.Parameters.AddWithValue("@hasChildSafety", image.HasChildSafety);
            //_imageCommand.Parameters.AddWithValue("@hasNightModeMirror", image.HasNightVisionMirror);
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
