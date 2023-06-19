import 'package:flutter/cupertino.dart';

//utilities
import '../../Utilities/themes.dart';

class Brands extends StatelessWidget {
  final String image;
  final double width;

  const Brands({required this.image, required this.width, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        border: Border.all(
          color: Themes.themeColor1,
          width: 1,
        ),
      ),
      child: Padding(
        padding: const EdgeInsets.all(10.0),
        child: Image.asset(
          image,
          width: width / 3,
        ),
      ),
    );
  }
}
