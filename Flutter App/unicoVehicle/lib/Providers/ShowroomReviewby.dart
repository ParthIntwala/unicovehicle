import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/ShowroomReview.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/Showroom.dart';
import '../Models/Miscellaneous/User.dart';
import '../Models/Miscellaneous/District.dart';

class ShowroomReviewbyProvider extends ChangeNotifier {
  Future<List<ShowroomReview>> getShowroomReviewbyShowroom(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.showroomReviewShowroom}/$id"));
      List<ShowroomReview> showroomReviews = [];
      ShowroomReview showroomReview = new ShowroomReview();
      var reviewBody = jsonDecode(response.body) as List<dynamic>;

      if (reviewBody.isEmpty) {
        return showroomReviews;
      }

      reviewBody.map((body) {
        showroomReview = new ShowroomReview(
          review: body["review"],
          showroom: new Showroom(
            showroomId: body["showroom"]["showroomId"],
            company: new Company(
              company: body["showroom"]["company"]["companyName"],
              companyId: body["showroom"]["company"]["companyId"],
            ),
            showroomName: body["showroom"]["showroomName"],
            district: new District(
              district: body["showroom"]["district"]["districtName"],
              districtId: body["showroom"]["district"]["districtId"],
            ),
          ),
          showroomReviewId: body["showroomReviewId"],
          user: new User(
            userId: body["user"]["userId"],
            firstName: body["user"]["firstName"],
            lastName: body["user"]["lastName"],
          ),
        );

        showroomReviews.add(showroomReview);
      }).toList();

      return showroomReviews;
    } catch (err) {
      throw err;
    }
  }

  Future<List<ShowroomReview>> getShowroombyUser(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.showroomReviewUser}/$id"));
      List<ShowroomReview> showroomReviews = [];
      ShowroomReview showroomReview = new ShowroomReview();
      var reviewBody = jsonDecode(response.body) as List<dynamic>;

      if (reviewBody.isEmpty) {
        return showroomReviews;
      }

      reviewBody.map((body) {
        showroomReview = new ShowroomReview(
          review: body["review"],
          showroom: new Showroom(
            showroomId: body["showroom"]["showroomId"],
            company: new Company(
              company: body["showroom"]["company"]["companyName"],
              companyId: body["showroom"]["company"]["companyId"],
            ),
            showroomName: body["showroom"]["showroomName"],
            district: new District(
              district: body["showroom"]["district"]["districtName"],
              districtId: body["showroom"]["district"]["districtId"],
            ),
          ),
          showroomReviewId: body["showroomReviewId"],
          user: new User(
            userId: body["user"]["userId"],
            firstName: body["user"]["firstName"],
            lastName: body["user"]["lastName"],
          ),
        );

        showroomReviews.add(showroomReview);
      }).toList();

      return showroomReviews;
    } catch (err) {
      throw err;
    }
  }
}
