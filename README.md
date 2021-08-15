# PlateLicense

#**Compile**

1. Nevigate into **PlateLicense** folder
2. Open **PlateLicense.sln** in Visual Studio
3. After the project open, try to trigger Clean&Build,the project should bring all nuget packages(specified on **packages.config**) automaticlly and compile.
4. If you get compile error of missing dependencies or lib(.dll) do the next things:
  a. Make sure you connect the internt 
  b. Open %appdata% folder > go to Nuget > Edit nuget.config file with:
  <myxml>
    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <packageSources>
        <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
      </packageSources>
    </configuration>
   </myxml>
    
   c.Back to the project and validate all nuget packges are installed by do thid steps:
    ![image](https://user-images.githubusercontent.com/88496990/128636342-3a1500b0-9c59-4630-a514-16d65eceae40.png)
    ![image](https://user-images.githubusercontent.com/88496990/128636393-d285bea5-631a-4bbb-8dd4-4bb0c24d0ed4.png)
   d.Now try to compile it should work.
   
 #**Application**
 
 You can use the application by run plateLicense.exe [PathToSomeImageOfPlate].
 The app will parse the text, then write to DB the action,and write the actions to the log files.
 
 **#LogFile**
 
 The logs file folder is: **C:\Temp\PlatesLogs**
 
 **#Tests**
 
 All the test under the class PlateLicenseTests.cs.
 
 **Run Tests:**
 
 ![image](https://user-images.githubusercontent.com/88496990/128636522-48ec9f21-b6e6-4dbe-af42-6140ae1b1d24.png)
 
![image](https://user-images.githubusercontent.com/88496990/128636546-8cb58ac4-1dde-426a-8923-642eb9ccc2f4.png)

    

    
