import shutil
import sys
import os
import subprocess

subprocess.run(["dotnet", "build"])

if len(sys.argv) < 2:
    print("Needs the destination paths as arguments (e.g. BepIn plugins folder and Unity plugins folder, seperated by spaces)")
    exit()
    
oldPath = os.path.join(os.getcwd(), "WafflesWeapons", "bin", "Debug", "net472", "WafflesWeapons.dll")

isFirst = True
for path in sys.argv:
    if isFirst:
        isFirst = False
        continue
    newPath = os.path.join(path, "WafflesWeapons.dll")
    shutil.copyfile(oldPath, newPath)
    print(f"Copied to {newPath}!")

if os.name == "nt":
    subprocess.run("cmd /c start steam://launch/1229490")
elif os.name == "posix":
    subprocess.run(["steam", "steam://run/1229490"])
