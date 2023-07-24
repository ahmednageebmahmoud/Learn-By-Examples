
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