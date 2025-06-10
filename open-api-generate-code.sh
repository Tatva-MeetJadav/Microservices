#!/bin/bash

npx @openapitools/openapi-generator-cli generate -g aspnetcore \
  --additional-properties aspnetCoreVersion=7.0 \
  --additional-properties classModifier=abstract \
  --additional-properties operationModifier=abstract \
  --additional-properties packageName=Microservices \
  --additional-properties packageTitle=Microservices \
  --additional-properties enumValueSuffix= \
  --additional-properties operationResultTask=true \
  --additional-properties useSeparateModelProject=true \
  -i api.yml \
  -o .