@echo off
set CMD=%1

REM Load environment variables from .env file
for /f "tokens=1,2 delims==" %%A in (.env) do (
    set %%A=%%B
)

if "%CMD%"=="rm-volume" (
    echo Deleting db/volume...
    rmdir /s /q .\db\volume\
) else if "%CMD%"=="db-up" (
    echo Starting Docker Compose...
    docker compose -f .\docker-compose-db.yaml up -d
) else if "%CMD%"=="db-down" (
    echo Stopping and removing Docker Compose...
    docker compose -f .\docker-compose-db.yaml down
) else if "%CMD%"=="db-stop" (
    echo Stopping Docker Compose...
    docker compose -f .\docker-compose-db.yaml stop
) else if "%CMD%"=="db-start" (
    echo Starting Docker Compose...
    docker compose -f .\docker-compose-db.yaml start
) else if "%CMD%"=="db-seed" (
    echo Seeding the database with data...
    docker exec -i %DOCKER_DB_CONTAINER% mysql -h127.0.0.1 -uroot -p%DB_ROOT_PASSWORD% %DB_NAME% < .\db\insert-data.sql
) else if "%CMD%"=="db-reset" (
    echo Resetting the database...
    docker-cmd.bat db-down
    docker-cmd.bat rm-volume
    docker-cmd.bat db-up
    echo Database reset complete.
) else if "%CMD%"=="db-logs" (
    echo Displaying database logs...
    docker logs --tail 100 -f %DOCKER_DB_CONTAINER%
) else (
    echo Available commands:
    echo   rm-volume - Deletes the db/volume directory
    echo   db-up     - Runs docker-compose up
    echo   db-down   - Runs docker-compose down
    echo   db-stop   - Runs docker-compose stop
    echo   db-start  - Runs docker-compose start
    echo   db-seed   - Seeds the database with data from insert-data.sql
    echo   db-reset  - Resets the database by stopping, removing, and recreating it
    echo   db-logs   - Displays the last 100 lines of the database logs
)