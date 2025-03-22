#!/bin/bash

docker compose -f patient-management/docker-compose.yml --env-file patient-management/.env.compose up -d --build
