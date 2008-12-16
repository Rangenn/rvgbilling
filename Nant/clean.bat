@echo off

call "%~dp0_props.bat"


%NANT% -buildfile:%~sdp0main.build clean
