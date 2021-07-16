import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/State.dart' as local;
import '../Utilities/BaseURL.dart';
import '../Models/Country.dart';

class StatebyProvider extends ChangeNotifier {
  Future<List<local.State>> getStatebyCountry(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.stateCountry}/$id"));
      List<local.State> states = [];
      local.State state = new local.State();
      var stateBody = jsonDecode(response.body) as List<dynamic>;

      if (stateBody.isEmpty) {
        return states;
      }

      stateBody.map((body) {
        state = new local.State(
          country: Country(
            country: body["countryName"]["countryName"],
            countryId: body["countryName"]["countryId"],
          ),
          state: body["stateName"],
          stateId: body["stateId"],
        );

        states.add(state);
      }).toList();

      return states;
    } catch (err) {
      throw err;
    }
  }
}
