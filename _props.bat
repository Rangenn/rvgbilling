@echo off

set SVN_HOME=C:\Program Files\Subversion\
set NANT_HOME=D:\distr\soft\programming\nant-0.86-beta1
set NANTCONTRIB_HOME=d:\distr\soft\programming\NAntContrib
set NDOC3_HOME=d:\distr\soft\programming\NDoc3
set JAVA_HOME=C:\Program Files\Java\jdk1.6.0_07
set WIKI2XHTML_HOME=d:\distr\soft\programming\Wiki2XHtml
set HTMLHELP_HOME=d:\distr\soft\programming\HtmlHelp


set SVN="%SVN_HOME%\bin\svn"
set NANT="%NANT_HOME%\bin\nant"
set NDOC3="%NDOC3_HOME%\bin\net\2.0\NDoc3Console"
set WIKI2XHTML="%JAVA_HOME%\bin\java"                                        ^
                 -classpath ".;%WIKI2XHTML_HOME%\wiki2xhtml.jar;%CLASSPATH%" ^
                 program.UserInterface
set HHC="%HTMLHELP_HOME%\hhc"
