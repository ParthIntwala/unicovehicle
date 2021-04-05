import 'dart:io';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import './Screens/home.dart';
import './Providers/FuelType.dart';
import './Providers/Accessories.dart';

void main() {
  runApp(MyApp());
  HttpOverrides.global = new MyHttpOverrides();
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
