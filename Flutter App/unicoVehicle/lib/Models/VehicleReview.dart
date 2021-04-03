import './User.dart';
import './Miscellaneous/Vehicle.dart';

class VehicleReview {
  final int vehicleReviewId;
  final String review;
  final User user;
  final Vehicle vehicle;

  VehicleReview({
    this.review,
    this.user,
    this.vehicle,
    this.vehicleReviewId,
  });
}
