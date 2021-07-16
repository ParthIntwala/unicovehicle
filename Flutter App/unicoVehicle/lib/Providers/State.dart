import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Utilities/BaseURL.dart';
import '../Models/State.dart' as local;
import '../Models/Country.dart';

class StateProvider extends ChangeNotifier {
  Future<void> addState(local.State state) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.state),
        body: json.encode({
          "StateName": state.state,
          "CountryName": {"CountryId": state.country?.countryId}
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

  Future<void> deleteState(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.state}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<local.State> getState(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.state}/$id"));
      local.State state = new local.State();
      var body = jsonDecode(response.body);

      if (body["stateId"] == 0) {
        return state;
      }

      state = local.State(
        state: body["stateName"],
        country: new Country(
          country: body["countryName"]["countryName"],
          countryId: body["countryName"]["countryId"],
        ),
        stateId: body["stateId"],
      );

      return state;
    } catch (err) {
      throw err;
    }
  }
}
