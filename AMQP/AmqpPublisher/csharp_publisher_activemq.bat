@echo off
setlocal	

set PUBLISHER=AmqpPublisher.exe

set BROKER=amqps://opcfoundation-prototyping.org
set USERNAME=sender
set PASSWORD=password
set AMQPNODENAME=topic://Topic1

echo -b %BROKER% -u %USERNAME% -p %PASSWORD% -t %AMQPNODENAME% 
%PUBLISHER% -b %BROKER% -u %USERNAME% -p %PASSWORD% -t %AMQPNODENAME% 
	