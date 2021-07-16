import 'dart:io';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import './Screens/home.dart';
import './Providers/Accessories.dart';
import './Providers/AccessoriesType.dart';
import './Providers/AccessoryBrand.dart';
import './Providers/BoughtAccessories.dart';
import './Providers/Company.dart';
import './Providers/Country.dart';
import './Providers/CylinderArrangement.dart';
import './Providers/CompanyInsurance.dart';
import './Providers/CompanyCountry.dart';
import './Providers/CompanybyCountry.dart';
import './Providers/Customer.dart';
import './Providers/District.dart';
import './Providers/DistrictState.dart';
import './Providers/FuelType.dart';
import './Providers/InsuranceCompany.dart';
import './Providers/InsuranceType.dart';
import './Providers/Order.dart';
import './Providers/OrderBy.dart';
import './Providers/PostBuyingDetail.dart';
import './Providers/Showroom.dart';
import './Providers/Showroomby.dart';
import './Providers/ShowroomReview.dart';
import './Providers/ShowroomReviewby.dart';
import './Providers/State.dart';
import './Providers/Stateby.dart';
import './Providers/Status.dart';
import './Providers/TestDrive.dart';
import './Providers/TestDriveby.dart';
import './Providers/TransmissionType.dart';
import './Providers/User.dart';

void main() {
  HttpOverrides.global = new MyHttpOverrides();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(
          create: (ctx) => AccessoriesProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => AccessoriesTypeProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => AccessoryBrandProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => BoughtAccessoriesProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CompanyProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CountryProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CylinderArrangementProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CompanyInsuranceProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CompanyCountryProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CompanybyCountryProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => CustomerProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => DistrictProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => DistrictStateProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => FuelTypeProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => InsuranceCompanyProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => InsuranceTypeProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => OrderProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => OrderByProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => PostBuyingDetailProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => ShowroomProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => ShowroombyProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => ShowroomReviewProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => ShowroomReviewbyProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => StateProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => StatebyProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => StatusProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => TestDriveProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => TestDrivebyProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => TransmissionTypeProvider(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => UserProvider(),
        ),
      ],
      child: MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
            visualDensity: VisualDensity.adaptivePlatformDensity,
          ),
          home: HomeScreen() //MyHomePage(title: 'Flutter Demo Home Page'),
          ),
    );
  }
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}
