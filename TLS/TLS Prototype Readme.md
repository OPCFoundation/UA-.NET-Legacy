# TLS Prototype Readme #
## Overview ##
The TLS Prototype codebase includes 6 elements:

* Modified C# Stack that supports an TLS transport;
* A C# Server that supports the TLS transport;
* A C# Client that supports TLS as a transport protocol;
* Modified ANSI C Stack that supports an TLS transport;
* An ANSI C Server that supports the TLS transport;
* An ANSI C Client that supports TLS as a transport protocol;

## TLS Transport ##
The TLS Transport has been added to the stack along side the HTTPS and OPC UA TCP Transport. 
The URL scheme opc.tls is used to tell an application to use the TLS transport.

The ANSI C is not a full UA server, however, does implement a Read service that can be invoked without creating a Session.

The C# Client has a menu item that can be used to test ANSI C Server even though it does not support Sessions.