import 'package:flutter/material.dart';

//utilities
import '../../Utilities/themes.dart';

class ServiceGrid extends StatelessWidget {
  final String title;
  final IconData icon;
  const ServiceGrid({required this.icon, required this.title, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        border: Border.all(
          style: BorderStyle.solid,
          width: 1,
          color: Themes.themeColor1,
        ),
        borderRadius: BorderRadius.circular(10),
      ),
      height: 150,
      child: GridTile(
        footer: Center(
          child: Text(
            title,
            style: const TextStyle(
              fontSize: 15,
              fontWeight: FontWeight.bold,
            ),
            textAlign: TextAlign.center,
          ),
        ),
        child: Icon(
          icon,
          size: 50,
        ),
      ),
    );
  }
}
