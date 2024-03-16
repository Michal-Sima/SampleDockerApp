FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore -v d
# Build and publish a release
RUN dotnet publish -c Release -o out

# ENV ASPNETCORE_HTTPS_PORTS=$PORT
EXPOSE 5000

ENTRYPOINT ["dotnet","/App/out/SampleDockerApp.dll"]