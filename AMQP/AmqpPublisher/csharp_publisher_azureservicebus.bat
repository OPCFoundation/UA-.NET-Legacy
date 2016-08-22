@echo off
setlocal

set PUBLISHER=AmqpPublisher.exe

set BROKER=amqps://opcfoundation-prototyping.servicebus.windows.net
set USERNAME=sender
set PASSWORD=ry9saNL%%2BHvzEDSI1gfJe5Kcsiro45GDe1QHcMgml9kk%%3D
set AMQPNODENAME=MyTopic

echo -b %BROKER% -u %USERNAME% -p %PASSWORD% -t %AMQPNODENAME% 
%PUBLISHER% -b %BROKER% -u %USERNAME% -p %PASSWORD% -t %AMQPNODENAME% 