#!/bin/bash

docker build -t web:optimized .
docker run -it --rm -p 8000:80 web:optimized
