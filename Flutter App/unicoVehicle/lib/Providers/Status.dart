import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Status.dart';
import '../Utilities/BaseURL.dart';

class StatusProvider extends ChangeNotifier {
  List<Status> _statuses = [];

  List<Status> get statuses {
    return _statuses;
  }

  Future<void> addStatus(Status status) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.status),
        body: json.encode({"TransactionStatus": status.status}),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> updateStatus(int id, Status status) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.status}/$id"),
        body: json.encode({"TransactionStatus": status.status}),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> fetchStatus() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.status));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<Status> status = [];

      body
          .map(
            (transactionStatus) => status.add(
              Status(
                status: transactionStatus["transactionStatus"],
                statusId: transactionStatus["statusId"],
              ),
            ),
          )
          .toList();

      _statuses = status;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }

  Future<Status> getStatus(int id) async {
    if (_statuses.isEmpty) {
      await fetchStatus();
    }

    return _statuses.firstWhere((element) => element.statusId == id);
  }

  Future<void> deleteStatus(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.status}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
