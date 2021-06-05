import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:provider/provider.dart';

import '../Models/Customer.dart';
import '../Models/Miscellaneous/District.dart';
import '../Models/Miscellaneous/User.dart';
import '../Providers/Customer.dart';

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
                  await Provider.of<CustomerProvider>(context, listen: false)
                      .deleteCustomer(3);

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
