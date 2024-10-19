set build_version=%1
@ECHO OFF

docker login docker.io -u leminhduc201299 -p duc.lm173043
docker build --quiet -t docker.io/leminhduc201299/test-fe:%build_version% .
docker push --quiet docker.io/leminhduc201299/test-fe:%build_version%