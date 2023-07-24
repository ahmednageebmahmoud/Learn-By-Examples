


Steps
-----------------------------------------
1- Create New Angualr APP
```
    > ng new helpdesk
```

2- Move Terminal To Project
```
    > cd helpdesk
```

3- Create Docker Ignore File
```
    > touch .dockerignore
    I Recommend you copy all patterns from .gitignore to this file     
```

7- Create Docker File
```
    > touch Dockerfile
    
    # Stage One: pull the node image because we will run an Android app on it, then add the name because we will use this name in the next command.
    FROM node as nodeBuild

    # Create App Folder And -p will check to create only if not created before
    RUN mkdir -p /app

    # Go To /app folder like cd /app
    WORKDIR /app

    # Copy All Angualr Files In /app
    COPY . /app/

    # Npm Install To Install NPM Packages
    RUN npm install

    # Build Angualr APP
    RUN npm run build --prod

    # Stage Tow: pull nginx to create server
    FROM nginx

    # Copy Build Files From "/app/dist/helpdesk/" From "nodeBuild" Stage In  "/usr/share/nginx/html" 
    COPY --from=nodeBuild /app/dist/helpdesk/ /usr/share/nginx/html

```

7- Create Image == Build Image
```
    > docker build . --tag helpdeskapp
```

7- Create Container == Run Image
```
    > docker run -d -p 4200:80 --name helpdesk helpdeskapp 

    -d: Detach, that's how you tell Docker to run containers in the background even if you close the current terminal session.
    -p: Port, here we map our port(4200) with docker container inside port(80)
```

Now Open Your App On http://localhost:4200