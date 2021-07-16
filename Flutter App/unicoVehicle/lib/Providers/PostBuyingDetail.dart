import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/PostBuyingDetail.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/InsuranceCompany.dart';
import '../Models/InsuranceType.dart';

class PostBuyingDetailProvider extends ChangeNotifier {
  Future<void> addPostBuyingDetail(PostBuyingDetail postBuyingDetail) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.postBuyingDetail),
        body: json.encode({
          "OrderId": postBuyingDetail.orderId,
          "InsuranceCompany": {
            "InsuranceCompanyId":
                postBuyingDetail.insuranceCompany?.insuranceCompanyId
          },
          "InsuranceType": {
            "InsuranceTypeId": postBuyingDetail.insuranceType?.insuranceTypeId
          },
          "LoanEMI": postBuyingDetail.loanEMI,
          "InsurancePremium": postBuyingDetail.insurancePremium,
          "TaxValidity": postBuyingDetail.taxValidity?.toIso8601String(),
          "InsuranceValidity":
              postBuyingDetail.insuranceValidity?.toIso8601String(),
          "FreeService": postBuyingDetail.freeService,
          "PaymentReceived": postBuyingDetail.paymentReceived
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

  Future<void> updatePostBuyingDetail(
      int id, PostBuyingDetail postBuyingDetail) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.postBuyingDetail}/$id"),
        body: json.encode({
          "InsuranceCompany": {
            "InsuranceCompanyId":
                postBuyingDetail.insuranceCompany?.insuranceCompanyId
          },
          "InsuranceType": {
            "InsuranceTypeId": postBuyingDetail.insuranceType?.insuranceTypeId
          },
          "InsurancePremium": postBuyingDetail.insurancePremium,
          "TaxValidity": postBuyingDetail.taxValidity?.toIso8601String(),
          "InsuranceValidity":
              postBuyingDetail.insuranceValidity?.toIso8601String(),
          "FreeService": postBuyingDetail.freeService,
          "PaymentReceived": postBuyingDetail.paymentReceived
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

  Future<PostBuyingDetail> getPostBuyingDeatil(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.postBuyingDetail}/$id"));
      PostBuyingDetail postBuyingDetail = new PostBuyingDetail();
      var body = jsonDecode(response.body);

      if (body["postBuyingDetailId"] == 0) {
        return postBuyingDetail;
      }

      postBuyingDetail = new PostBuyingDetail(
        orderId: body["orderId"],
        postBuyingDetailId: body["postBuyingDetailId"],
        freeService: body["freeService"],
        insuranceCompany: new InsuranceCompany(
          insuranceCompany: body["insuranceCompany"]["insuranceCompanyName"],
          insuranceCompanyId: body["insuranceCompany"]["insuranceCompanyId"],
        ),
        insurancePremium: double.parse(body["insurancePremium"]),
        insuranceType: new InsuranceType(
          insuranceTypeId: body["insuranceType"]["insuranceTypeId"],
          insuranceType: body["insuranceType"]["insuranceTypeName"],
          insuranceCompany: new InsuranceCompany(
            insuranceCompany: body["insuranceType"]["insuranceCompany"]
                ["insuranceCompanyName"],
            insuranceCompanyId: body["insuranceType"]["insuranceCompany"]
                ["insuranceCompanyId"],
          ),
        ),
        insuranceValidity: DateTime.parse(body["insuranceValidity"]),
        loanEMI: double.parse(body["loanEMI"]),
        paymentReceived: body["paymentReceived"],
        taxValidity: DateTime.parse(body["taxValidity"]),
      );

      print(postBuyingDetail.insuranceCompany?.insuranceCompany);

      return postBuyingDetail;
    } catch (err) {
      throw err;
    }
  }
}
