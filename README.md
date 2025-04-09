# TaskMaster

## MySQL
La base de donnée MySQL fonctionne sur un container docker.

### Utilitaire Windows
Sur windows, le fichier `docker-cmd.bat` est un utilitaire pour faciliter la mise en place (uniquement sur Windows).

- `./docker-cmd.bat rm-volume` ➡️ supprime le volume ou se trouve les données de la base de donnée
- `./docker-cmd.bat db-up` ➡️ démarre la base de donnée. Si jamais lancée, ou que les données ont été supprimées, la bdd est initialisée à nouveau, avec la structure des tables
- `./docker-cmd.bat db-start`  ➡️ redémarre le container
- `./docker-cmd.bat db-stop`  ➡️ stop le container
- `./docker-cmd.bat db-down`  ➡️ stop le container puis le supprime. Les données de la base reste dans le dossier `db/volume`

### Connection
La base se trouve sur le port 3306, et les logins de base se trouvent dans le `.env`.

## Le projet
Pour run/compile le projet, lancer la commande:
```sh
dotnet run --framework net9.0-windows10.0.19041.0
```
