class DropDownCompany {
  final String image;
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
    id: "1",
    image: "assets/Aston Martin.png",
  ),
  DropDownCompany(
    name: "BMW",
    id: "2",
    image: "assets/BMW.png",
  ),
  DropDownCompany(
    name: "Ferrari",
    id: "3",
    image: "assets/Ferrari.png",
  ),
  DropDownCompany(
    name: "Lexus",
    id: "4",
    image: "assets/Lexus.png",
  ),
  DropDownCompany(
    name: "Lincoln",
    id: "5",
    image: "assets/Lincoln.png",
  ),
  DropDownCompany(
    name: "Maserati",
    id: "6",
    image: "assets/Maserati.png",
  ),
  DropDownCompany(
    name: "Mercedes Benz",
    id: "7",
    image: "assets/Mercedes Benz.png",
  ),
  DropDownCompany(
    name: "Porsche",
    id: "8",
    image: "assets/Porsche.png",
  ),
  DropDownCompany(
    name: "Tesla",
    id: "9",
    image: "assets/Tesla.png",
  ),
];
