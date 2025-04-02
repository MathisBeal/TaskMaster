@echo off
set CMD=%1

if "%CMD%"=="rm-volume" (
    echo Deleting db/volume...
    rmdir /s /q .\db\volume\
) else if "%CMD%"=="db-up" (
    echo Starting Docker Compose...
    docker compose -f .\docker-compose-db.yaml up -d
) else if "%CMD%"=="db-down" (
    echo Stopping Docker Compose...
    docker compose -f .\docker-compose-db.yaml down
) else (
    echo Available commands:
    echo   rm-volume - Deletes the db/volume directory
    echo   db-up     - Runs docker-compose up
    echo   db-down   - Runs docker-compose down
)