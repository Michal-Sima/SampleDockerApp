Pre spustenie webovej sample aplikacie na manazovanie uzivatelov je potrebne v systeme Windows otvorit Powershell terminal v nom sa donavigovat do rozbaleneho zip archivu, potom staci spustit prikaz ".\start-app.ps1" a na pozastavenie docker containerov prikaz "end-app.ps1". Na pripojenie k webovej aplikacii je potrebne v browseri otvorit URL -> http://localhost:5555

Zoznam komponentov: 1. komponent: MSSQL Server, ktory obsahuje databazu pre nasu aplikaciu, 2. komponent: jednoducha webova aplikacia na manazovanie Userov napisana v .NET Core

Zip archiv obsahuje 2 docker-compose.yml subory. Ten ktory sa spusta pomocou ".\start-app.ps1" vyuziva docker image mojej webovej aplikacie ktory je nahrany v mojom repozitari na Docker Hub kde sa nahrava pomocou Github Action z repozitara https://github.com/Michal-Sima/SampleDockerApp. Kedze na niektorych systemoch je obcas problem zbuildovat .NET Core aplikaciu v dockeri vid tento bug -> https://github.com/dotnet/dotnet-docker/issues/4503.

Subor docker-compose.yml ktory sa nachadza v roote repozitara builduje docker image pomocou Dockerfile suboru opat v roote repozitara.

Na zmazanie tych containerov staci vojst do zlozky docker-compose-only-images a zavolat "docker compose down".
