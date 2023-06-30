FROM node:16.20-slim as build
WORKDIR /dist/src/app

RUN npm install -g npm@9.7.2
COPY package*.json ./
RUN npm ci 
COPY . .
RUN npm run build

FROM nginx:latest as final
COPY --from=build /dist/src/app/dist/angular-app /usr/share/nginx/html
COPY /nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80