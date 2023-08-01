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
    then install [VS CODE Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) if you want to test your apis from any file with .http extensions.
```
    exmaple:
![End Points](https://github.com/ahmednageebmahmoud/Learn-By-Examples/blob/54fa38cdd79e199d6d6b8ba0622fb2db2667a592/Docker/NodeApp_DockerCompose/images/1-rest-http.png?raw=true)


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
    Open [docker-compose.yml](docker-compose.yml)

```


6- Docker compose commands  
```
    > docker build .
    > docker compose up 
    > docker compose up -d ## If you want keep docker running in background 
    > docker compose down

```

7- Create Bind Mounting Volume With Nodemone To Auto Restart App If Change Any Nodejs File At Run Time  
```
    1- In DockerFile Use > CMD ["npm","run","dev"] Instead Of CMD [ "npm","start" ]
    2- In docker-compose.yml In api searvice section create Mounting volume to bind all file with docker app path (WORKDIR)
        volumes:
        - .:/usr/source/myNodeApp
```