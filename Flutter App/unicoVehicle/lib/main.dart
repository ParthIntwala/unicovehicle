import 'dart:io';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import './Screens/home.dart';
import './Providers/FuelType.dart';
import './Providers/Accessories.dart';
import './Providers/AccessoriesType.dart';
import './Providers/AccessoryBrand.dart';
import './Providers/BoughtAccessories.dart';

void main() {
  HttpOverrides.global = new MyHttpOverrides();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(
          create: (ctx) => FuelTypeProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => AccessoriesProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => AccessoriesTypeProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => AccessoryBrandProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => BoughtAccessoriesProvider(),
        ),
      ],
      child: MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
            visualDensity: VisualDensity.adaptivePlatformDensity,
          ),
          home: HomeScreen() //MyHomePage(title: 'Flutter Demo Home Page'),
          ),
    );
  }
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}
