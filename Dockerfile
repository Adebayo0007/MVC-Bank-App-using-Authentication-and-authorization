# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /Bank App

# Copy everything
# COPY . ./
# Restore as distinct layers
# RUN dotnet restore
# Build and publish a release
# RUN dotnet publish -c Release -o out

# Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /Bank App
# COPY --from=build-env /Bank App/out .
# ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]


#Alternatively

FROM nats:Windows
COPY . / Bank App
WORKDIR /Bank App
CMD mcr.microsoft.com/dotnet/sdk Bank App