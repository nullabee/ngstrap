FROM microsoft/aspnetcore-build:latest

WORKDIR /app
COPY . . 

RUN dotnet restore
RUN dotnet publish -c release -o /dist/release

WORKDIR /
RUN ls -lha
