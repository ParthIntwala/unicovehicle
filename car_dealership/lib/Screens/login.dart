import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

//utilities
import '../Utilities/themes.dart';

class LoginScreen extends StatefulWidget
{
  const LoginScreen({Key? key}) : super(key: key);
  
  @override
  State<StatefulWidget> createState() => _LoginScreenState();
}



class _LoginScreenState extends State<LoginScreen>
{
  final TextEditingController _userName = TextEditingController();
  final TextEditingController _password = TextEditingController();
  final FocusNode _userNameNode = FocusNode();
    final FocusNode _passwordNode = FocusNode();

  @override
  Widget build(BuildContext context)
  {
    return CupertinoPageScaffold(
      child: SafeArea(child: Center(
        child: Card(
          color: Themes.themeColor1,
          elevation: 6,
          margin: const EdgeInsets.all(10),
          child: Padding(padding: const EdgeInsets.all(10),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Image.asset(
                "assets/Logo.png",width: 250,
              ),
              const SizedBox(height: 30,),
              CupertinoTextField(
                controller: _userName, 
                focusNode: _userNameNode, 
                style: const TextStyle(
                  color: Colors.black,
                ), 
                cursorColor: Colors.black,
                padding: const EdgeInsets.all(10),
                placeholder: "Username or EmailID",
              ),
              const SizedBox(height: 10,),
              CupertinoTextField(
                controller: _password, 
                focusNode: _passwordNode, 
                style: const TextStyle(
                  color: Colors.black,
                ), 
                cursorColor: Colors.black,
                padding: const EdgeInsets.all(10),
                placeholder: "Password",
                obscureText: true,
              ),
              const SizedBox(height: 20,),
              Row(
                children: [
                  Expanded(child: CupertinoButton(onPressed: () => {}, child: const Text("Reset"),),),
                   Expanded(child: CupertinoButton(onPressed: () => {}, child: const Text("Submit"),),),
                ],
              ),
            ],
          ),
        ),),
      ),
    ),);
  }
}