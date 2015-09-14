@echo off
setlocal

SET PATH=%PATH%;..\..\Bin\Debug;..\..\..\Bin

REM These lines will build the sample design if the batch file is run from the project directory

echo Building TestData
Opc.Ua.ModelCompiler.exe -d2 ".\TestData\TestDataDesign.xml" -cg ".\TestData\TestDataDesign.csv" -o2 ".\TestData" -useXmlInitializers
echo Success!

echo Building MemoryBuffer
Opc.Ua.ModelCompiler.exe -d2 ".\MemoryBuffer\MemoryBufferDesign.xml" -cg ".\MemoryBuffer\MemoryBufferDesign.csv" -o ".\MemoryBuffer" 
echo Success!

echo Building FileSystem
Opc.Ua.ModelCompiler.exe -d2 ".\FileSystem\FileSystemDesign.xml" -cg ".\FileSystem\FileSystemDesign.csv" -o ".\FileSystem" 
echo Success!

echo Building BoilerDesign V2
Opc.Ua.ModelCompiler.exe -d2 ".\Boiler\BoilerDesign.xml" -c ".\Boiler\BoilerDesign.csv" -o2 ".\Boiler"
echo Success!

REM echo Building BoilerDesign V1
REM Opc.Ua.ModelCompiler.exe -d ".\Sample\SampleDesign.xml" -c ".\Sample\SampleDesign.csv" -o ".\Sample"
REM echo Success!
