import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Country.dart';
import '../Utilities/BaseURL.dart';

class CountryProvider extends ChangeNotifier {
  List<Country> _countries = [];

  List<Country> get countries {
    return _countries;
  }

  Future<void> fetchCountries() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.country));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<Country> loadedCountries = [];

      body
          .map(
            (country) => loadedCountries.add(
              Country(
                countryId: country["countryId"],
                country: country["countryName"],
              ),
            ),
          )
          .toList();

      _countries = loadedCountries;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }

  Future<void> addCountry(Country country) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.country),
        body: json.encode(
          {
            "CountryName": country.country,
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

  Future<void> deleteCompany(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.country}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
