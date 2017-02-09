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

Note that getting the ANSI C samples and the .NET samples to interoperate requires that the client certificates be copied into the server trust lists. 

## Browser-based JavaScript Clients ##
The WebSocketsWebHmi project is a simple ASP .NET project that has been published to [https://opcfoundation-prototyping.org/](https://opcfoundation-prototyping.org/). This page should allow a WebBrowser to connect the C# WebSockets Prototype Server running on any machine that the browser can reach provided the a TLS certificate signed by a trusted authority (from the perspective of the machine running the browser). 

The facilitate this requirement C# WebSockets Prototype Server checks the 'LocalMachine\My' store for a valid TLS certificate that matches the domain of the URL with a private key that the process can access. If one exists it uses this certificate as its TLS certificate instead of its application instance certificate. At the application level (i.e. the certificates used in the CreateSession/ActivateSession handshake) the C# WebSockets Prototype Server still uses its application instance certificate. Note that this feature requires that the Server application be lauched as an adminitrator.

Note that setting up a certificate to get the WebSocket samples to work in a development environment takes a little fiddling:
* 1) Create a Root CA certificate and install it in LocalMachine\Root certificate store;
* 2) Create a HTTPS certificate with a common name (CN=) equal to the machine name that was issued by the Root CA and install in LocalMachine\My;
* 3) Use Windows powershell to assign the certificate created in 2) to the websocket port used by the server (65200); 

The command to create the CA certificate is:
```
Opc.Ua.CertificateGenerator.exe -sp pki -cmd issue -sn "CN=Prototyping 2017/O=My Company" -ca true -ks 2048 -lm 12 -st 131277024000000000
```

The command to create the HTTPS certificate is:
```
Opc.Ua.CertificateGenerator.exe -sp pki -cmd issue -sn CN=mycomputer -dn mycomputer,localhost -au urn:mycomputer -ks 2048 -st 131277024000000000 -lm 12 -ikf "pki\private\Prototyping 2017 [<thumprint of root ca certificate>].pfx"
```

The command to assign the HTTPS certificate to a port is (from power shell prompt):
```
netsh
http
add sslcert ipport=0.0.0.0:65200 certhash=<thumprint of HTTPS certificate> appid={<any valid guid>}
```

This has not been tested on Windows 7 and may require that TLS 1.2 be enabled. See [GDS setup](https://github.com/OPCFoundation/UA-.NET/blob/prototyping/GDS/gdsdb_setup.md) for more information.


