import 'package:flutter/cupertino.dart';

//widgets
import './brands.dart';
//utilities
import '../../Utilities/themes.dart';

class BrandGrid extends StatelessWidget {
  final double width;
  BrandGrid({required this.width, super.key});

  final List<String> images = [
    "assets/Aston Martin.png",
    "assets/BMW.png",
    "assets/Ferrari.png",
    "assets/Lexus.png",
    "assets/Lincoln.png",
    "assets/Maserati.png",
    "assets/Mercedes Benz.png",
    "assets/Porsche.png",
    "assets/Tesla.png",
  ];

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.all(10),
      decoration: BoxDecoration(
        border: Border.all(
          color: Themes.themeColor1,
          width: 1,
        ),
      ),
      height: width - 20,
      child: GridView.builder(
        physics: const NeverScrollableScrollPhysics(),
        gridDelegate:
            const SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 3),
        itemBuilder: (ctx, index) => Brands(image: images[index], width: width),
        itemCount: images.length,
      ),
    );
  }
}
