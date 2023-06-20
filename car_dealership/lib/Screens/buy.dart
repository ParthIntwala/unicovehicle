import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

//models
import '../Models/dropdowncompany.dart';
//utilities
import '../Utilities/themes.dart';

class BuyScreen extends StatefulWidget {
  static const String buyScreenRoute = "/buy";
  const BuyScreen({super.key});

  @override
  State<BuyScreen> createState() => _BuyScreenState();
}

class _BuyScreenState extends State<BuyScreen> {
  String name = "";
  String selectedCompany = "Select the Company";
  @override
  Widget build(BuildContext context) {
    name = ModalRoute.of(context)!.settings.arguments as String;
    return CupertinoPageScaffold(
      navigationBar: CupertinoNavigationBar(
        backgroundColor: Themes.themeColor1,
        middle: Text(
          "Buy a Car!",
          style: Themes.navigationBarTheme,
        ),
      ),
      child: SafeArea(
        child: Container(
          padding: const EdgeInsets.all(10),
          child: Column(
            children: [
              Card(
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10),
                  side: BorderSide(
                    color: Themes.themeColor1,
                    width: 1.5,
                  ),
                ),
                elevation: 10,
                color: Themes.themeColor2,
                child: Padding(
                  padding: const EdgeInsets.all(10.0),
                  child: Text(
                    "Woohoo 🎉! Congratulations $name! Finally, you decided to buy a new Car and we are immensely happy to assist you for it.",
                    style: const TextStyle(
                      color: Colors.black,
                      decoration: TextDecoration.none,
                      fontSize: 13,
                      fontWeight: FontWeight.w500,
                    ),
                    textAlign: TextAlign.center,
                  ),
                ),
              ),
              SizedBox(
                height: 150,
                child: Material(
                  child: DropdownButton(
                    menuMaxHeight: 300,
                    itemHeight: 70,
                    value: "BMW",
                    items: company
                        .map(
                          (item) => DropdownMenuItem(
                            value: item.id,
                            child: ListTile(
                              leading: item.image,
                              title: Text(item.name),
                            ),
                          ),
                        )
                        .toList(),
                    onChanged: (selectedValue) {},
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
