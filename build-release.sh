#!/bin/bash
if [ $# -ne 1 ]; 
then
  echo "Which tag should be built?"
  exit 1;
fi
TAG=$1
git checkout $TAG
xbuild /p:Configuration=Release InteractiveOfficeClient.sln
7za a InteractiveOfficeClient-$TAG.7z bin/Release/
