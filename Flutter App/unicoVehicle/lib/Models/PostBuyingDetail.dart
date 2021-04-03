import './Miscellaneous/InsuranceCompany.dart';
import './InsuranceType.dart';

class PostBuyingDetail {
  final int postBuyingDetailId;
  final int orderId;
  final InsuranceCompany insuranceCompany;
  final InsuranceType insuranceType;
  final double loanEMI;
  final double insurancePremium;
  final DateTime taxValidity;
  final DateTime insuranceValidity;
  final int freeService;
  final bool paymentReceived;

  PostBuyingDetail({
    this.freeService,
    this.insuranceCompany,
    this.insurancePremium,
    this.insuranceType,
    this.insuranceValidity,
    this.loanEMI,
    this.orderId,
    this.paymentReceived,
    this.postBuyingDetailId,
    this.taxValidity,
  });
}
