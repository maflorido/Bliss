#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER usrapi;
    CREATE DATABASE questionapi;
    GRANT ALL PRIVILEGES ON DATABASE questionapi TO usrapi;
EOSQL