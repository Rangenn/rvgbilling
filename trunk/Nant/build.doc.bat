@echo off

call "%~dp0_props.bat"


set BASE_DIR=%~dp0.
set DOC_DIR=%BASE_DIR%\doc
set BIN_DIR=%BASE_DIR%\bin
set BIN_DOC_DIR=%BIN_DIR%\doc
set BIN_DOC_SRC_DIR=%BIN_DIR%\doc\src
set OUT_DIR=%BASE_DIR%\out


md %BIN_DOC_DIR% >nul 2>nul


%NDOC3% -documenter=MSDN                               ^
        -recurse="%BIN_DIR%"                           ^
        -OutputDirectory="%BIN_DOC_SRC_DIR%"           ^
        -HtmlHelpName=RVGBilling.src                   ^
        -Title=RVGBilling                              ^
        -RootPageContainsNamespaces=True               ^
        -HeaderHtml=^%TOPIC_TITLE^%                    ^
        -FooterHtml=^%ASSEMBLY_NAME^%                  ^
        -LangID=1049                                   ^
        -DocumentExplicitInterfaceImplementations=True ^
        -DocumentInternals=True                        ^
        -DocumentSealedProtected=True                  ^
        -DocumentPrivates=True                         ^
        -DocumentProtectedInternalAsProtected=True     ^
        -DocumentEmptyNamespaces=True                  ^
        -AssemblyVersionInfo=AssemblyVersion           ^
        -SdkDocVersionString=VS.80                     ^
        -DocumentAttributes=True                       ^
        -ShowTypeIdInAttributes=True                   ^
        -IncludeDefaultThreadSafety=False
copy /y "%BIN_DOC_SRC_DIR%\*.chm" "%BIN_DOC_DIR%"


%WIKI2XHTML% --lang=ru                                 ^
             --style="%DOC_DIR%\wiki2xhtml.style"      ^
             --target-dir="%BIN_DOC_DIR%\manual"       ^
             %DOC_DIR%\manual\*.wiki
copy /y "%DOC_DIR%\manual\*.html" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.htm" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.txt" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.css" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.js" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.gif" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.png" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.jpg" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.jpeg" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\manual\*.bmp" "%BIN_DOC_DIR%\manual"
copy /y "%DOC_DIR%\RVGBilling.*" "%BIN_DOC_DIR%"


%HHC% "%BIN_DOC_DIR%\RVGBilling.hhp"

copy /y "%BASE_DIR%\src\RVGlib\RVGlibTest\bin\debug\RVGlib.dll" "%BIN_DIR%"
copy /y "%BASE_DIR%\src\RVGlib\RVGlibTest\bin\debug\RVGlibTest.dll" "%BIN_DIR%"
copy /y "%BASE_DIR%\src\docs\hibernate.cfg.xml" "%BIN_DIR%"
copy /y "%BIN_DOC_DIR%\*.chm" "%OUT_DIR%"
