import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Showroom.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/District.dart';

class ShowroombyProvider extends ChangeNotifier {
  Future<List<Showroom>> getShowroombyCompany(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.showroomCompany}/$id"));
      List<Showroom> showrooms = [];
      Showroom showroom = new Showroom();
      var showroomBody = jsonDecode(response.body) as List<dynamic>;

      if (showroomBody.isEmpty) {
        return showrooms;
      }

      showroomBody.map((body) {
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

        showrooms.add(showroom);
      }).toList();

      return showrooms;
    } catch (err) {
      throw err;
    }
  }

  Future<List<Showroom>> getShowroombyDistrict(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.showroomDistrict}/$id"));
      List<Showroom> showrooms = [];
      Showroom showroom = new Showroom();
      var showroomBody = jsonDecode(response.body) as List<dynamic>;

      if (showroomBody.isEmpty) {
        return showrooms;
      }

      showroomBody.map((body) {
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

        showrooms.add(showroom);
      }).toList();

      return showrooms;
    } catch (err) {
      throw err;
    }
  }
}
