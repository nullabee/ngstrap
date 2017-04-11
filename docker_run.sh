#!/bin/bash

docker build publish/web -t web:optimized
docker run -it --rm -P 8000:80 web:optimized
