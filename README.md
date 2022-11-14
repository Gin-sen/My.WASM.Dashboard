# My.WASM.Dashboard
.Net 7 WASM Blazor with webpack bundling

# Webpack integration

NPM is needed to install node packages.

Webpack is used to bundle and minify you Javascript files from JsBundle folder.

NPM commands are run before build in JsBundle directory to produce `wwwroot/js/mybundle.js`

# Docker Support on Visual Studio

Blazor WASM Apps (on Docker and Docker-Compose projects) are not currently supported in Visual Studio . 
Some attempts were made but it was slow, buggy and not suitable for development. 

It runs fine without Visual Studio injecting things so use it from the command line :

```bash
docker build -f My.WASM.Dashboard/Dockerfile -t mywasmdashboard:1.0 .
docker run --rm -d -p 8080:80 -n my_wasm_dashboard mywasmdashboard:1.0
docker stop my_wasm_dashboard

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
docker-compose -f docker-compose.yml -f docker-compose.override.yml down
```

Docker dev setup for Blazor WebAssembly will be invistigated furthermore but it is planned for .Net 8 Release so 
it is recommended to work without docker for step-by-step debugging in Visual Studio.


# Installation de la template

Prérequis : .Net SDK 7

Cloner le dépot de la solution.
Dans un terminal, à la racine du dépot, entrer la commande :
`dotnet new --install .`
Cela rendra la template disponible dans Visual Studio (nouveau projet) et avec la commande :
`dotnet new my-wasm-dashboard -n VOTRE.NOUVEAU.MICROSERVICE`

2 cas de figure:
1. Cloner un nouveau dépot vide puis dans ce dépot, lancer :
`dotnet new my-wasm-dashboard -n VOTRE.NOUVEAU.MICROSERVICE -o .`
2. Créer la solution avec la commande suivante puis initialiser votre dépot à partir du nouveau dossier de solution
`dotnet new my-wasm-dashboard -n VOTRE.NOUVEAU.MICROSERVICE`

Pour lister les templates installées :
`dotnet new --list`

Pour désinstaller la template, dans un terminal, à la racine du dépot, entrez la commande :
`dotnet new --uninstall .`