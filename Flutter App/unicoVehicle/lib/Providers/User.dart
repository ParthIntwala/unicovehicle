import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/User.dart';
import '../Models/UserType.dart';
import '../Utilities/BaseURL.dart';

class UserProvider extends ChangeNotifier {
  Future<void> updateUser(int id, User user) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.user}/$id"),
        body: json
            .encode({"firstName": user.firstName, "lastName": user.lastName}),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<User> getUser(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.user}/$id"));
      var body = jsonDecode(response.body);
      User user = new User();

      if (body["userId"] == 0) {
        return user;
      }

      user = User(
        email: body["email"],
        firstName: body["firstName"],
        lastName: body["lastName"],
        userId: body["userId"],
        userType: new UserType(
          userType: body["userType"]["usersType"],
          userTypeId: body["userType"]["userTypeId"],
        ),
      );

      print(user.userType?.userType);

      return user;
    } catch (err) {
      throw (err);
    }
  }

  Future<void> deleteUser(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.user}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
