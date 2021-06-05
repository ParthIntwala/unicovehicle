import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Customer.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/User.dart';
import '../Models/Miscellaneous/District.dart';

class CustomerProvider extends ChangeNotifier {
  Future<void> addCustomer(Customer customer) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.customer),
        body: json.encode({
          "user": {
            "UserId": customer.user?.userId,
          },
          "district": {
            "DistrictId": customer.district?.districtId,
          },
          "address": customer.address,
          "photograph": customer.photograph,
          "drivingLicenseNumber": customer.drivingLicenseNumber,
          "standardIDNumber": customer.standardIDNumber,
          "incomeTaxIDNumber": customer.incomeTaxIDNumber,
          "lastITReturn": customer.lastITReturn,
          "bankPassbookPhoto": customer.bankPassbookPhoto,
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

  Future<void> updateCustomer(int id, Customer customer) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.customer}/$id"),
        body: json.encode({
          "district": {
            "DistrictId": customer.district?.districtId,
          },
          "address": customer.address,
          "photograph": customer.photograph,
          "drivingLicenseNumber": customer.drivingLicenseNumber,
          "lastITReturn": customer.lastITReturn,
          "bankPassbookPhoto": customer.bankPassbookPhoto,
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

  Future<void> deleteCustomer(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.customer}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<Customer> getCustomer(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.customer}/$id"));
      Customer customer = new Customer();
      var body = jsonDecode(response.body);

      if (body["customerId"] == 0) {
        return customer;
      }

      customer = Customer(
        address: body["address"],
        customerId: body["customerId"],
        bankPassbookPhoto: body["bankPassbookPhoto"],
        drivingLicenseNumber: body["drivingLicenseNumber"],
        incomeTaxIDNumber: body["incomeTaxIDNumber"],
        lastITReturn: body["lastITReturn"],
        photograph: body["photograph"],
        standardIDNumber: body["standardIDNumber"],
        district: new District(
          district: body["district"]["districtName"],
          districtId: body["district"]["districtId"],
        ),
        user: new User(
          firstName: body["user"]["firstName"],
          lastName: body["user"]["lastName"],
          userId: body["user"]["userId"],
        ),
      );

      return customer;
    } catch (err) {
      throw err;
    }
  }
}
