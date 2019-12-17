# TFL Road Status API
- This is a code sample that forms part of a contract tender for TFL.

## Caveats
- It is an 80/20 implementation.
- It and this document are for illustrative purposes only.
- It and this document are draft versions and not fully proofed.

In case of any difficulties, please feel free to contact support on 01440 707720.

## Assumptions
- You have basic C# developer knowledge.  
- The client accesses the live TFL Web site so the PC must be on line.  
- The application is a coding demonstration not intended for multiple enquiries, much less real-world use.

## Getting Started
High-level steps:
- build the application
- get your TFL credentials
- configure the Road Status Client
- run the application.

These steps are explained below.

### Build the application
- Unzip the application source code to a folder.
- Open the .sln file in Visual Studio.
- Set project output configuration to Release.
-  and compile the solution.

### Get TFL Credentials:
To access the TFL Web API, you will need to configure the Road Status Client:
- developer key
- application id.

__N.B. Refer to the Developer coding challenge.docx in the __DOCUMENTS__ solution folder for how to get a developer key.__

### Set Up
- Add the developer key to the App.config file __your_developer_key__ (see the example below).
- Add the application id __your_app_id__ similarly.
- Save the file.

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <appSettings>
        <add key="your_developer_key" value="__INSERT_YOUR_YOUR_DEVELOPER_KEY_HERE__" />
        <add key="your_app_id" value="__INSERT_YOUR_APPLICATION_ID_HERE__" />
    </appSettings>
</configuration>
``` 

### Run the Road Status Client
- Open the solution.
- Make sure you have compiled the Tfl.Solution solution.
- Open Solution Explorer.
- Navigate to the RoadStatus project the Tfl.Solution folder.
- Open the Bin\ __Release__\ folder.
- Right-click on the netcoreapp3.1 folder.
- Select Open Folder in File Explorer the context menu.
- In file explorer address bar, type __cmd__ to open a console window on the folder.
- A Visual Studio runtime console window will appear.
- When the prompt appears, type RoadStatus.exe and enter a road name:

````
 RoadStatus.exe A2
````
- The status for that road corridor will be displayed immediately below the road name you entered.
  (see the above TFL instructions in the Developer coding challenge.docx).

__NBThe TFL Road Status Client is not for production use, so to enter further road names you will have to re-run the application.__

## Developer Notes
### Testing and Debugging the Road Status Client
Acceptance Test:
- The Road Status Client has been manually tested via the command line and integration tested automatically using the consultant's (Rightway IT Limited's) own proprietary BDD method.
- For acceptance test:  
-- manually enter the three command-line parameters  
   or...   
-- configure the app id and the developer key in the App.config and pass in the road name via the command line.

Automated Integration Test:
- The entry point is the Application.Run() method. 
- Pass the three command-line parameters to the Run method.  

Debugging:
- Add __road name__, __app id__ and __developer key__ command line parameters to the RoadStatus project | Properties | Application | Application arguments box.

Example command line parameters entered in the __Application arguments__ box:
```
A2  169944f3 87472398b7d46b584812c602a452d97d
```

### Troubleshooting
Scenario:
```
System.Text.Json.JsonReaderException: ''<' is an invalid start of a value. LineNumber: 0 | BytePositionInLine: 0.'
```
Explanation:  
This may happen when an XML error is returned instead of a JSON payload.  
Fix:  
Make sure the command line parameters/configurations are valid and in the correct order.

Scenario:
Host Policy dll not found.

Explanation: Possibly running the debug version which will not run on its own in .NET Core.

Fix:
- Set output configuration to Release.
- Compile and run the app from the release folder.

Scenario:
__Feel free to add further troubleshooting scenarios here.__

Once again, in case of any difficulties, please feel free to contact support on 01440 707720.
