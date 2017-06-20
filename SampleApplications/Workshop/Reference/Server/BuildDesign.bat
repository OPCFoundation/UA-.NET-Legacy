@echo off
setlocal

SET PATH=%PATH%;..\..\..\Bin\Debug

echo Building ModelDesign
Opc.Ua.ModelCompiler.exe -d2 ".\Model\ModelDesign.xml" -cg ".\Model\ModelDesign.csv" -o2 ".\Model"
echo Success!



