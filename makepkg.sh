#!/bin/bash
#ditto -c -k --keepParent bin/Debug/net9.0/osx-x64  Macron.zip # nope
#hdiutil create -srcFolder --keepParent bin/Debug/net9.0/osx-x64 -o Macron.zip #nope again

echo "building x64"
dotnet publish -r osx-x64 -p:PublishSingleFile=true # no sc
mkdir -p amd64
cp bin/Release/net9.0/osx-x64/publish/Macron* amd64/

echo "attempting cross compile arm64"
dotnet publish -r osx-arm64 -p:PublishSingleFile=true # no sc
mkdir -p arm64
cp bin/Release/net9.0/osx-x64/publish/Macron* arm64/
