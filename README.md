# PlateLicense

#**Compile**

1. Nevigate into **PlateLicense** folder
2. Open **PlateLicense.sln** in Visual Studio
3. After the project open, try to trigger Clean&Build,the project should bring all nuget packages(specified on **packages.config**) automaticlly and compile.
4. If you get compile error of missing dependencies or lib(.dll) do the next things:
  a. Make sure you connect the internt 
  b. Open %appdata% folder > go to Nuget > Edit nuget.config file with:
  
  ~~~ xml
    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <packageSources>
        <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
      </packageSources>
    </configuration>
~~~
    
   c.Back to the project and validate all nuget packges are installed by do thid steps:
    ![image](https://user-images.githubusercontent.com/88496990/128636342-3a1500b0-9c59-4630-a514-16d65eceae40.png)
    ![image](https://user-images.githubusercontent.com/88496990/128636393-d285bea5-631a-4bbb-8dd4-4bb0c24d0ed4.png)
   d.Now try to compile it should work.
   
 #**Application**
 
PlateLicense.exe are open a windows path dialog, while you choose some picture from dialog the program will recognize the text from the pic, and check if the generated text(of plate number in our case) allowed to enter the parking. and also write each desicion to DB and the log file.
For exit just close the dialog box without choose nothing.
 
 ![image](https://user-images.githubusercontent.com/88496990/129480049-1dbc65d5-f8e9-426d-b375-5e088c289ede.png)

 
 **#LogFile**
 
 The logs file folder is: **C:\Temp\PlatesLogs**
 
 **#Tests**
 
 All the test under the class PlateLicenseTests.cs.
 
 **Run Tests:**
 
 ![image](https://user-images.githubusercontent.com/88496990/128636522-48ec9f21-b6e6-4dbe-af42-6140ae1b1d24.png)
 
![image](https://user-images.githubusercontent.com/88496990/128636546-8cb58ac4-1dde-426a-8923-642eb9ccc2f4.png)

    

    
