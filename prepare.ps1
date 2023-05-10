$shellPath = Get-Location

$pathArray = @();
$pathArray += Join-Path $shellPath "\Assets\Scripts"
$pathArray += Join-Path $shellPath "\Assets\Scripts\ScriptableObject"
$pathArray += Join-Path $shellPath "\Assets\Materials"
$pathArray += Join-Path $shellPath "\Assets\Resources"
$pathArray += Join-Path $shellPath "\Assets\Resources\ProjectAssets"
$pathArray += Join-Path $shellPath "\Assets\Resources\Prefabs"
$pathArray += Join-Path $shellPath "\Assets\Resources\Effect"
$pathArray += Join-Path $shellPath "\Assets\Resources\Texture"

foreach($path in $pathArray){
    if( Test-Path $path ){

    }else{
        New-Item $path -ItemType Directory
    }
}
