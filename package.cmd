REM nuget update -self

if not exist download mkdir download
if not exist download\package mkdir download\package
if not exist download\package\dnsimple mkdir download\package\dnsimple

if not exist download\package\dnsimple\lib mkdir download\package\dnsimple\lib
if not exist download\package\dnsimple\lib\net45 mkdir download\package\dnsimple\lib\net45

copy src\DNSimple.Api\bin\Release\DNSimple.Api.dll download\package\DNSimple\lib\net45\
copy LICENSE.txt download

nuget pack DNSimple.nuspec -BasePath download\package\dnsimple -o download