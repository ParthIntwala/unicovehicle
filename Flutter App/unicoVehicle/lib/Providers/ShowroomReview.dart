import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/ShowroomReview.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/User.dart';
import '../Models/Miscellaneous/Showroom.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/District.dart';

class ShowroomReviewProvider extends ChangeNotifier {
  Future<void> addReview(ShowroomReview showroomReview) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.showroomReview),
        body: json.encode({
          "showroom": {"ShowroomId": showroomReview.showroom?.showroomId},
          "user": {"UserId": showroomReview.user?.userId},
          "review": showroomReview.review
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

  Future<void> updateReview(int id, ShowroomReview showroomReview) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.showroomReview}/$id"),
        body: json.encode({"review": showroomReview.review}),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<ShowroomReview> getShowroomReview(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.showroomReview}/$id"));
      ShowroomReview showroomReview = new ShowroomReview();
      var body = jsonDecode(response.body);

      if (body["showroomReviewId"] == 0) {
        return showroomReview;
      }

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

      return showroomReview;
    } catch (err) {
      throw err;
    }
  }

  Future<void> deleteShowroomReview(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.showroomReview}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}
