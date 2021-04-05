import './UserType.dart';

class User {
  final int? userId;
  final UserType? userType;
  final String? firstName;
  final String? lastName;
  final String? email;

  User({
    this.email,
    this.firstName,
    this.lastName,
    this.userId,
    this.userType,
  });
}
