Host Simple Index File On NGINX With Bind Mounting 
=====

Steps
-----------------------------------------
1- Pull NGINX image
```
    > docker pull nginx
```


2- Create container and bind loacl folder to NGINX host folder
```
    >  docker run -d --name testBindMounting -p 4300:80 -v ${pwd}:/usr/share/nginx/html nginx 
    
    -d: Detach, that's how you tell Docker to run containers in the background even if you close the current terminal session.
    -p: Port, here we map our port(4300) with nginx port(80)
    ${pwd}: Current directory
```
