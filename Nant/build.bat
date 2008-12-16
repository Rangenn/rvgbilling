@echo off

call %~sdp0_props.bat

%NANT% -buildfile:%~sdp0main.build clean
%NANT% -buildfile:%~sdp0main.build reloadsrc
%NANT% -buildfile:%~sdp0main.build build -t:net-3.5
