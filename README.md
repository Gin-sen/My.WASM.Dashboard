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

Pr�requis : .Net SDK 7

Cloner le d�pot de la solution.
Dans un terminal, � la racine du d�pot, entrer la commande :
`dotnet new --install .`
Cela rendra la template disponible dans Visual Studio (nouveau projet) et avec la commande :
`dotnet new my-wasm-dashboard -n VOTRE.NOUVEAU.MICROSERVICE`

2 cas de figure:
1. Cloner un nouveau d�pot vide puis dans ce d�pot, lancer :
`dotnet new my-wasm-dashboard -n VOTRE.NOUVEAU.MICROSERVICE -o .`
2. Cr�er la solution avec la commande suivante puis initialiser votre d�pot � partir du nouveau dossier de solution
`dotnet new my-wasm-dashboard -n VOTRE.NOUVEAU.MICROSERVICE`

Pour lister les templates install�es :
`dotnet new --list`

Pour d�sinstaller la template, dans un terminal, � la racine du d�pot, entrez la commande :
`dotnet new --uninstall .`