@echo off
setlocal

SET PATH=%PATH%;..\..\..\Bin;..\..\..\Scripts

echo Building ModelDesign
Opc.Ua.ModelCompiler.exe -d2 ".\Model\ModelDesign.xml" -cg ".\Model\ModelDesign.csv" -o2 ".\Model\"
echo Success!

copy ".\Model\*.Constants.cs" ..\Client\

cd Schema

echo Building Mapping Schema
xsd /classes /n:DsatsDemo.DataSource DataSource.xsd UANodeSet.xsd UAVariant.xsd


