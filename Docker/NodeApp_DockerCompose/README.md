Host Simple NodeJs App On NGINX And Using MongoDB And Use Docker Compose And Applu Bind Mounting To Restart Container If I Make Change In App 
=====

Steps
-----------------------------------------
1- Basic Commands
```
    > mkdir NodeApp_DockerCompose
    > cd ./NodeApp_DockerCompose
    > touch .gitignore
    > touch .dockerignore
    > touch Dockerfile
    > touch docker-compose.yml
    > npm i express mongodb dotenv nodemon body-parser
    > touch app.js
    > touch initDB.js
    > touch .env
```

2- Create Simple Express Server 
```
    All Code In app.js
```

3- Create rest.http to create post requests easyly by VSCODE
```
    > touch rest.http
    then install (VS CODE Rest Client)[https://marketplace.visualstudio.com/items?itemName=humao.rest-client] if you want to test your apis from any file with .http extensions.
    exmaple:
    ![EndPoints](https://raw.githubusercontent.com/ahmednageebmahmoud/Learn-By-Examples/main/docker/NodeApp_DockerCompose/images/rest-http.png)
````
 
4- Fill Dockerfile
```
    ## Pull Node Image With Alpine Tag
    FROM node:alpine

    ## Define App Folder Path
    WORKDIR /usr/source/myNodeApp

    ## Copy All Files Available in [WORKDIR]
    COPY . .

    ## Run npm continuous integration to install dependencies 
    RUN npm ci

    ## Start App
    CMD [ "npm","start" ]
````

5- Fill docker-compose.yml 
```


```


6- Docker compoes commands  
```
    > docker compoes up
    > docker compoes down

```