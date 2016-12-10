# WebSockets Prototype Readme #
## Overview ##
The WebSockets Prototype codebase includes 7 elements:

* Modified C# Stack that supports an WebSockets transport;
* A C# Server that supports the WebSockets transport;
* A C# Client that supports WebSockets as a transport protocol;
* Modified ANSI C Stack that supports an WebSockets transport;
* An ANSI C Server that supports the WebSockets transport;
* An ANSI C Client that supports WebSockets as a transport protocol;
* A simple website that uses JavaScript + JSON to communicate with the C# Server (the ANSIC Server does not support JSON).

## WebSockets Transport ##
The WebSockets Transport has been added to the stack along side the HTTPS and OPC UA TCP Transport. 
The URL scheme opc.wss is used to tell an application to use the WebSockets transport.

The WebSockets transpoort requires TLS. Technically only TLS1.2 is allowed for OPC UA, however, getting the .NET samples to run on Windows 7 with TLS1.2 enabled takes some effort so the samples have been configured to allow any version of TLS. The [GDS Readme](../GDS/README.md) has more information on configuring TLS 1.2 on Windows 7.

The ANSI C is not a full UA server, however, does implement a Read service that can be invoked without creating a Session.

The C# Client has a menu item that can be used to test ANSI C Server even though it does not support Sessions.

The baked in tests connect once with security and once without. Connecting with security will fail until the client certificate is added to the server trust list. Both the .NET and ANSI C prototype applications use a PKI directory in the same directory as the executable.

The executables for the .NET prototypes are run from $(UaNetRoot}/bin/$(Configuration).
The executables for the ANSIC prototypes are run from $(UaAnsiCRoot}/prototypes/websockets/build/Debug.

## Browser-based JavaScript Clients ##
The WebSocketsWebHmi project is a simple ASP .NET project that has been published to [https://opcfoundation-prototyping.org/](https://opcfoundation-prototyping.org/). This page should allow a WebBrowser to connect the C# WebSockets Prototype Server running on any machine that the browser can reach provided the a TLS certificate signed by a trusted authority (from the perspective of the machine running the browser). 

The facilitate this requirement C# WebSockets Prototype Server checks the 'LocalMachine\My' store for a valid TLS certificate that matches the domain of the URL with a private key that the process can access. If one exists it uses this certificate as its TLS certificate instead of its application instance certificate. At the application level (i.e. the certificates used in the CreateSession/ActivateSession handshake) the C# WebSockets Prototype Server still uses its application instance certificate. 







