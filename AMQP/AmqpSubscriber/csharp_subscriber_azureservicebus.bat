@echo off
setlocal

set SUBSCRIBER=AmqpSubscriber.exe

set BROKER=amqps://opcfoundation-prototyping.servicebus.windows.net
set USERNAME=receiver
set PASSWORD=up9a%%2BDN18fu2yJB3BakphmFXta%%2BP1mEjL7V%%2FEGWwmXE%%3D
set AMQPNODENAME=MyTopic/Subscriptions/default

echo -b %BROKER% -u %USERNAME% -p %PASSWORD% -t %AMQPNODENAME% 
%SUBSCRIBER% -b %BROKER% -u %USERNAME% -p %PASSWORD% -t %AMQPNODENAME% 