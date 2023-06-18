import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_carousel_widget/flutter_carousel_widget.dart';

//screens
import './login.dart';
//utilities
import '../Utilities/themes.dart';

class HomeScreen extends StatefulWidget {
  static String homeScreenRoute = "/home";

  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    String name = ModalRoute.of(context)!.settings.arguments as String;
    double width = MediaQuery.of(context).size.width;
    return CupertinoPageScaffold(
      backgroundColor: Themes.themeColor2,
      navigationBar: CupertinoNavigationBar(
        leading: IconButton(
          icon: Icon(
            Icons.logout,
            size: 20,
            color: Themes.themeColor2,
          ),
          onPressed: () {
            Navigator.of(context).pushNamedAndRemoveUntil(
                LoginScreen.loginScreenRoute, (route) => false);
          },
        ),
        backgroundColor: Themes.themeColor1,
        middle: Text(
          "Welcome, $name",
          style: TextStyle(
            fontSize: 20,
            color: Themes.themeColor2,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
      child: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Container(
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
                    aspectRatio: 1.78,
                  ),
                ),
              ),
              const SizedBox(
                height: 30,
              ),
              Card(
                shape: const RoundedRectangleBorder(
                  borderRadius: BorderRadius.all(
                    Radius.elliptical(
                      5,
                      7,
                    ),
                  ),
                ),
                child: SizedBox(
                  width: width * 0.95,
                  child: Column(
                    children: [
                      const Text(
                        "Our Services",
                        style: TextStyle(
                          fontSize: 20,
                          color: Colors.black,
                        ),
                      ),
                      SizedBox(
                        height: 300,
                        child: GridView.builder(
                          gridDelegate:
                              const SliverGridDelegateWithFixedCrossAxisCount(
                                  crossAxisCount: 2),
                          itemBuilder: (ctx, index) => null,
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
