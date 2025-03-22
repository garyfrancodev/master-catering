#!/bin/bash

docker compose --env-file patient-management/.env.compose up -d --build
