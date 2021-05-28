import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:provider/provider.dart';

import '../Providers/District.dart';
import '../Models/District.dart';
import '../Models/Miscellaneous/State.dart' as local;

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
                  await Provider.of<DistrictProvider>(context, listen: false)
                      .deleteDistrict(3);

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
