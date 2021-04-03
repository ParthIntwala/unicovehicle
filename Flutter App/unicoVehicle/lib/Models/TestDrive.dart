import './Status.dart';
import './Miscellaneous/User.dart';
import './Miscellaneous/Vehicle.dart';
import './Miscellaneous/Showroom.dart';

class TestDrive {
  final int testDriveId;
  final User user;
  final Vehicle vehicle;
  final Showroom showroom;
  final Status status;
  final DateTime testDriveDateTime;

  TestDrive({
    this.showroom,
    this.status,
    this.testDriveDateTime,
    this.testDriveId,
    this.user,
    this.vehicle,
  });
}
