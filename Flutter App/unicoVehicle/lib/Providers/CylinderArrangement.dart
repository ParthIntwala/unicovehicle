import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/CylinderArrangement.dart';
import '../Utilities/BaseURL.dart';

class CylinderArrangementProvider extends ChangeNotifier {
  List<CylinderArrangement> _arrangements = [];

  List<CylinderArrangement> get arrangements {
    return _arrangements;
  }

  Future<void> fetchCylinderArrangement() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.cylinderArrangement));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<CylinderArrangement> loadedArrangements = [];

      body
          .map(
            (arrangement) => loadedArrangements.add(
              CylinderArrangement(
                cylinderArrangementId: arrangement["cylinderArrangementId"],
                cylinderArrangement: arrangement["cylinderArrangementName"],
              ),
            ),
          )
          .toList();

      _arrangements = loadedArrangements;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }

  Future<void> addCylinderArrangement(CylinderArrangement arrangement) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.cylinderArrangement),
        body: json.encode(
          {
            "CylinderArrangementName": arrangement.cylinderArrangement,
          },
        ),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> deleteCylinderArrangement(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.cylinderArrangement}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
