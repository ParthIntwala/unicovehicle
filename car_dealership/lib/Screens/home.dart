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
                    Container(
                      color: Colors.red,
                    ),
                    Container(
                      color: Colors.blue,
                    ),
                    Container(
                      color: Colors.green,
                    ),
                    Container(
                      color: Colors.yellow,
                    ),
                    Container(
                      color: Colors.orange,
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
                      GridView.builder(
                        gridDelegate:
                            const SliverGridDelegateWithFixedCrossAxisCount(
                                crossAxisCount: 2),
                        itemBuilder: (ctx, index) => null,
                      )
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
