FROM microsoft/aspnetcore:latest
WORKDIR /app
COPY . .

#ENV ASPNETCORE_URLS http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "api.dll"]

