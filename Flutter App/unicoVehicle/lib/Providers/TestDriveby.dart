import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/TestDrive.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Status.dart';
import '../Models/Miscellaneous/Vehicle.dart';
import '../Models/VehicleVariant.dart';
import '../Models/VehicleName.dart';
import '../Models/Miscellaneous/Showroom.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/District.dart';
import '../Models/Miscellaneous/User.dart';

class TestDrivebyProvider extends ChangeNotifier {
  Future<List<TestDrive>> getTestDrivebyUser(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.userTestDrive}/$id"));
      List<TestDrive> testDrives = [];
      TestDrive testDrive = new TestDrive();
      var stateBody = jsonDecode(response.body) as List<dynamic>;

      if (stateBody.isEmpty) {
        return testDrives;
      }

      stateBody.map((body) {
        testDrive = new TestDrive(
          showroom: new Showroom(
            showroomName: body["showroom"]["showroomName"],
            company: new Company(
              company: body["showroom"]["company"]["companyName"],
              companyId: body["showroom"]["company"]["companyId"],
            ),
            district: new District(
              district: body["showroom"]["district"]["districtName"],
              districtId: body["showroom"]["district"]["districtId"],
            ),
            showroomId: body["showroom"]["showroomId"],
          ),
          status: new Status(
            status: body["testDriveStatus"]["transactionStatus"],
            statusId: body["testDriveStatus"]["statusId"],
          ),
          testDriveDateTime: DateTime.parse(body["testDriveDate"]),
          testDriveId: body["testDriveId"],
          user: new User(
            firstName: body["user"]["firstName"],
            lastName: body["user"]["lastName"],
            userId: body["user"]["userId"],
          ),
          vehicle: new Vehicle(
            vehicleId: body["vehicle"]["vehicleId"],
            vehicleName: new VehicleName(
              vehicleName: body["vehicle"]["vehicleName"]["name"],
              vehicleNameId: body["vehicle"]["vehicleName"]["vehicleNameId"],
              company: new Company(
                company: body["vehicle"]["vehicleName"]["company"]
                    ["companyName"],
                companyId: body["vehicle"]["vehicleName"]["company"]
                    ["companyId"],
              ),
            ),
            vehicleVariant: new VehicleVariant(
              vehicleVariantId: body["vehicle"]["vehicleVariant"]
                  ["vehicleVariantId"],
              vehicleVariant: body["vehicle"]["vehicleVariant"]
                  ["vehicleVariantName"],
              company: new Company(
                company: body["vehicle"]["vehicleVariant"]["company"]
                    ["companyName"],
                companyId: body["vehicle"]["vehicleVariant"]["company"]
                    ["companyId"],
              ),
            ),
          ),
        );

        testDrives.add(testDrive);
      }).toList();

