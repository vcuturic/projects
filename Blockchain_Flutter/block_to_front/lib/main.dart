//import 'dart:io';

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
//import 'package:path_provider/path_provider.dart';
import 'package:web3dart/web3dart.dart';
//import 'package:web_socket_channel/web_socket_channel.dart';
import 'package:http/http.dart';
import 'package:web_socket_channel/io.dart';
//import 'package:web_socket_channel/io.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  final String rpcUrl = "http://localhost:8545";
  final String wsUrl = "ws://localhost:8545/";
  
  Client httpClient;
  Web3Client ethClient;
  bool data;

  final myAddress = "0xd7ac71a071d249e7954418a01abde6fa7916376b";

  var myData;

  @override
  void initState(){
    super.initState();
    httpClient = Client();
    ethClient = Web3Client(rpcUrl, httpClient, socketConnector: () {
      return IOWebSocketChannel.connect(wsUrl).cast<String>();
    });

    getTaskCount(myAddress);

  }
  Future<DeployedContract> loadContract() async {
    String abi = await rootBundle.loadString("assets/abi.json");
    
    //var jsonAbi = jsonDecode(abi);
    //String abiCode = jsonEncode(jsonAbi["abi"])
    //print("\n"+abiCode+"\n");
    String contractAddress = "0x283562367910f8aB74D355c9f9328d58f1d77d6b";

    final contract = DeployedContract(
      ContractAbi.fromJson(abi, "TodoList"), EthereumAddress.fromHex(contractAddress));

    return contract;
  }

  //List<dynamic> args su argumenti funkcije
  Future<List<dynamic>> query(String functionName, List<dynamic> args) async{
      final contract = await loadContract();

      final ethFunction = contract.function(functionName);

      final result = await ethClient.call(contract: contract, function: ethFunction, params: args);

      return result;
  }

  Future<void> getTaskCount(String targetAddress) async{
    //EthereumAddress address = EthereumAddress.fromHex(targetAddress);

    List<dynamic> result = await query("getTaskCount", []);

    myData = result[0];
    data=true;
    setState(() {});
  }

  //int _counter = 0;

  void _incrementCounter() async {
    //setState(() {
      //_counter++;
    //});
    ;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        // Here we take the value from the MyHomePage object that was created by
        // the App.build method, and use it to set our appbar title.
        title: Text(widget.title),
      ),
      body: Center(
        // Center is a layout widget. It takes a single child and positions it
        // in the middle of the parent.
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Text(
              'You have pushed the button this many times:',
            ),
            Text(
              '$myData',
              style: Theme.of(context).textTheme.headline4,
            ),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _incrementCounter,
        tooltip: 'Increment',
        child: Icon(Icons.add),
      ), // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}
