#!/bin/bash
if [ $# -ne 1 ]; 
then
  echo "Which tag should be built?"
  exit 1;
fi
TAG=$1
git checkout $TAG
xbuild /p:Configuration=Release InteractiveOfficeClient.sln
7za a InteractiveOfficeClient-$TAG-Linux.7z bin/Release/
git checkout master
git push --tags && \
chromium https://github.com/InteractiveOfficeProject/client/releases/new?tag=$TAG & 
