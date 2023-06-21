import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

//models
import '../Models/dropdownvalues.dart';
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
  String selectedCompany = "1";
  double width = 0;
  @override
  Widget build(BuildContext context) {
    name = ModalRoute.of(context)!.settings.arguments as String;
    width = MediaQuery.of(context).size.width;
    List<DropDownCompany> companies = company;

    return Scaffold(
      appBar: CupertinoNavigationBar(
        backgroundColor: Themes.themeColor1,
        middle: Text(
          "Buy a Car!",
          style: Themes.navigationBarTheme,
        ),
      ),
      body: SafeArea(
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
              DropdownButton(
                padding: const EdgeInsets.all(10),
                menuMaxHeight: 300,
                itemHeight: 70,
                isExpanded: true,
                value: selectedCompany,
                items: companies
                    .map(
                      (item) => DropdownMenuItem(
                        alignment: Alignment.center,
                        value: item.id,
                        child: SizedBox(
                          width: width,
                          child: ListTile(
                            leading: Image.asset(
                              item.image,
                              width: 40,
                            ),
                            title: SizedBox(
                              width: width - 50,
                              child: Text(item.name),
                            ),
                          ),
                        ),
                      ),
                    )
                    .toList(),
                onChanged: (selectedValue) {
                  setState(() {
                    selectedCompany = companies
                        .firstWhere((element) => element.id == selectedValue)
                        .id;
                  });
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
