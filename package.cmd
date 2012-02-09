nuget.exe update -self

if not exist download mkdir download
if not exist download\package mkdir download\package
if not exist download\package\dnsimple mkdir download\package\dnsimple

if not exist download\package\dnsimple\lib mkdir download\package\dnsimple\lib
if not exist download\package\dnsimple\lib\4.0 mkdir download\package\dnsimple\lib\4.0

copy src\DNSimple.Api\bin\Release\*.* download\package\DNSimple\lib\4.0\
copy LICENSE.txt download

nuget.exe pack DNSimple.nuspec -BasePath download\package\dnsimple -o download