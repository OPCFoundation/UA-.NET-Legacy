# Setting up the GDS Database #
The GDS requires an instance of SQL server. It can be any instance >SQL Server 2012.
A free version can be downloaded [here](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express).
The Client Tools component must also be installed.

The instance that it connects to is defined in the app.config for the GlobalDiscoveryServer project.
It can be changed by editing the 'gdsEntities' connection string.
The default uses the '.\SQLEXPRESS' named instance with integrated Windows authentication.
(when installing SQL server make a named instance is created)

If a new instance is installed the GDS database needs to be created with this command (the exact location depends on the system):
```
[sqlutilspath]\osql -S .\SQLEXPRESS -E
1> create database gdsdb
2> go
3> exit
```
A possible location for [sqlutilspath] is C:\Program Files\Microsoft SQL Server\130\Tools\Binn\

Once the DB exists the following command can be used to create or reset the tables:
```
[sqlutilspath]\osql -S .\SQLEXPRESS -E -d gdsdb -i [coderoot]\GDS\Common\DB\Tables.sql
```

### Setting up the GDS Certificates ###
Setting up the GDS OAuth2 Service on a new machine requires that a HTTPS certificate be created and then registered with windows. This can be done with the Windows Power Shell (must be launched with Administrator priviledges). The steps are:

On Windows 10 create a new certificate (replace [hostname] with the actual hostname):
```
New-SelfSignedCertificate -DnsName [hostname] -CertStoreLocation cert:Localmachine\My -HashAlgorithm SHA256
```

On Windows 7 create a new certificate (replace [hostname] with the actual hostname and [coderoot] with the root of the source tree):
```
[coderoot]\Bin\Opc.Ua.CertificateGenerator.exe -cmd issue -an [hostname] -dn [hostname] -sp st -hs 256 -ks 2048 
```
then from the certificate manager ([mmc | certificates](https://msdn.microsoft.com/en-us/library/ms788967(v=vs.110).aspx)) install the certificate in LocalMachine\My (Personal)


Register the ports (Authorization Service and GDS HTTPS Endpoint):
```
netsh
http
add sslcert ipport=0.0.0.0:54333 certhash=<thumprint> appid={00112233-4455-6677-8899-AABBCCDDEEFF}
add sslcert ipport=0.0.0.0:58811 certhash=<thumprint> appid={00112233-4455-6677-8899-AABBCCDDEEFF}
```
The appid can be any valid GUID. 
The certhash is the thumprint created in the first step.

On Windows 7 and Windows Server 2008 TLS 1.2 must be explicitly enabled by creating following registry keys with powershell:

```
md "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2"
md "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2\Server"
md "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2\Client"

new-itemproperty -path "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2\Server" -name "Enabled" -value 1 -PropertyType "DWord"
new-itemproperty -path "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2\Server" -name "DisabledByDefault" -value 0 -PropertyType "DWord"
new-itemproperty -path "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2\Client" -name "Enabled" -value 1 -PropertyType "DWord"
new-itemproperty -path "HKLM:\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS 1.2\Client" -name "DisabledByDefault" -value 0 -PropertyType "DWord"
```
After creating the registry keys the machine *must* be rebooted.

On Windows 7 you should confirm that TLS 1.2 is enabled by using Chrome to navigate to https://[hostname]:54333/ and looking at the certificate details.

