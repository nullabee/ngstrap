#!/bin/bash

docker build -t web:optimized .
docker run -it --rm -p 7777:80 web:optimized
