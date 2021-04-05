class RegisterUser {
  final int? userId;
  final int? userTypeId;
  final String? firstName;
  final String? lastName;
  final String? email;
  final String? password;

  RegisterUser({
    this.email,
    this.firstName,
    this.lastName,
    this.password,
    this.userId,
    this.userTypeId,
  });
}
