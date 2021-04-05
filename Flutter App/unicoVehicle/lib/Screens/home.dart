import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:provider/provider.dart';

import '../Providers/Accessories.dart';
import '../Providers/FuelType.dart';

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
            middle: Text("Unocò Vehicle"),
          ),
          body: SafeArea(
            child: Center(
              child: ElevatedButton(
                child: Text("Fetch"),
                onPressed: () {
                  Provider.of<AccessoriesProvider>(context, listen: false)
                      .fetchAccessories();
                },
              ),
            ),
          ),
        ),
      ),
    );
  }
}
