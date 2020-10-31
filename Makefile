run:
	@dotnet run -p ./src/cscli.csproj

watch:
	@dotnet watch -p ./src/cscli.csproj run 

dry-run:
	@dotnet run -p ./src/cscli.csproj --no-build

test:
	@dotnet test

.DEFAULT_GOAL := run