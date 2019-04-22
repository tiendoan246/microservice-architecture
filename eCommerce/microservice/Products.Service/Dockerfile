FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Products.Service/Products.Service.csproj", "Products.Service/"]
RUN dotnet restore "Products.Service/Products.Service.csproj"
COPY . .
WORKDIR "/src/Products.Service"
RUN dotnet build "Products.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Products.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Products.Service.dll"]