# First stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./ElementarySchool.Web.csproj"
RUN dotnet build "ElementarySchool.Web.csproj" -c Release -o /app/build

# Copy everything else and build website
FROM build AS publish
RUN dotnet publish "ElementarySchool.Web.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElementarySchool.Web.dll"]

FROM jenkins/jenkins:latest
USER root
RUN apt-get update && apt-get install -y apt-transport-https \
	ca-certificates curl gnupg2 \
	software-properties-common
RUN apt-get install -y dotnet-sdk-5.0.0 && \
    	export PATH=$PATH:$HOME/dotnet && \
    	dotnet --version
RUN curl -fsSL https://download.docker.com/linux/debian/gpg | apt-key add -
RUN apt-key fingerprint 0EBFCD88
RUN add-apt-repository \
	"deb [arch=amd64] https://download.docker.com/linux/debian \
	$(lsb_release -cs) stable"
RUN apt-get update && apt-get install -y docker-ce-cli
USER jenkins
RUN jenkins-plugin-cli
