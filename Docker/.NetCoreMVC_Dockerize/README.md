


Steps
-----------------------------------------
1- Create New MVC APP
```
    > dotnet new mvc -o solutionName -name projectName
```

3- Move Terminal To Project
```
    > cd projectName
```

4- Build APP
```
    > dotnet build
```

5- Create Docker Ignore File
```
    > touch .dockerignore

    And We Don't Need the bin folder and the obj folder In Our image, So we will ignore them by the fellowing pattern
    [o|O]bj 
    [b|B]in
```

6- Create Docker File
```
    > touch Dockerfile
    
    # First Stage Pull Donte SDK And Make Alise Name To Use It Name In Next Stpes
    FROM mcr.microsoft.com/dotnet/sdk:6.0 AS buildStage

    # Tell Next Commands What Directory Will Work In 
    WORKDIR /source

    # Copy All MVC Project Files In [WORKDIR]  
    COPY . .

    # Restore All Dependencies Packages
    RUN dotnet restore

    # Publish MVC Project In app Folder
    RUN dotnet publish -c release -o /app


    # Second Stage Pull Dontent ASPNet 
    FROM mcr.microsoft.com/dotnet/aspnet:6.0

    # Tell Next Commands What Directory Will Work In, Remember We Already Created an App Folder In The Previous Step When Publish App Step
    WORKDIR /app

    # Copy All Files From buildStage To app folder
    COPY --from=buildStage /app .

    # What Command Will Work When We Do > docker run -d -p 8080:80 --name containerName projectName  
    ENTRYPOINT [ "dotnet","mvcapp.dll" ]
```

7- Create Image == Build Image
```
    > docker build . --tag imageName

    or add image name with tag if you want create more images with diffrent versions
    > docker build . --tag imageName:imageTag
```

8- Create Container == Run Image
```
    > docker run -d -p 8080:80 --name containerName imageName 

    -d: Detach, that's how you tell Docker to run containers in the background even if you close the current terminal session.
    -p: Port, here we map our port(8080) with docker container inside port(80)
```

Now Open Your App On http://localhost:8080