import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Order.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/User.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Vehicle.dart';
import '../Models/Showroom.dart';
import '../Models/Status.dart';
import '../Models/Customer.dart';
import '../Models/Miscellaneous/District.dart';
import '../Models/CylinderArrangement.dart';
import '../Models/FuelType.dart';
import '../Models/TransmissionType.dart';
import '../Models/VehicleFeatures.dart';
import '../Models/VehicleName.dart';
import '../Models/VehicleType.dart';
import '../Models/VehicleVariant.dart';

class OrderProvider extends ChangeNotifier {
  Future<void> addOrder(Order order) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.order),
        body: json.encode({
          "Vehicle": {
            "VehicleId": order.vehicle?.vehicleId,
          },
          "Showroom": {
            "ShowroomId": order.showroom?.showroomId,
          },
          "OrderStatus": {
            "StatusId": order.status?.statusId,
          },
          "Customer": {
            "CustomerId": order.customer?.customerId,
          },
          "FinalPrice": order.finalPrice,
          "hasLoan": order.hasLoan,
          "DeliveryDate": order.deliveryDate?.toIso8601String(),
        }),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> updateOrder(int id, Order order) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.order}/$id"),
        body: json.encode({
          "FinalPrice": order.finalPrice,
          "DeliveryDate": order.deliveryDate?.toIso8601String(),
        }),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> updateOrderStatus(int id, Status status) async {
    try {
      Map<String, String> params = {
        "id": "$id",
      };

      String queryParams = Uri(queryParameters: params).query;

      var response = await http.put(
        Uri.parse("${BaseURL.order}?$queryParams"),
        body: json.encode({
          "StatusId": status.statusId,
        }),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<Order> getOrder(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.order}/$id"));
      Order order = new Order();
      var body = jsonDecode(response.body);

      if (body["orderId"] == 0) {
        return order;
      }

      order = new Order(
        orderId: body["orderId"],
        hasLoan: body["hasLoan"],
        deliveryDate: DateTime.parse(body["deliveryDate"]),
        finalPrice: double.parse(body["finalPrice"].toString()),
        customer: new Customer(
          customerId: body["customer"]["customerId"],
          address: body["customer"]["address"],
          bankPassbookPhoto: body["customer"]["bankPassbookPhoto"],
          drivingLicenseNumber: body["customer"]["drivingLicenseNumber"],
          incomeTaxIDNumber: body["customer"]["incomeTaxIDNumber"],
          lastITReturn: body["customer"]["lastITReturn"],
          photograph: body["customer"]["photograph"],
          standardIDNumber: body["customer"]["standardIDNumber"],
          district: new District(
            district: body["customer"]["district"]["districtName"],
            districtId: body["customer"]["district"]["districtId"],
          ),
          user: new User(
            userId: body["customer"]["user"]["userId"],
            firstName: body["customer"]["user"]["firstName"],
            lastName: body["customer"]["user"]["lastName"],
          ),
        ),
        showroom: new Showroom(
          address: body["showroom"]["address"],
          hasSales: body["showroom"]["hasSales"],
          hasService: body["showroom"]["hasService"],
          isOperational: body["showroom"]["isOperational"],
          manager: body["showroom"]["manager"],
          pincode: body["showroom"]["pincode"],
          showroomId: body["showroom"]["showroomId"],
          showroomName: body["showroom"]["showroomName"],
          company: new Company(
            company: body["showroom"]["company"]["companyName"],
            companyId: body["showroom"]["company"]["companyId"],
          ),
          district: new District(
            district: body["showroom"]["district"]["districtName"],
            districtId: body["showroom"]["district"]["districtId"],
          ),
        ),
        status: new Status(
          status: body["orderStatus"]["transactionStatus"],
          statusId: body["orderStatus"]["statusId"],
        ),
        vehicle: new Vehicle(
          doors: body["vehicle"]["doors"],
          cylinder: body["vehicle"]["cylinder"],
          engineSize: body["vehicle"]["engineSize"],
          fuelTankSize:
              double.parse(body["vehicle"]["fuelTankSize"].toString()),
          grossWeight: double.parse(body["vehicle"]["grossWeight"].toString()),
          groundClearance:
              double.parse(body["vehicle"]["groundClearance"].toString()),
          height: double.parse(body["vehicle"]["height"].toString()),
          cylinderArrangement: new CylinderArrangement(
            cylinderArrangement: body["vehicle"]["cylinderArrangement"]
                ["cylinderArrangementName"],
            cylinderArrangementId: body["vehicle"]["cylinderArrangement"]
                ["cylinderArrangementId"],
          ),
          fuelType: new FuelType(
            fuelType: body["vehicle"]["fuelType"]["fuelTypeName"],
            fuelTypeId: body["vehicle"]["fuelType"]["fuelTypeId"],
          ),
          horsePower: double.parse(body["vehicle"]["horsePower"].toString()),
          kerbWeight: double.parse(body["vehicle"]["kerbWeight"].toString()),
          length: double.parse(body["vehicle"]["length"].toString()),
          mileage: double.parse(body["vehicle"]["mileage"].toString()),
          passenger: body["vehicle"]["passenger"],
          torque: double.parse(body["vehicle"]["torque"].toString()),
          transmissionType: new TransmissionType(
            transmissionType: body["vehicle"]["transmissionType"]
                ["gearTransmission"],
            transmissionTypeId: body["vehicle"]["transmissionType"]
                ["transmissionTypeId"],
          ),
          vehicleFeatures: new VehicleFeatures(
            airbagCount: body["vehicle"]["vehicleFeatures"]["airbagCount"],
            hasABS: body["vehicle"]["vehicleFeatures"]["hasABS"],
            hasAC: body["vehicle"]["vehicleFeatures"]["hasAC"],
            hasAUXSupport: body["vehicle"]["vehicleFeatures"]["hasAUXSupport"],
            hasAdjustableHeadRest: body["vehicle"]["vehicleFeatures"]
                ["hasAdjustableHeadRest"],
            hasAlloyWheel: body["vehicle"]["vehicleFeatures"]["hasAlloyWheel"],
            hasAndroidAuto: body["vehicle"]["vehicleFeatures"]
                ["hasAndroidAuto"],
            hasBluetooth: body["vehicle"]["vehicleFeatures"]["hasBluetooth"],
            hasBucketSeat: body["vehicle"]["vehicleFeatures"]["hasBucketSeat"],
            hasCarCover: body["vehicle"]["vehicleFeatures"]["hasCarCover"],
            hasCarPlay: body["vehicle"]["vehicleFeatures"]["hasCarPlay"],
            hasCentralLock: body["vehicle"]["vehicleFeatures"]
                ["hasCentralLock"],
            hasChildSafety: body["vehicle"]["vehicleFeatures"]
                ["hasChildSafety"],
            hasCigaretteLighter: body["vehicle"]["vehicleFeatures"]
                ["hasCigaretteLighter"],
            hasClimateControl: body["vehicle"]["vehicleFeatures"]
                ["hasClimateControl"],
            hasCompass: body["vehicle"]["vehicleFeatures"]["hasCompass"],
            hasConvertibleRoof: body["vehicle"]["vehicleFeatures"]
                ["hasConvertibleRoof"],
            hasCruiseControl: body["vehicle"]["vehicleFeatures"]
                ["hasCruiseControl"],
            hasCupHolder: body["vehicle"]["vehicleFeatures"]["hasCupHolder"],
            hasDigitalWatch: body["vehicle"]["vehicleFeatures"]
                ["hasDigitalWatch"],
            hasDrivingModes: body["vehicle"]["vehicleFeatures"]
                ["hasDrivingModes"],
            hasFingerprintDoorUnlock: body["vehicle"]["vehicleFeatures"]
                ["hasFingerprintDoorUnlock"],
            hasFogLamp: body["vehicle"]["vehicleFeatures"]["hasFogLamp"],
            hasFoldableSeat: body["vehicle"]["vehicleFeatures"]
                ["hasFoldableSeat"],
            hasFrontHeatedSeat: body["vehicle"]["vehicleFeatures"]
                ["hasFrontHeatedSeat"],
            hasFrontSpeaker: body["vehicle"]["vehicleFeatures"]
                ["hasFrontSpeaker"],
            hasGearShiftIndicator: body["vehicle"]["vehicleFeatures"]
                ["hasGearShiftIndicator"],
            hasGloveCompartment: body["vehicle"]["vehicleFeatures"]
                ["hasGloveCompartment"],
            hasHeadLightCleaner: body["vehicle"]["vehicleFeatures"]
                ["hasHeadLightCleaner"],
            hasHeadRest: body["vehicle"]["vehicleFeatures"]["hasHeadRest"],
            hasHeater: body["vehicle"]["vehicleFeatures"]["hasHeater"],
            hasKeylessEntry: body["vehicle"]["vehicleFeatures"]
                ["hasKeylessEntry"],
            hasLaneChangeIndicator: body["vehicle"]["vehicleFeatures"]
                ["hasLaneChangeIndicator"],
            hasLowFuelLight: body["vehicle"]["vehicleFeatures"]
                ["hasLowFuelLight"],
            hasLuggageNet: body["vehicle"]["vehicleFeatures"]["hasLuggageNet"],
            hasMassageChair: body["vehicle"]["vehicleFeatures"]
                ["hasMassageChair"],
            hasMiddleSpeaker: body["vehicle"]["vehicleFeatures"]
                ["hasMiddleSpeaker"],
            hasMileageMeter: body["vehicle"]["vehicleFeatures"]
                ["hasMileageMeter"],
            hasNavigation: body["vehicle"]["vehicleFeatures"]["hasNavigation"],
            hasNightVisionMirror: body["vehicle"]["vehicleFeatures"]
                ["hasNightVisionMirror"],
            hasOilChangeLight: body["vehicle"]["vehicleFeatures"]
                ["hasOilChangeLight"],
            hasPowerFrontWindow: body["vehicle"]["vehicleFeatures"]
                ["hasPowerFrontWindow"],
            hasPowerRearWindow: body["vehicle"]["vehicleFeatures"]
                ["hasPowerRearWindow"],
            hasPowerSteering: body["vehicle"]["vehicleFeatures"]
                ["hasPowerSteering"],
            hasRadio: body["vehicle"]["vehicleFeatures"]["hasRadio"],
            hasRangeMeter: body["vehicle"]["vehicleFeatures"]["hasRangeMeter"],
            hasRearACDucts: body["vehicle"]["vehicleFeatures"]
                ["hasRearACDucts"],
            hasRearHeatedSeat: body["vehicle"]["vehicleFeatures"]
                ["hasRearHeatedSeat"],
            hasRearLightCleaner: body["vehicle"]["vehicleFeatures"]
                ["hasRearLightCleaner"],
            hasRearSpeaker: body["vehicle"]["vehicleFeatures"]
                ["hasRearSpeaker"],
            hasRearViewAdjustmentSwitch: body["vehicle"]["vehicleFeatures"]
                ["hasRearViewAdjustmentSwitch"],
            hasRemoteEngineStart: body["vehicle"]["vehicleFeatures"]
                ["hasRemoteEngineStart"],
            hasRemoteTrunkOpener: body["vehicle"]["vehicleFeatures"]
                ["hasRemoteTrunkOpener"],
            hasSeatBelt: body["vehicle"]["vehicleFeatures"]["hasSeatBelt"],
            hasSeatCover: body["vehicle"]["vehicleFeatures"]["hasSeatCover"],
            hasSeatInfotainment: body["vehicle"]["vehicleFeatures"]
                ["hasSeatInfotainment"],
            hasSunRoof: body["vehicle"]["vehicleFeatures"]["hasSunRoof"],
            hasTemperatureScale: body["vehicle"]["vehicleFeatures"]
                ["hasTemperatureScale"],
            hasTrunkLight: body["vehicle"]["vehicleFeatures"]["hasTrunkLight"],
            hasUSB: body["vehicle"]["vehicleFeatures"]["hasUSB"],
            hasVehicleServiceLight: body["vehicle"]["vehicleFeatures"]
                ["hasVehicleServiceLight"],
            hasWIFI: body["vehicle"]["vehicleFeatures"]["hasWIFI"],
            hasWeatherSensingWiper: body["vehicle"]["vehicleFeatures"]
                ["hasWeatherSensingWiper"],
            hasiPod: body["vehicle"]["vehicleFeatures"]["hasiPod"],
            usbPorts: body["vehicle"]["vehicleFeatures"]["usbPorts"],
            vehicleFeaturesId: body["vehicle"]["vehicleFeatures"]
                ["vehicleFeaturesId"],
          ),
          vehicleId: body["vehicle"]["vehicleId"],
          vehicleName: new VehicleName(
            company: new Company(
              company: body["vehicle"]["vehicleName"]["company"]["companyName"],
              companyId: body["vehicle"]["vehicleName"]["company"]["companyId"],
            ),
            vehicleName: body["vehicle"]["vehicleName"]["name"],
            vehicleNameId: body["vehicle"]["vehicleName"]["vehicleNameId"],
          ),
          vehicleType: new VehicleType(
            vehicleType: body["vehicle"]["vehicleType"]["vehicleTypeName"],
            vehicleTypeId: body["vehicle"]["vehicleType"]["vehicleTypeId"],
          ),
          vehicleVariant: new VehicleVariant(
            company: new Company(
              company: body["vehicle"]["vehicleVariant"]["company"]
                  ["companyName"],
              companyId: body["vehicle"]["vehicleVariant"]["company"]
                  ["companyId"],
            ),
            vehicleVariant: body["vehicle"]["vehicleVariant"]
                ["vehicleVariantName"],
            vehicleVariantId: body["vehicle"]["vehicleVariant"]
                ["vehicleVariantId"],
          ),
          wheelBase: double.parse(body["vehicle"]["wheelBase"].toString()),
          width: double.parse(body["vehicle"]["width"].toString()),
        ),
      );

      return order;
    } catch (err) {
      throw err;
    }
  }
}
