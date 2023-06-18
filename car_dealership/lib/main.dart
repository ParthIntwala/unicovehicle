import 'package:flutter/material.dart';

//screens
import './Screens/login.dart';
import './Screens/home.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const LoginScreen(),
      routes: {
        LoginScreen.loginScreenRoute: (ctx) => const LoginScreen(),
        HomeScreen.homeScreenRoute: (ctx) => const HomeScreen(),
      },
    );
  }
}
