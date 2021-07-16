import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:provider/provider.dart';
import 'package:unicoVehicle/Models/UserType.dart';

import '../Providers/User.dart';
import '../Models/User.dart';

class HomeScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return CupertinoTabScaffold(
      tabBar: CupertinoTabBar(
        items: [
          BottomNavigationBarItem(icon: Icon(CupertinoIcons.home)),
          BottomNavigationBarItem(icon: Icon(CupertinoIcons.home)),
        ],
      ),
      tabBuilder: (ctx, index) => CupertinoTabView(
        builder: (ctx) => Scaffold(
          appBar: CupertinoNavigationBar(
            middle: Text("Unicò Vehicle"),
          ),
          body: SafeArea(
            child: Center(
              child: ElevatedButton(
                child: Text("Fetch"),
                onPressed: () async {
                  print("Button Pressed");
                  await Provider.of<UserProvider>(context, listen: false)
                      .deleteUser(3);
                  print("Function Over");
                },
              ),
            ),
          ),
        ),
      ),
    );
  }
}
