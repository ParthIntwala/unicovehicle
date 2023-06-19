import 'package:flutter/cupertino.dart';
import 'package:flutter_carousel_widget/flutter_carousel_widget.dart';

class Carousal extends StatelessWidget {
  final double width;
  const Carousal({required this.width, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 200,
      margin: const EdgeInsets.symmetric(vertical: 20),
      child: FlutterCarousel(
        items: [
          Image.asset(
            "assets/F12017.jpeg",
            height: 200,
            width: width * 0.95,
          ),
          Image.asset(
            "assets/Lewis.png",
            height: 200,
            width: width * 0.95,
          ),
          Image.asset(
            "assets/MclarenF1.jpeg",
            height: 200,
            width: width * 0.95,
          ),
          Image.asset(
            "assets/Senna.jpeg",
            height: 200,
            width: width * 0.95,
          ),
          Image.asset(
            "assets/SF90.png",
            height: 200,
            width: width * 0.95,
          ),
        ],
        options: CarouselOptions(
          autoPlay: true,
          autoPlayAnimationDuration: const Duration(
            milliseconds: 300,
          ),
          showIndicator: false,
          autoPlayInterval: const Duration(
            seconds: 2,
          ),
          height: 200,
          enlargeCenterPage: true,
          aspectRatio: 16 / 9,
        ),
      ),
    );
  }
}
