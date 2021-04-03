import './Vehicle.dart';
import './Showroom.dart';
import './Status.dart';
import './Customer.dart';

class Order {
  final int orderId;
  final Vehicle vehicle;
  final Showroom showroom;
  final Status status;
  final Customer customer;
  final double finalPrice;
  final bool hasLoan;
  final DateTime deliveryDate;

  Order({
    this.customer,
    this.deliveryDate,
    this.finalPrice,
    this.hasLoan,
    this.orderId,
    this.showroom,
    this.status,
    this.vehicle,
  });
}
