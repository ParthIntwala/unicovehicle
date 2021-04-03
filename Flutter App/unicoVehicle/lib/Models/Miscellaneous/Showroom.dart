import './Company.dart';
import './District.dart';

class Showroom {
  final int showroomId;
  final Company company;
  final District district;
  final String showroomName;

  Showroom({
    this.company,
    this.district,
    this.showroomId,
    this.showroomName,
  });
}
