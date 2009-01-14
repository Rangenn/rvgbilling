@echo off

call %~sdp0_props.bat

%NANT% -buildfile:%~sdp0main.build setversion