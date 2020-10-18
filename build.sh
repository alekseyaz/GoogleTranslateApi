#!/bin/bash

set -e

dotnet --info
dotnet --list-sdks
dotnet restore

echo "🤖 Attempting to pack..."
for path in GoogleTranslateApi/*.csproj; do
    dotnet pack -c Release ${path} -o ..\artifacts
done
