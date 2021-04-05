import './Miscellaneous/Showroom.dart';
import './Miscellaneous/User.dart';

class ShowroomReview {
  final int? showroomReviewId;
  final Showroom? showroom;
  final User? user;
  final String? review;

  ShowroomReview({
    this.review,
    this.showroom,
    this.showroomReviewId,
    this.user,
  });
}
