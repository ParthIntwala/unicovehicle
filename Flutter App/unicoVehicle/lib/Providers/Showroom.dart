import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Showroom.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/District.dart';

class ShowroomProvider extends ChangeNotifier {
  Future<void> addShowroom(Showroom showroom) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.showroom),
        body: json.encode({
          "district": {"districtId": showroom.district?.districtId},
          "company": {"companyId": showroom.company?.companyId},
          "showroomName": showroom.showroomName,
          "Address": showroom.address,
          "Pincode": showroom.pincode,
          "Manager": showroom.manager,
          "hasSales": showroom.hasSales,
          "hasService": showroom.hasService,
          "isOperational": showroom.isOperational
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

  Future<void> updateShowroom(int id, Showroom showroom) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.showroom}/$id"),
        body: json.encode({
          "district": {"districtId": showroom.district?.districtId},
          "showroomName": showroom.showroomName,
          "Address": showroom.address,
          "Pincode": showroom.pincode,
          "Manager": showroom.manager,
          "hasSales": showroom.hasSales,
          "hasService": showroom.hasService,
          "isOperational": showroom.isOperational
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

  Future<Showroom> getShowroom(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.showroom}/$id"));
      Showroom showroom = new Showroom();
      var body = jsonDecode(response.body);

      if (body["showroomId"] == 0) {
        print(showroom);
        return showroom;
      }

      showroom = new Showroom(
        address: body["address"],
        company: new Company(
          companyId: body["company"]["companyId"],
          company: body["company"]["companyName"],
        ),
        district: new District(
          districtId: body["district"]["districtId"],
          district: body["district"]["districtName"],
        ),
        hasSales: body["hasSales"],
        hasService: body["hasService"],
        isOperational: body["isOperational"],
        manager: body["manager"],
        pincode: body["pincode"],
        showroomId: body["showroomId"],
        showroomName: body["showroomName"],
      );

      return showroom;
    } catch (err) {
      throw err;
    }
  }

  Future<void> deleteShowroom(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.showroom}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
