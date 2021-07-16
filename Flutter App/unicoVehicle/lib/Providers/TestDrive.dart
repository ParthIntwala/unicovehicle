import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/TestDrive.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/User.dart';
import '../Models/Miscellaneous/Showroom.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/District.dart';
import '../Models/Miscellaneous/Vehicle.dart';
import '../Models/Status.dart';
import '../Models/VehicleName.dart';
import '../Models/VehicleVariant.dart';

class TestDriveProvider extends ChangeNotifier {
  Future<void> addTestDrive(TestDrive testDrive) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.testDrive),
        body: json.encode({
          "User": {"UserId": testDrive.user?.userId},
          "Showroom": {"ShowroomId": testDrive.showroom?.showroomId},
          "Vehicle": {"VehicleId": testDrive.vehicle?.vehicleId},
          "TestDriveStatus": {"StatusId": testDrive.status?.statusId},
          "TestDriveDate": testDrive.testDriveDateTime?.toIso8601String()
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

  Future<void> updateStatus(int id, TestDrive testDrive) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.testDrive}/$id"),
        body: json.encode({
          "TestDriveStatus": {"StatusId": testDrive.status?.statusId},
          "TestDriveDate": testDrive.testDriveDateTime?.toIso8601String()
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

  Future<TestDrive> getTestDrive(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.testDrive}/$id"));
      TestDrive testDrive = new TestDrive();
      var body = jsonDecode(response.body);

      if (body["testDriveId"] == 0) {
        return testDrive;
      }

      testDrive = TestDrive(
        testDriveDateTime: DateTime.parse(body["testDriveDate"]),
        testDriveId: body["testDriveId"],
        showroom: new Showroom(
          showroomId: body["showroom"]["showroomId"],
          company: new Company(
            company: body["showroom"]["company"]["companyName"],
            companyId: body["showroom"]["company"]["companyId"],
          ),
          district: new District(
            district: body["showroom"]["district"]["districtName"],
            districtId: body["showroom"]["district"]["districtId"],
          ),
          showroomName: body["showroom"]["showroomName"],
        ),
        status: new Status(
          status: body["testDriveStatus"]["transactionStatus"],
          statusId: body["testDriveStatus"]["statusId"],
        ),
        user: new User(
          firstName: body["user"]["firstName"],
          lastName: body["user"]["lastName"],
          userId: body["user"]["userId"],
        ),
        vehicle: new Vehicle(
          vehicleId: body["vehicle"]["vehicleId"],
          vehicleName: new VehicleName(
            company: new Company(
              company: body["vehicle"]["vehicleName"]["company"]["companyName"],
              companyId: body["vehicle"]["vehicleName"]["company"]["companyId"],
            ),
            vehicleName: body["vehicle"]["vehicleName"]["name"],
            vehicleNameId: body["vehicle"]["vehicleName"]["vehicleNameId"],
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
        ),
      );

      return testDrive;
    } catch (err) {
      throw err;
    }
  }
}
