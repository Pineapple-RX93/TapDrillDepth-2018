@Echo on
setlocal
set Appfolder=TapDrillDepth

mkdir %AppData%\Autodesk\ApplicationPlugins\%Appfolder%
copy *.dll %AppData%\Autodesk\ApplicationPlugins\%Appfolder%
copy *.addin %AppData%\Autodesk\ApplicationPlugins\%Appfolder%

endlocal
