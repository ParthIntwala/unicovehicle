import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/TransmissionType.dart';
import '../Utilities/BaseURL.dart';

class TransmissionTypeProvider extends ChangeNotifier {
  List<TransmissionType> _transmissionTypes = [];

  List<TransmissionType> get transmissionTypes {
    return _transmissionTypes;
  }

  Future<void> addTransmissionType(TransmissionType transmissionType) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.transmissionType),
        body: json
            .encode({"GearTransmission": transmissionType.transmissionType}),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> fetchTransmissionType() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.transmissionType));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<TransmissionType> transmission = [];

      body
          .map(
            (transmissions) => transmission.add(
              TransmissionType(
                transmissionType: transmissions["gearTransmission"],
                transmissionTypeId: transmissions["transmissionTypeId"],
              ),
            ),
          )
          .toList();

      _transmissionTypes = transmission;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }

  Future<TransmissionType> getTransmissionType(int id) async {
    if (_transmissionTypes.isEmpty) {
      await fetchTransmissionType();
    }

    return _transmissionTypes
        .firstWhere((element) => element.transmissionTypeId == id);
  }

  Future<void> deleteTransmission(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.transmissionType}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
