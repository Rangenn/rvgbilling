@echo off

set SVN_HOME=G:\Program Files\Subversion\
set NANT_HOME=G:\Program Files\NAnt\nant-0.86-beta1
set NANTCONTRIB_HOME=G:\Program Files\NAnt\nantcontrib-0.85
set NDOC3_HOME=d:\distr\soft\programming\NDoc3
set JAVA_HOME=G:\Program Files\jdk1.6.0_7
set WIKI2XHTML_HOME=d:\distr\soft\programming\Wiki2XHtml
set HTMLHELP_HOME=d:\distr\soft\programming\HtmlHelp


set SVN="%SVN_HOME%\bin\svn"
set NANT="%NANT_HOME%\bin\nant"
set NDOC3="%NDOC3_HOME%\bin\net\2.0\NDoc3Console"
set WIKI2XHTML="%JAVA_HOME%\bin\java"                                        ^
                 -classpath ".;%WIKI2XHTML_HOME%\wiki2xhtml.jar;%CLASSPATH%" ^
                 program.UserInterface
set HHC="%HTMLHELP_HOME%\hhc"
