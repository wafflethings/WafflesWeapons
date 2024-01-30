echo waffle asset downloader!!
echo make sure that you are logged into git and your account has tundra access

git clone git@github.com:Tundra-Editor/Config.git TempTundra
xcopy "%cd%\TempTundra" "%cd%" /E /Y
RD /s /q "%cd%\TempTundra"
RD /s /q "%cd%\Git"
RD /s /q "%cd%\Scripts"

git clone git@github.com:Tundra-Editor/AddressableAssetsData.git "Assets/AddressableAssetsData"
RD /s /q "%cd%\Assets\AddressableAssetsData\.git"
del "%cd%\Assets\AddressableAssetsData\.gitignore"

git submodule add "https://github.com/Tundra-Editor/Prefabs.git" "Assets/ULTRAKILL Prefabs"
git submodule add "https://github.com/Tundra-Editor/Assets.git" "Assets/Common"
git submodule add "https://github.com/Tundra-Editor/Components.git" "Assets/Components"

pause