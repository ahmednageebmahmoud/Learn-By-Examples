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


