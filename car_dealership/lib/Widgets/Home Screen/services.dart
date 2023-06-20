import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

//screens
import '../../Screens/booktestdrive.dart';
import '../../Screens/buy.dart';
import '../../Screens/compare.dart';
import '../../Screens/sell.dart';
//widgets
import './servicegrid.dart';
//utilities
import '../../Utilities/themes.dart';

class Services extends StatelessWidget {
  final double width;
  const Services({required this.width, super.key});

  @override
  Widget build(BuildContext context) {
    return Card(
      color: Themes.themeColor2,
      shape: const RoundedRectangleBorder(
        borderRadius: BorderRadius.all(
          Radius.circular(10),
        ),
      ),
      child: SizedBox(
        width: width * 0.95,
        child: Column(
          children: [
            const SizedBox(
              height: 20,
            ),
            const Text(
              "Our Services",
              style: TextStyle(
                fontSize: 20,
                color: Colors.black,
                fontWeight: FontWeight.w900,
              ),
            ),
            SizedBox(
              height: 150,
              child: GridView(
                padding: const EdgeInsets.all(10),
                scrollDirection: Axis.horizontal,
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                  mainAxisSpacing: 10,
                  crossAxisCount: 1,
                ),
                children: [
                  GestureDetector(
                    onTap: () => Navigator.of(context).pushNamed(
                        BuyScreen.buyScreenRoute,
                        arguments: "Parth"),
                    child: const ServiceGrid(
                      icon: CupertinoIcons.car_detailed,
                      title: "Buy Car",
                    ),
                  ),
                  GestureDetector(
                    onTap: () => SellScreen.sellScreenRoute,
                    child: const ServiceGrid(
                      icon: Icons.car_rental,
                      title: "Sell Car",
                    ),
                  ),
                  GestureDetector(
                    onTap: () => BookTestDriveScreen.bookTestDriveScreenRoute,
                    child: const ServiceGrid(
                      icon: CupertinoIcons.speedometer,
                      title: "Book a test drive",
                    ),
                  ),
                  GestureDetector(
                    onTap: () => CompareScreen.compareScreenRoute,
                    child: const ServiceGrid(
                      icon: CupertinoIcons.list_bullet,
                      title: "Compare prices",
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(
              height: 20,
            ),
          ],
        ),
      ),
    );
  }
}
