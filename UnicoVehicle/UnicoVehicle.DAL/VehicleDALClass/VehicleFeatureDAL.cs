using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class VehicleFeatureDAL : IVehicleFeatureDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _detailCommand;
        private SqlDataReader _detailReader;
        int _success;

        public VehicleFeatureDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public VehicleFeatures GetVehicleFeaturebyId(int id)
        {
            _detailCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleFeaturesbyId);
            _detailCommand.Parameters.AddWithValue("@vehicleId", id);
            _detailReader = _detailCommand.ExecuteReader();

            VehicleFeatures _features = new VehicleFeatures();

            while (_detailReader.Read())
            {
                _features = new VehicleFeatures
                {
                    VehicleId = id,
                    VehicleFeaturesId = int.Parse(_detailReader["VehicleFeaturesId"].ToString()),
                    AirbagCount = int.Parse(_detailReader["AirbagCount"].ToString()),
                    HasPowerSteering = bool.Parse(_detailReader["hasPowerSteering"].ToString()),
                    HasPowerFrontWindow = bool.Parse(_detailReader["hasPowerFrontWindow"].ToString()),
                    HasPowerRearWindow = bool.Parse(_detailReader["hasPowerRearWindow"].ToString()),
                    HasSunRoof = bool.Parse(_detailReader["hasSunRoof"].ToString()),
                    HasSeatCover = bool.Parse(_detailReader["hasSeatCover"].ToString()),
                    HasBluetooth = bool.Parse(_detailReader["hasBluetooth"].ToString()),
                    HasWIFI = bool.Parse(_detailReader["hasWIFI"].ToString()),
                    HasAUXSupport = bool.Parse(_detailReader["hasAUXSupport"].ToString()),
                    HasUSB = bool.Parse(_detailReader["hasUSB"].ToString()),
                    HasiPod = bool.Parse(_detailReader["hasiPod"].ToString()),
                    HasRadio = bool.Parse(_detailReader["hasRadio"].ToString()),
                    HasCarPlay = bool.Parse(_detailReader["hasCarPlay"].ToString()),
                    HasAndroidAuto = bool.Parse(_detailReader["hasAndroidAuto"].ToString()),
                    HasNavigation = bool.Parse(_detailReader["hasNavigation"].ToString()),
                    HasCompass = bool.Parse(_detailReader["hasCompass"].ToString()),
                    HasFrontSpeaker = bool.Parse(_detailReader["hasFrontSpeaker"].ToString()),
                    HasMiddleSpeaker = bool.Parse(_detailReader["hasMiddleSpeaker"].ToString()),
                    HasRearSpeaker = bool.Parse(_detailReader["hasRearSpeaker"].ToString()),
                    HasClimateControl = bool.Parse(_detailReader["hasClimateControl"].ToString()),
                    HasWeatherSensingWiper = bool.Parse(_detailReader["hasWeatherSensingWiper"].ToString()),
                    HasAC = bool.Parse(_detailReader["hasAC"].ToString()),
                    HasHeater = bool.Parse(_detailReader["hasHeater"].ToString()),
                    HasRemoteTrunkOpener = bool.Parse(_detailReader["hasRemoteTrunkOpener"].ToString()),
                    HasRemoteEngineStart = bool.Parse(_detailReader["hasRemoteEngineStart"].ToString()),
                    HasLowFuelLight = bool.Parse(_detailReader["hasLowFuelLight"].ToString()),
                    HasOilChangeLight = bool.Parse(_detailReader["hasOilChangeLight"].ToString()),
                    HasVehicleServiceLight = bool.Parse(_detailReader["hasVehicleServiceLight"].ToString()),
                    HasRangeMeter = bool.Parse(_detailReader["hasRangeMeter"].ToString()),
                    HasMileageMeter = bool.Parse(_detailReader["hasMileageMeter"].ToString()),
                    HasTemperatureScale = bool.Parse(_detailReader["hasTemperatureScale"].ToString()),
                    HasTrunkLight = bool.Parse(_detailReader["hasTrunkLight"].ToString()),
                    HasRearACDucts = bool.Parse(_detailReader["hasRearACDuct"].ToString()),
                    HasAdjustableHeadRest = bool.Parse(_detailReader["hasAdjustableHeadRest"].ToString()),
                    HasHeadRest = bool.Parse(_detailReader["hasHeadRest"].ToString()),
                    HasBucketSeat = bool.Parse(_detailReader["hasBucketSeat"].ToString()),
                    HasSeatBelt = bool.Parse(_detailReader["hasSeatBelt"].ToString()),
                    HasCupHolder = bool.Parse(_detailReader["hasCupHolder"].ToString()),
                    HasABS = bool.Parse(_detailReader["hasABS"].ToString()),
                    HasFrontHeatedSeat = bool.Parse(_detailReader["hasFrontHeatedSeat"].ToString()),
                    HasRearHeatedSeat = bool.Parse(_detailReader["hasRearHeatedSeat"].ToString()),
                    HasMassageChair = bool.Parse(_detailReader["hasMassageChair"].ToString()),
                    HasSeatInfotainment = bool.Parse(_detailReader["hasSeatInfotainment"].ToString()),
                    HasCruiseControl = bool.Parse(_detailReader["hasCruiseControl"].ToString()),
                    HasFoldableSeat = bool.Parse(_detailReader["hasFoldableSeat"].ToString()),
                    HasKeylessEntry = bool.Parse(_detailReader["hasKeylessEntry"].ToString()),
                    HasFingerprintDoorUnlock = bool.Parse(_detailReader["hasFingerprintDoorUnlock"].ToString()),
                    USBPorts = int.Parse(_detailReader["NumberofUSBPorts"].ToString()),
                    HasCigaretteLighter = bool.Parse(_detailReader["hasCigaretteLighter"].ToString()),
                    HasLuggageNet = bool.Parse(_detailReader["hasLuggageNet"].ToString()),
                    HasConvertibleRoof = bool.Parse(_detailReader["hasConvertibleRoof"].ToString()),
                    HasLaneChangeIndicator = bool.Parse(_detailReader["hasLaneChangeIndicator"].ToString()),
                    HasGearShiftIndicator = bool.Parse(_detailReader["hasGearShiftIndicator"].ToString()),
                    HasFogLamp = bool.Parse(_detailReader["hasFogLamp"].ToString()),
                    HasDigitalWatch = bool.Parse(_detailReader["hasDigitalWatch"].ToString()),
                    HasDrivingModes = bool.Parse(_detailReader["hasDrivingMode"].ToString()),
                    HasGloveCompartment = bool.Parse(_detailReader["hasGloveCompartment"].ToString()),
                    HasHeadLightCleaner = bool.Parse(_detailReader["hasHeadLightCleaner"].ToString()),
                    HasRearLightCleaner = bool.Parse(_detailReader["hasRearLightCleaner"].ToString()),
                    HasRearViewAdjustmentSwitch = bool.Parse(_detailReader["hasRearViewAdjustmentSwitch"].ToString()),
                    HasAlloyWheel = bool.Parse(_detailReader["hasAlloyWheel"].ToString()),
                    HasCarCover = bool.Parse(_detailReader["hasCarCover"].ToString()),
                    HasCentralLock = bool.Parse(_detailReader["hasCentralLock"].ToString()),
                    HasChildSafety = bool.Parse(_detailReader["hasChildSafety"].ToString()),
                    HasNightVisionMirror = bool.Parse(_detailReader["hasNightModeMirror"].ToString())
                };
            }

            _detailReader.Close();
            _connection.CloseConnection();

            return _features;
        }

        //public bool InsertVehicleFeature(VehicleFeatures variant)
        //{
        //    _detailCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehicleVariant);
        //    _detailCommand.Parameters.AddWithValue("@vehicleVariant", variant.VehicleVariantName);
        //    _detailCommand.Parameters.AddWithValue("@companyId", variant.Company.CompanyId);
        //    _detailCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

        //    _success = _detailCommand.ExecuteNonQuery();
        //    _connection.CloseConnection();

        //    if (_success > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool DeleteVehicleFeature(int id)
        {
            _detailCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteVehicleFeatures);
            _detailCommand.Parameters.AddWithValue("@vehicleFeaturesId", id);
            _detailCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _detailCommand.ExecuteNonQuery();
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
