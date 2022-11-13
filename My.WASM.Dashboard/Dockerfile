#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -fsSL https://deb.nodesource.com/setup_19.x | bash - && \
			apt-get install -y nodejs

WORKDIR /src
COPY ["My.WASM.Dashboard/My.WASM.Dashboard.csproj", "My.WASM.Dashboard/"]
RUN dotnet restore "My.WASM.Dashboard/My.WASM.Dashboard.csproj"
COPY . .
WORKDIR "/src/My.WASM.Dashboard"
RUN dotnet build "My.WASM.Dashboard.csproj" -c Release -o /app/build -r linux-musl-x64 --self-contained

FROM build AS publish
RUN dotnet publish "My.WASM.Dashboard.csproj" -c Release -o /app/publish /p:UseAppHost=false -r linux-musl-x64 --self-contained


FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
COPY My.WASM.Dashboard/nginx.conf /etc/nginx/nginx.conf
# si on déploie sur Kube, alors appsettings.json 
# doit etre supprimé dans le container
ARG KUBE_DEPLOY
RUN if [ ! -z "$KUBE_DEPLOY" ] ; then rm appsettings*.json; fi