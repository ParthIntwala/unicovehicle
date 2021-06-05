import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Order.dart';
import '../Utilities/BaseURL.dart';
import '../Models/User.dart';
import '../Models/Vehicle.dart';
import '../Models/Showroom.dart';
import '../Models/Status.dart';
import '../Models/Customer.dart';

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
          "DeliveryDate": order.deliveryDate,
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
          "DeliveryDate": order.deliveryDate,
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
