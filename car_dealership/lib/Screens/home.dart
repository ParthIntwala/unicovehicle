import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

//screens
import './login.dart';
//widgets
import '../Widgets/Home Screen/services.dart';
import '../Widgets/Home Screen/carousal.dart';
import '../Widgets/Home Screen/brandgrid.dart';
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
      navigationBar: CupertinoNavigationBar(
        leading: CupertinoButton(
          child: Icon(
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
          style: Themes.navigationBarTheme,
        ),
      ),
      child: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Carousal(width: width),
              const SizedBox(
                height: 30,
              ),
              Services(width: width),
              const SizedBox(
                height: 30,
              ),
              Text(
                "Our Partners",
                style: TextStyle(
                  fontSize: 20,
                  color: Themes.themeColor1,
                  decoration: TextDecoration.none,
                ),
                textAlign: TextAlign.center,
              ),
              const SizedBox(
                height: 20,
              ),
              BrandGrid(
                width: width,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
