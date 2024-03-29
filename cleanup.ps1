### Info util:
### https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/remove-item?view=powershell-6
### https://blogs.technet.microsoft.com/heyscriptingguy/2006/10/23/how-can-i-use-windows-powershell-to-delete-all-the-tmp-files-on-a-drive/
### https://stackoverflow.com/questions/3085295/how-do-i-get-only-directories-using-get-childitem


### Clients
# Remove-Item -Path ".\Client\bower_components" -Recurse -Force -ErrorAction SilentlyContinue
Get-ChildItem -Path  ".\Client" -Exclude "bower_components" | Get-ChildItem -Recurse | where {$_.name -match ".js.map"} | foreach { Remove-Item -Path $_.FullName }
Get-ChildItem -Path  ".\Client" -Exclude "bower_components" | Get-ChildItem -Recurse | where {$_.extension -eq ".js"} | foreach { Remove-Item -Path $_.FullName }


### Server
Remove-Item -Path ".\Server\.vs\" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\Server\Server\bin\*" -Include *.*
Get-ChildItem ".\Server\Server\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Server\Server\obj\*" -Include *.*
Get-ChildItem ".\Server\Server\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}

### Server/NavyBlueDtos
Remove-Item -Path ".\Server\NavyBlueDtos\bin\*" -Include *.*
Get-ChildItem ".\Server\NavyBlueDtos\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Server\NavyBlueDtos\obj\*" -Include *.*
Get-ChildItem ".\Server\NavyBlueDtos\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}

### Server/NavyBlueEntities
Remove-Item -Path ".\Server\NavyBlueEntities\bin\*" -Include *.*
Get-ChildItem ".\Server\NavyBlueEntities\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Server\NavyBlueEntities\obj\*" -Include *.*
Get-ChildItem ".\Server\NavyBlueEntities\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}


### Tools/DatabaseSchemaGenerator
Remove-Item -Path ".\Tools\01.DatabaseSchemaGenerator\.vs\" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\Tools\01.DatabaseSchemaGenerator\Tools\bin\*" -Include *.*
Get-ChildItem ".\Tools\01.DatabaseSchemaGenerator\Tools\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Tools\01.DatabaseSchemaGenerator\Tools\obj\*" -Include *.*
Get-ChildItem ".\Tools\01.DatabaseSchemaGenerator\Tools\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}

### Tools/DatabaseSchemaGenerator/Tests
Remove-Item -Path ".\Tools\01.DatabaseSchemaGenerator\ToolsTests\bin\*" -Include *.*
Get-ChildItem ".\Tools\01.DatabaseSchemaGenerator\ToolsTests\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse}
Remove-Item -path ".\Tools\01.DatabaseSchemaGenerator\ToolsTests\obj\*" -Include *.*
Get-ChildItem ".\Tools\01.DatabaseSchemaGenerator\ToolsTests\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse}


### Tools/DataProviderGeneratorServer
Remove-Item -Path ".\Tools\02.DataProviderGeneratorServer\.vs\" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\Tools\02.DataProviderGeneratorServer\Tools\bin\*" -Include *.*
Get-ChildItem ".\Tools\02.DataProviderGeneratorServer\Tools\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Tools\02.DataProviderGeneratorServer\Tools\obj\*" -Include *.*
Get-ChildItem ".\Tools\02.DataProviderGeneratorServer\Tools\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}

### Tools/MetadataGeneratorClient
Remove-Item -Path ".\Tools\03.MetadataGeneratorClient\.vs\" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\Tools\03.MetadataGeneratorClient\Tools\bin\*" -Include *.*
Get-ChildItem ".\Tools\03.MetadataGeneratorClient\Tools\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Tools\03.MetadataGeneratorClient\Tools\obj\*" -Include *.*
Get-ChildItem ".\Tools\03.MetadataGeneratorClient\Tools\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}

### Tools/DataProviderGeneratorClient
Remove-Item -Path ".\Tools\04.DataProviderGeneratorClient\.vs\" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\Tools\04.DataProviderGeneratorClient\Tools\bin\*" -Include *.*
Get-ChildItem ".\Tools\04.DataProviderGeneratorClient\Tools\bin" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
Remove-Item -path ".\Tools\04.DataProviderGeneratorClient\Tools\obj\*" -Include *.*
Get-ChildItem ".\Tools\04.DataProviderGeneratorClient\Tools\obj" -Directory | foreach ($_) {Remove-Item $_.fullname -Recurse -Force}