      return testDrives;
    } catch (err) {
      throw err;
    }
  }

  Future<List<TestDrive>> getTestDrivebyShowroom(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.showroomTestDrive}/$id"));
      List<TestDrive> testDrives = [];
      TestDrive testDrive = new TestDrive();

      var testDriveBody = jsonDecode(response.body) as List<dynamic>;

      if (testDriveBody.isEmpty) {
        return testDrives;
      }

      testDriveBody.map((body) {
        testDrive = new TestDrive(
          showroom: new Showroom(
            showroomName: body["showroom"]["showroomName"],
            company: new Company(
              company: body["showroom"]["company"]["companyName"],
              companyId: body["showroom"]["company"]["companyId"],
            ),
            district: new District(
              district: body["showroom"]["district"]["districtName"],
              districtId: body["showroom"]["district"]["districtId"],
            ),
            showroomId: body["showroom"]["showroomId"],
          ),
          status: new Status(
            status: body["testDriveStatus"]["transactionStatus"],
            statusId: body["testDriveStatus"]["statusId"],
          ),
          testDriveDateTime: DateTime.parse(body["testDriveDate"]),
          testDriveId: body["testDriveId"],
          user: new User(
            firstName: body["user"]["firstName"],
            lastName: body["user"]["lastName"],
            userId: body["user"]["userId"],
          ),
          vehicle: new Vehicle(
            vehicleId: body["vehicle"]["vehicleId"],
            vehicleName: new VehicleName(
              vehicleName: body["vehicle"]["vehicleName"]["name"],
              vehicleNameId: body["vehicle"]["vehicleName"]["vehicleNameId"],
              company: new Company(
                company: body["vehicle"]["vehicleName"]["company"]
                    ["companyName"],
                companyId: body["vehicle"]["vehicleName"]["company"]
                    ["companyId"],
              ),
            ),
            vehicleVariant: new VehicleVariant(
              vehicleVariantId: body["vehicle"]["vehicleVariant"]
                  ["vehicleVariantId"],
              vehicleVariant: body["vehicle"]["vehicleVariant"]
                  ["vehicleVariantName"],
              company: new Company(
                company: body["vehicle"]["vehicleVariant"]["company"]
                    ["companyName"],
                companyId: body["vehicle"]["vehicleVariant"]["company"]
                    ["companyId"],
              ),
            ),
          ),
        );

        testDrives.add(testDrive);
      }).toList();

      return testDrives;
    } catch (err) {
      throw err;
    }
  }

  Future<List<TestDrive>> getTestDrivebyShowroomVehicle(
      int vehicleId, int showroomId) async {
    try {
      Map<String, String> params = {
        "vehicleId": "$vehicleId",
      };

      String queryParams = Uri(queryParameters: params).query;
      var response = await http.get(Uri.parse(
          "${BaseURL.testDriveShowroomVehicle}/$showroomId?$queryParams"));
      List<TestDrive> testDrives = [];
      TestDrive testDrive = new TestDrive();
      var stateBody = jsonDecode(response.body) as List<dynamic>;

      if (stateBody.isEmpty) {
        return testDrives;
      }

      stateBody.map((body) {
        testDrive = new TestDrive(
          showroom: new Showroom(
            showroomName: body["showroom"]["showroomName"],
            company: new Company(
              company: body["showroom"]["company"]["companyName"],
              companyId: body["showroom"]["company"]["companyId"],
            ),
            district: new District(
              district: body["showroom"]["district"]["districtName"],
              districtId: body["showroom"]["district"]["districtId"],
            ),
            showroomId: body["showroom"]["showroomId"],
          ),
          status: new Status(
            status: body["testDriveStatus"]["transactionStatus"],
            statusId: body["testDriveStatus"]["statusId"],
          ),
          testDriveDateTime: DateTime.parse(body["testDriveDate"]),
          testDriveId: body["testDriveId"],
          user: new User(
            firstName: body["user"]["firstName"],
            lastName: body["user"]["lastName"],
            userId: body["user"]["userId"],
          ),
          vehicle: new Vehicle(
            vehicleId: body["vehicle"]["vehicleId"],
            vehicleName: new VehicleName(
              vehicleName: body["vehicle"]["vehicleName"]["name"],
              vehicleNameId: body["vehicle"]["vehicleName"]["vehicleNameId"],
              company: new Company(
                company: body["vehicle"]["vehicleName"]["company"]
                    ["companyName"],
                companyId: body["vehicle"]["vehicleName"]["company"]
                    ["companyId"],
              ),
            ),
            vehicleVariant: new VehicleVariant(
              vehicleVariantId: body["vehicle"]["vehicleVariant"]
                  ["vehicleVariantId"],
              vehicleVariant: body["vehicle"]["vehicleVariant"]
                  ["vehicleVariantName"],
              company: new Company(
                company: body["vehicle"]["vehicleVariant"]["company"]
                    ["companyName"],
                companyId: body["vehicle"]["vehicleVariant"]["company"]
                    ["companyId"],
              ),
            ),
          ),
        );

        testDrives.add(testDrive);
      }).toList();

      return testDrives;
    } catch (err) {
      throw err;
    }
  }
}
