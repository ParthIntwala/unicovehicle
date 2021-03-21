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
        private SqlCommand _featureCommand;
        private SqlDataReader _featureReader;
        int _success;

        public VehicleFeatureDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public VehicleFeatures GetVehicleFeaturebyId(int id)
        {
            _featureCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleFeaturesbyId);
            _featureCommand.Parameters.AddWithValue("@vehicleId", id);
            _featureReader = _featureCommand.ExecuteReader();

            VehicleFeatures _features = new VehicleFeatures();

            while (_featureReader.Read())
            {
                _features = new VehicleFeatures
                {
                    VehicleFeaturesId = int.Parse(_featureReader["VehicleFeaturesId"].ToString()),
                    AirbagCount = int.Parse(_featureReader["AirbagCount"].ToString()),
                    HasPowerSteering = bool.Parse(_featureReader["hasPowerSteering"].ToString()),
                    HasPowerFrontWindow = bool.Parse(_featureReader["hasPowerFrontWindow"].ToString()),
                    HasPowerRearWindow = bool.Parse(_featureReader["hasPowerRearWindow"].ToString()),
                    HasSunRoof = bool.Parse(_featureReader["hasSunRoof"].ToString()),
                    HasSeatCover = bool.Parse(_featureReader["hasSeatCover"].ToString()),
                    HasBluetooth = bool.Parse(_featureReader["hasBluetooth"].ToString()),
                    HasWIFI = bool.Parse(_featureReader["hasWIFI"].ToString()),
                    HasAUXSupport = bool.Parse(_featureReader["hasAUXSupport"].ToString()),
                    HasUSB = bool.Parse(_featureReader["hasUSB"].ToString()),
                    HasiPod = bool.Parse(_featureReader["hasiPod"].ToString()),
                    HasRadio = bool.Parse(_featureReader["hasRadio"].ToString()),
                    HasCarPlay = bool.Parse(_featureReader["hasCarPlay"].ToString()),
                    HasAndroidAuto = bool.Parse(_featureReader["hasAndroidAuto"].ToString()),
                    HasNavigation = bool.Parse(_featureReader["hasNavigation"].ToString()),
                    HasCompass = bool.Parse(_featureReader["hasCompass"].ToString()),
                    HasFrontSpeaker = bool.Parse(_featureReader["hasFrontSpeaker"].ToString()),
                    HasMiddleSpeaker = bool.Parse(_featureReader["hasMiddleSpeaker"].ToString()),
                    HasRearSpeaker = bool.Parse(_featureReader["hasRearSpeaker"].ToString()),
                    HasClimateControl = bool.Parse(_featureReader["hasClimateControl"].ToString()),
                    HasWeatherSensingWiper = bool.Parse(_featureReader["hasWeatherSensingWiper"].ToString()),
                    HasAC = bool.Parse(_featureReader["hasAC"].ToString()),
                    HasHeater = bool.Parse(_featureReader["hasHeater"].ToString()),
                    HasRemoteTrunkOpener = bool.Parse(_featureReader["hasRemoteTrunkOpener"].ToString()),
                    HasRemoteEngineStart = bool.Parse(_featureReader["hasRemoteEngineStart"].ToString()),
                    HasLowFuelLight = bool.Parse(_featureReader["hasLowFuelLight"].ToString()),
                    HasOilChangeLight = bool.Parse(_featureReader["hasOilChangeLight"].ToString()),
                    HasVehicleServiceLight = bool.Parse(_featureReader["hasVehicleServiceLight"].ToString()),
                    HasRangeMeter = bool.Parse(_featureReader["hasRangeMeter"].ToString()),
                    HasMileageMeter = bool.Parse(_featureReader["hasMileageMeter"].ToString()),
                    HasTemperatureScale = bool.Parse(_featureReader["hasTemperatureScale"].ToString()),
                    HasTrunkLight = bool.Parse(_featureReader["hasTrunkLight"].ToString()),
                    HasRearACDucts = bool.Parse(_featureReader["hasRearACDuct"].ToString()),
                    HasAdjustableHeadRest = bool.Parse(_featureReader["hasAdjustableHeadRest"].ToString()),
                    HasHeadRest = bool.Parse(_featureReader["hasHeadRest"].ToString()),
                    HasBucketSeat = bool.Parse(_featureReader["hasBucketSeat"].ToString()),
                    HasSeatBelt = bool.Parse(_featureReader["hasSeatBelt"].ToString()),
                    HasCupHolder = bool.Parse(_featureReader["hasCupHolder"].ToString()),
                    HasABS = bool.Parse(_featureReader["hasABS"].ToString()),
                    HasFrontHeatedSeat = bool.Parse(_featureReader["hasFrontHeatedSeat"].ToString()),
                    HasRearHeatedSeat = bool.Parse(_featureReader["hasRearHeatedSeat"].ToString()),
                    HasMassageChair = bool.Parse(_featureReader["hasMassageChair"].ToString()),
                    HasSeatInfotainment = bool.Parse(_featureReader["hasSeatInfotainment"].ToString()),
                    HasCruiseControl = bool.Parse(_featureReader["hasCruiseControl"].ToString()),
                    HasFoldableSeat = bool.Parse(_featureReader["hasFoldableSeat"].ToString()),
                    HasKeylessEntry = bool.Parse(_featureReader["hasKeylessEntry"].ToString()),
                    HasFingerprintDoorUnlock = bool.Parse(_featureReader["hasFingerprintDoorUnlock"].ToString()),
                    USBPorts = int.Parse(_featureReader["NumberofUSBPorts"].ToString()),
                    HasCigaretteLighter = bool.Parse(_featureReader["hasCigaretteLighter"].ToString()),
                    HasLuggageNet = bool.Parse(_featureReader["hasLuggageNet"].ToString()),
                    HasConvertibleRoof = bool.Parse(_featureReader["hasConvertibleRoof"].ToString()),
                    HasLaneChangeIndicator = bool.Parse(_featureReader["hasLaneChangeIndicator"].ToString()),
                    HasGearShiftIndicator = bool.Parse(_featureReader["hasGearShiftIndicator"].ToString()),
                    HasFogLamp = bool.Parse(_featureReader["hasFogLamp"].ToString()),
                    HasDigitalWatch = bool.Parse(_featureReader["hasDigitalWatch"].ToString()),
                    HasDrivingModes = bool.Parse(_featureReader["hasDrivingMode"].ToString()),
                    HasGloveCompartment = bool.Parse(_featureReader["hasGloveCompartment"].ToString()),
                    HasHeadLightCleaner = bool.Parse(_featureReader["hasHeadLightCleaner"].ToString()),
                    HasRearLightCleaner = bool.Parse(_featureReader["hasRearLightCleaner"].ToString()),
                    HasRearViewAdjustmentSwitch = bool.Parse(_featureReader["hasRearViewAdjustmentSwitch"].ToString()),
                    HasAlloyWheel = bool.Parse(_featureReader["hasAlloyWheel"].ToString()),
                    HasCarCover = bool.Parse(_featureReader["hasCarCover"].ToString()),
                    HasCentralLock = bool.Parse(_featureReader["hasCentralLock"].ToString()),
                    HasChildSafety = bool.Parse(_featureReader["hasChildSafety"].ToString()),
                    HasNightVisionMirror = bool.Parse(_featureReader["hasNightModeMirror"].ToString())
                };
            }

            _featureReader.Close();
            _connection.CloseConnection();

            return _features;
        }

        public bool InsertVehicleFeature(VehicleFeatures feature, int id)
        {
            _featureCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehicleFeatures);
            _featureCommand.Parameters.AddWithValue("@vehicleId", id);
            _featureCommand.Parameters.AddWithValue("@airbagCount", feature.AirbagCount);
            _featureCommand.Parameters.AddWithValue("@hasPowerSteering", feature.HasPowerSteering);
            _featureCommand.Parameters.AddWithValue("@hasPowerFrontWindow", feature.HasPowerFrontWindow);
            _featureCommand.Parameters.AddWithValue("@hasPowerRearWindow", feature.HasPowerRearWindow);
            _featureCommand.Parameters.AddWithValue("@hasSunRoof", feature.HasSunRoof);
            _featureCommand.Parameters.AddWithValue("@hasSeatCover", feature.HasSeatCover);
            _featureCommand.Parameters.AddWithValue("@hasBluetooth", feature.HasBluetooth);
            _featureCommand.Parameters.AddWithValue("@hasWIFI", feature.HasWIFI);
            _featureCommand.Parameters.AddWithValue("@hasAUXSupport", feature.HasAUXSupport);
            _featureCommand.Parameters.AddWithValue("@hasUSB", feature.HasUSB);
            _featureCommand.Parameters.AddWithValue("@hasiPod", feature.HasiPod);
            _featureCommand.Parameters.AddWithValue("@hasRadio", feature.HasRadio);
            _featureCommand.Parameters.AddWithValue("@hasCarPlay", feature.HasCarPlay);
            _featureCommand.Parameters.AddWithValue("@hasAndroidAuto", feature.HasAndroidAuto);
            _featureCommand.Parameters.AddWithValue("@hasNavigation", feature.HasNavigation);
            _featureCommand.Parameters.AddWithValue("@hasCompass", feature.HasCompass);
            _featureCommand.Parameters.AddWithValue("@hasFrontSpeaker", feature.HasFrontSpeaker);
            _featureCommand.Parameters.AddWithValue("@hasMiddleSpeaker", feature.HasMiddleSpeaker);
            _featureCommand.Parameters.AddWithValue("@hasRearSpeaker", feature.HasRearSpeaker);
            _featureCommand.Parameters.AddWithValue("@hasClimateControl", feature.HasClimateControl);
            _featureCommand.Parameters.AddWithValue("@hasWeatherSensingWiper", feature.HasWeatherSensingWiper);
            _featureCommand.Parameters.AddWithValue("@hasAC", feature.HasAC);
            _featureCommand.Parameters.AddWithValue("@hasHeater", feature.HasHeater);
            _featureCommand.Parameters.AddWithValue("@hasRemoteTrunkOpener", feature.HasRemoteTrunkOpener);
            _featureCommand.Parameters.AddWithValue("@hasRemoteEngineStart", feature.HasRemoteEngineStart);
            _featureCommand.Parameters.AddWithValue("@hasLowFuelLight", feature.HasLowFuelLight);
            _featureCommand.Parameters.AddWithValue("@hasOilChangeLight", feature.HasOilChangeLight);
            _featureCommand.Parameters.AddWithValue("@hasVehicleServiceLight", feature.HasVehicleServiceLight);
            _featureCommand.Parameters.AddWithValue("@hasRangeMeter", feature.HasRangeMeter);
            _featureCommand.Parameters.AddWithValue("@hasMileageMeter", feature.HasMileageMeter);
            _featureCommand.Parameters.AddWithValue("@hasTemperatureScale", feature.HasTemperatureScale);
            _featureCommand.Parameters.AddWithValue("@hasTrunkLight", feature.HasTrunkLight);
            _featureCommand.Parameters.AddWithValue("@hasRearACDuct", feature.HasRearACDucts);
            _featureCommand.Parameters.AddWithValue("@hasAdjustableHeadRest", feature.HasAdjustableHeadRest);
            _featureCommand.Parameters.AddWithValue("@hasHeadRest", feature.HasHeadRest);
            _featureCommand.Parameters.AddWithValue("@hasBucketSeat", feature.HasBucketSeat);
            _featureCommand.Parameters.AddWithValue("@hasSeatBelt", feature.HasSeatBelt);
            _featureCommand.Parameters.AddWithValue("@hasCupHolder", feature.HasCupHolder);
            _featureCommand.Parameters.AddWithValue("@hasABS", feature.HasABS);
            _featureCommand.Parameters.AddWithValue("@hasFrontHeatedSeat", feature.HasFrontHeatedSeat);
            _featureCommand.Parameters.AddWithValue("@hasRearHeatedSeat", feature.HasRearHeatedSeat);
            _featureCommand.Parameters.AddWithValue("@hasMassageChair", feature.HasMassageChair);
            _featureCommand.Parameters.AddWithValue("@hasSeatInfotainment", feature.HasSeatInfotainment);
            _featureCommand.Parameters.AddWithValue("@hasCruiseControl", feature.HasCruiseControl);
            _featureCommand.Parameters.AddWithValue("@hasFoldableSeat", feature.HasFoldableSeat);
            _featureCommand.Parameters.AddWithValue("@hasKeylessEntry", feature.HasKeylessEntry);
            _featureCommand.Parameters.AddWithValue("@hasFingerprintDoorUnlock", feature.HasFingerprintDoorUnlock);
            _featureCommand.Parameters.AddWithValue("@numberofUSBPorts", feature.USBPorts);
            _featureCommand.Parameters.AddWithValue("@hasCigaretteLighter", feature.HasCigaretteLighter);
            _featureCommand.Parameters.AddWithValue("@hasLuggageNet", feature.HasLuggageNet);
            _featureCommand.Parameters.AddWithValue("@hasConvertibleRoof", feature.HasConvertibleRoof);
            _featureCommand.Parameters.AddWithValue("@hasLaneChangeIndicator", feature.HasLaneChangeIndicator);
            _featureCommand.Parameters.AddWithValue("@hasGearShiftIndicator", feature.HasGearShiftIndicator);
            _featureCommand.Parameters.AddWithValue("@hasFogLamp", feature.HasFogLamp);
            _featureCommand.Parameters.AddWithValue("@hasDigitalWatch", feature.HasDigitalWatch);
            _featureCommand.Parameters.AddWithValue("@hasDrivingMode", feature.HasDrivingModes);
            _featureCommand.Parameters.AddWithValue("@hasGloveCompartment", feature.HasGloveCompartment);
            _featureCommand.Parameters.AddWithValue("@hasHeadLightCleaner", feature.HasHeadLightCleaner);
            _featureCommand.Parameters.AddWithValue("@hasRearLightCleaner", feature.HasRearLightCleaner);
            _featureCommand.Parameters.AddWithValue("@hasRearViewAdjustmentSwitch", feature.HasRearViewAdjustmentSwitch);
            _featureCommand.Parameters.AddWithValue("@hasAlloyWheel", feature.HasAlloyWheel);
            _featureCommand.Parameters.AddWithValue("@hasCarCover", feature.HasCarCover);
            _featureCommand.Parameters.AddWithValue("@hasCentralLock", feature.HasCentralLock);
            _featureCommand.Parameters.AddWithValue("@hasChildSafety", feature.HasChildSafety);
            _featureCommand.Parameters.AddWithValue("@hasNightModeMirror", feature.HasNightVisionMirror);
            _featureCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _featureCommand.ExecuteNonQuery();
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

        public bool UpdateVehicleFeature(VehicleFeatures feature)
        {
            _featureCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateVehicleFeatures);
            _featureCommand.Parameters.AddWithValue("@vehicleId", feature.VehicleFeaturesId);
            _featureCommand.Parameters.AddWithValue("@airbagCount", feature.AirbagCount);
            _featureCommand.Parameters.AddWithValue("@hasPowerSteering", feature.HasPowerSteering);
            _featureCommand.Parameters.AddWithValue("@hasPowerFrontWindow", feature.HasPowerFrontWindow);
            _featureCommand.Parameters.AddWithValue("@hasPowerRearWindow", feature.HasPowerRearWindow);
            _featureCommand.Parameters.AddWithValue("@hasSunRoof", feature.HasSunRoof);
            _featureCommand.Parameters.AddWithValue("@hasSeatCover", feature.HasSeatCover);
            _featureCommand.Parameters.AddWithValue("@hasBluetooth", feature.HasBluetooth);
            _featureCommand.Parameters.AddWithValue("@hasWIFI", feature.HasWIFI);
            _featureCommand.Parameters.AddWithValue("@hasAUXSupport", feature.HasAUXSupport);
            _featureCommand.Parameters.AddWithValue("@hasUSB", feature.HasUSB);
            _featureCommand.Parameters.AddWithValue("@hasiPod", feature.HasiPod);
            _featureCommand.Parameters.AddWithValue("@hasRadio", feature.HasRadio);
            _featureCommand.Parameters.AddWithValue("@hasCarPlay", feature.HasCarPlay);
            _featureCommand.Parameters.AddWithValue("@hasAndroidAuto", feature.HasAndroidAuto);
            _featureCommand.Parameters.AddWithValue("@hasNavigation", feature.HasNavigation);
            _featureCommand.Parameters.AddWithValue("@hasCompass", feature.HasCompass);
            _featureCommand.Parameters.AddWithValue("@hasFrontSpeaker", feature.HasFrontSpeaker);
            _featureCommand.Parameters.AddWithValue("@hasMiddleSpeaker", feature.HasMiddleSpeaker);
            _featureCommand.Parameters.AddWithValue("@hasRearSpeaker", feature.HasRearSpeaker);
            _featureCommand.Parameters.AddWithValue("@hasClimateControl", feature.HasClimateControl);
            _featureCommand.Parameters.AddWithValue("@hasWeatherSensingWiper", feature.HasWeatherSensingWiper);
            _featureCommand.Parameters.AddWithValue("@hasAC", feature.HasAC);
            _featureCommand.Parameters.AddWithValue("@hasHeater", feature.HasHeater);
            _featureCommand.Parameters.AddWithValue("@hasRemoteTrunkOpener", feature.HasRemoteTrunkOpener);
            _featureCommand.Parameters.AddWithValue("@hasRemoteEngineStart", feature.HasRemoteEngineStart);
            _featureCommand.Parameters.AddWithValue("@hasLowFuelLight", feature.HasLowFuelLight);
            _featureCommand.Parameters.AddWithValue("@hasOilChangeLight", feature.HasOilChangeLight);
            _featureCommand.Parameters.AddWithValue("@hasVehicleServiceLight", feature.HasVehicleServiceLight);
            _featureCommand.Parameters.AddWithValue("@hasRangeMeter", feature.HasRangeMeter);
            _featureCommand.Parameters.AddWithValue("@hasMileageMeter", feature.HasMileageMeter);
            _featureCommand.Parameters.AddWithValue("@hasTemperatureScale", feature.HasTemperatureScale);
            _featureCommand.Parameters.AddWithValue("@hasTrunkLight", feature.HasTrunkLight);
            _featureCommand.Parameters.AddWithValue("@hasRearACDuct", feature.HasRearACDucts);
            _featureCommand.Parameters.AddWithValue("@hasAdjustableHeadRest", feature.HasAdjustableHeadRest);
            _featureCommand.Parameters.AddWithValue("@hasHeadRest", feature.HasHeadRest);
            _featureCommand.Parameters.AddWithValue("@hasBucketSeat", feature.HasBucketSeat);
            _featureCommand.Parameters.AddWithValue("@hasSeatBelt", feature.HasSeatBelt);
            _featureCommand.Parameters.AddWithValue("@hasCupHolder", feature.HasCupHolder);
            _featureCommand.Parameters.AddWithValue("@hasABS", feature.HasABS);
            _featureCommand.Parameters.AddWithValue("@hasFrontHeatedSeat", feature.HasFrontHeatedSeat);
            _featureCommand.Parameters.AddWithValue("@hasRearHeatedSeat", feature.HasRearHeatedSeat);
            _featureCommand.Parameters.AddWithValue("@hasMassageChair", feature.HasMassageChair);
            _featureCommand.Parameters.AddWithValue("@hasSeatInfotainment", feature.HasSeatInfotainment);
            _featureCommand.Parameters.AddWithValue("@hasCruiseControl", feature.HasCruiseControl);
            _featureCommand.Parameters.AddWithValue("@hasFoldableSeat", feature.HasFoldableSeat);
            _featureCommand.Parameters.AddWithValue("@hasKeylessEntry", feature.HasKeylessEntry);
            _featureCommand.Parameters.AddWithValue("@hasFingerprintDoorUnlock", feature.HasFingerprintDoorUnlock);
            _featureCommand.Parameters.AddWithValue("@numberofUSBPorts", feature.USBPorts);
            _featureCommand.Parameters.AddWithValue("@hasCigaretteLighter", feature.HasCigaretteLighter);
            _featureCommand.Parameters.AddWithValue("@hasLuggageNet", feature.HasLuggageNet);
            _featureCommand.Parameters.AddWithValue("@hasConvertibleRoof", feature.HasConvertibleRoof);
            _featureCommand.Parameters.AddWithValue("@hasLaneChangeIndicator", feature.HasLaneChangeIndicator);
            _featureCommand.Parameters.AddWithValue("@hasGearShiftIndicator", feature.HasGearShiftIndicator);
            _featureCommand.Parameters.AddWithValue("@hasFogLamp", feature.HasFogLamp);
            _featureCommand.Parameters.AddWithValue("@hasDigitalWatch", feature.HasDigitalWatch);
            _featureCommand.Parameters.AddWithValue("@hasDrivingMode", feature.HasDrivingModes);
            _featureCommand.Parameters.AddWithValue("@hasGloveCompartment", feature.HasGloveCompartment);
            _featureCommand.Parameters.AddWithValue("@hasHeadLightCleaner", feature.HasHeadLightCleaner);
            _featureCommand.Parameters.AddWithValue("@hasRearLightCleaner", feature.HasRearLightCleaner);
            _featureCommand.Parameters.AddWithValue("@hasRearViewAdjustmentSwitch", feature.HasRearViewAdjustmentSwitch);
            _featureCommand.Parameters.AddWithValue("@hasAlloyWheel", feature.HasAlloyWheel);
            _featureCommand.Parameters.AddWithValue("@hasCarCover", feature.HasCarCover);
            _featureCommand.Parameters.AddWithValue("@hasCentralLock", feature.HasCentralLock);
            _featureCommand.Parameters.AddWithValue("@hasChildSafety", feature.HasChildSafety);
            _featureCommand.Parameters.AddWithValue("@hasNightModeMirror", feature.HasNightVisionMirror);
            _featureCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _featureCommand.ExecuteNonQuery();
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

        public bool DeleteVehicleFeature(int id)
        {
            _featureCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteVehicleFeatures);
            _featureCommand.Parameters.AddWithValue("@vehicleFeaturesId", id);
            _featureCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _featureCommand.ExecuteNonQuery();
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
