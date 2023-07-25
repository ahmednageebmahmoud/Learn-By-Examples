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