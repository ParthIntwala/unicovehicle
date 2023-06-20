import 'package:flutter/material.dart';

class DropDownCompany {
  final Image image;
  final String name;
  final String id;

  DropDownCompany({
    required this.id,
    required this.image,
    required this.name,
  });
}

List<DropDownCompany> company = [
  DropDownCompany(
    name: "Aston Martin",
    id: "Aston Martin",
    image: Image.asset("assets/Aston Martin.png"),
  ),
  DropDownCompany(
    name: "BMW",
    id: "BMW",
    image: Image.asset("assets/BMW.png"),
  ),
  DropDownCompany(
    name: "Ferrari",
    id: "Ferrari",
    image: Image.asset("assets/Ferrari.png"),
  ),
  DropDownCompany(
    name: "Lexus",
    id: "Lexus",
    image: Image.asset("assets/Lexus.png"),
  ),
  DropDownCompany(
    name: "Lincoln",
    id: "Lincoln",
    image: Image.asset("assets/Lincoln.png"),
  ),
  DropDownCompany(
    name: "Maserati",
    id: "Maserati",
    image: Image.asset("assets/Maserati.png"),
  ),
  DropDownCompany(
    name: "Mercedes Benz",
    id: "Mercedes Benz",
    image: Image.asset("assets/Mercedes Benz.png"),
  ),
  DropDownCompany(
    name: "Porsche",
    id: "Porsche",
    image: Image.asset("assets/Porsche.png"),
  ),
  DropDownCompany(
    name: "Tesla",
    id: "Tesla",
    image: Image.asset("assets/Tesla.png"),
  ),
];
