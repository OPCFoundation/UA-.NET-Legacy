# WebSockets Prototype Readme #
## Overview ##
The WebSockets Prototype codebase includes 6 elements:

* Modified C# Stack that supports an WebSockets transport;
* A C# Server that supports the WebSockets transport;
* A C# Client that supports WebSockets as a transport protocol;
* Modified ANSI C Stack that supports an WebSockets transport;
* An ANSI C Server that supports the WebSockets transport;
* An ANSI C Client that supports WebSockets as a transport protocol;

## WebSockets Transport ##
The WebSockets Transport has been added to the stack along side the HTTPS and OPC UA TCP Transport. 
The URL scheme opc.wss is used to tell an application to use the WebSockets transport.

The WebSockets transpoort requires TLS. Technically only TLS1.2 is allowed for OPC UA, however, getting the .NET samples to run on Windows 7 with TLS1.2 enabled takes some effort so the samples have been configured to allow any version of TLS. The [GDS Readme](GDS/readme.md) has more information on configuring TLS 1.2 on Windows 7.

The ANSI C is not a full UA server, however, does implement a Read service that can be invoked without creating a Session.

The C# Client has a menu item that can be used to test ANSI C Server even though it does not support Sessions.

The baked in tests connect once with security and once without. Connecting with security will fail until the client certificate is added to the server trust list. Both the .NET and ANSI C prototype applications use a PKI directory in the same directory as the executable.

The executables for the .NET prototypes are run from $(UaNetRoot}/bin/$(Configuration).
The executables for the ANSIC prototypes are run from $(UaAnsiCRoot}/prototypes/websockets/build/Debug.




