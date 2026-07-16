FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EmployeeApi/EmployeeApi.csproj", "EmployeeApi/"]
RUN dotnet restore "EmployeeApi/EmployeeApi.csproj"
COPY . .
WORKDIR "/src/EmployeeApi"
RUN dotnet build "EmployeeApi.csproj" -c Release -o /app/build
RUN dotnet publish "EmployeeApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "EmployeeApi.dll"]