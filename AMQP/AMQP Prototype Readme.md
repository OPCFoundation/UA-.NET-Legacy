# AMQP Prototype Readme #
## Overview ##
The AMQP Prototype .NET codebase includes 5 elements:

* Modified C# Stack that supports an AMQP transport and JSON encoding/decoding;
* A C# Server that supports the AMQP transport and the PubSub information model;
* A C# Client that supports AMQP as a transport protocol;
* A basic C# AMQP client able to consume and parse JSON messages; 
* A basic C# AMQP client able to construct and publish JSON messages; 

The samples also rely on the following services:
* An ActiveMQ broker installed on opcfoundation-prototyping.org;
  Endpoint: amqpa://opcfoundation-prototyping.org/Server1/
* An Azure ServiceBus broker installed on opcfoundation-prototyping.servicebus.windows.net;
  Endpoint: amqps://opcfoundation-prototyping.servicebus.windows.net/MyServer/

The ActiveMQ server has a Certificate issued by a [OPC-F Prototyping CA](activemq_cacertificate.der);
  It is necessary to add this Certificate to the LocalMachine TrustedRootCertificationAuthorities store before using the ActiveMQ samples.
 
## AQMP Transport ##
The AMQP Transport has been added to the stack along side the HTTPS and OPC UA TCP Transport. 
  The URL schema opc.amqp is used to tell an application to use the AMQP transport.

## Running the Samples ##
The AmqpTestServer.exe will create a UA server that listens on a queue and publishes to a topic.
  The AmqpTestClient.exe will listen to a queue for replies and connect to a Server via AMQP.
  The AmqpSubscriber.exe will subscribe to the topic being used by AmqpTestServer.exe.

Note that only one person can use the UA over AMQP samples at a time because the AMQP queues are fixed. The PubSub samples allow simultaneous publishers and subscribers.
That said, the samples will dynamically create new queues with the ActiveMQ broker if different names are entered into the configuration file and the samples are restarted. e.g. replace all instances of ‘Server1’ with ‘MyName/Server1’ and ‘Client1’ with ‘MyName/Client1’.

| Batch File | Description |
|------------|-------------|
|csharp_publisher_activemq|Publishes to the ActiveMQ broker|
|csharp_publisher_azureservicebus|Publishes data to the Azure ServiceBus broker|
|csharp_subscriber_activemq|Subscribes to the ActiveMQ broker|
|csharp_subscriber_azureservicebus|Subscribes to the Azure ServiceBus broker|

Some notes about passing URL encoded parameters to command line applications:

* If in a batch file the % chararacters must be doubled;
* If specified as VisualStudio project arguments for C/C++ programs then URL encoding must be done twice;
* If specified as VisualStudio project arguments C# programs then URL encoding is only done once;
 
## Stack Changes ##
The stack adds AMQP binding which uses the AMQP Lite .NET library.
It also provides a JSON encoder/decoder based on the Newtonsoft JSON library.
The changes introduce a new configuration element called AmqpBrokerConfiguration:
```xml
<AmqpBrokerConfiguration>
  <BrokerAddress>opcfoundation-prototyping.org</BrokerAddress>
  <IncomingTerminus>Server1</IncomingTerminus>
  <UseSasl>false</UseSasl>
  <ReceiveKeyName>receiver</ReceiveKeyName>
  <ReceiveKeyValue>password</ReceiveKeyValue>
  <SendKeyName>sender</SendKeyName>
  <SendKeyValue>password</SendKeyValue>
  <ServerKeys>
    <AmqpBrokerKeySet>
      <Terminus>topic://Topic1</Terminus>
      <KeyName>sender</KeyName>
      <KeyValue>password</KeyValue>
    </AmqpBrokerKeySet>
  </ServerKeys>
</AmqpBrokerConfiguration>
```
The fields in AmqpBrokerConfiguration are:

| Field | Description |
|------------|-------------|
|BrokerAddress|The DNS name of the broker.|
|IncomingTerminus|The name of the queue used to listen for incoming requests.|
|UseSasl|Whether SASL based credentials should be used.  Only supported by Azure at this time.|
|ReceiveKeyName|The username or shared key name used to receive messages.  It must be URL encoded if non-alphanumeric characters exist.|
|ReceiveKeyValue|The password or shared key used to receive messages.  It must be URL encoded if non-alphanumeric characters exist.|
|SendKeyName|The username or shared key name used to send messages.  It must be URL encoded if non-alphanumeric characters exist.|
|SendKeyValue|The password or shared key used to send messages.  It must be URL encoded if non-alphanumeric characters exist.|
|ServerKeys|A list of additional keys for additional destinations.  It is use to configure clients to communicate with servers or to configure servers to publish to topics.|

The fields in AmqpBrokerKeySet are:

| Field | Description |
|------------|-------------|
|Terminus|The fully qualified name of the destination.  The format of the fully qualified name depends on the broker.  ActiveMQ uses the topic:// prefix for topics.|
|KeyName|The username or shared key name used to send messages.  It must be URL encoded if non-alphanumeric characters exist.|
|KeyValue|The password or shared key used to send messages.  It must be URL encoded if non-alphanumeric characters exist.|

The PubSub information model in a server is configured a AmqpDataSetConfiguration element:
```xml
<AmqpDataSetConfiguration>
  <Name>AllEvents</Name>
  <NotifierId><Identifier>i=2253</Identifier></NotifierId>
  <EventTypeId><Identifier>i=2041</Identifier></EventTypeId>
  <Connections>
    <AmqpConnectionConfiguration>
      <ConnectionName>ActiveMQ</ConnectionName>
      <BrokerUrl>amqp://opcfoundation-prototyping.org</BrokerUrl>
      <GroupName>Topic1</GroupName>
      <TargetName>topic://Topic1</TargetName>
    </AmqpConnectionConfiguration>
    <AmqpConnectionConfiguration>
      <ConnectionName>Microsoft ServiceBus</ConnectionName>
      <BrokerUrl>amqps://opcfoundation-prototyping.servicebus.windows.net</BrokerUrl>
      <GroupName>MyTopic</GroupName>
      <TargetName>MyTopic</TargetName>
    </AmqpConnectionConfiguration>
  </Connections>
</AmqpDataSetConfiguration>
```
The fields in AmqpDataSetConfiguration are:

| Field | Description |
|------------|-------------|
|Name|The name of the DataSet.|
|NotifierId|The NodeId of the notifier for the DataSet event subscription.|
|EventTypeId|The NodeId of the event type filter for the DataSet event subscription.|
|Connections|The list of connections which are destinations for the events.|

The fields in AmqpConnectionConfiguration are: 

| Field | Description |
|------------|-------------|
|Connection|The name of the connection object.|
|BrokerUrl|The  URL of the broker.|
|GroupName|The name of the group object.|
|TargetName|The name of the destination.|

The security settings used to publish events come from the AmqpBrokerConfiguration settings. The DNS name from the BrokerUrl is used to find the record and the TargetName is used to find the ServerKeys.

## Configuring ActiveMQ ##
ActiveMQ is running on amqps://opcfoundation-prototyping.org
It has two queues to support the OPC UA relay: Server1 and Client1
It has 1 topic for PubSub: Topic1
There are two users with full rights:
•	receiver/password
•	sender/password
Note that these users will automatically create non-existent queues which means typos in files can result in no messages even if the connections look good.
The fully qualified topic names add a ‘topic://’ prefix. For example: topic://Topic1

## Configuring Azure ServiceBus ##
Azure ServiceBus is run on amqps://opcfoundation-prototyping.servicebus.windows.net
It has two queues to support the OPC UA relay: MyServer and MyClient
It has 1 topic for PubSub: MyTopic
Each entity has two security keys: sender and receiver
sender is send only. receiver has full rights.

| Terminus | Key Name | Security Key |
|------------|-------------|-------------|
|MyServer|sender|rdOWB7cUiVIGkHJPD5YOF0b5Xukpa7u6XL4uS932mFA=|
|MyServer|receiver|wK7wFVR0rgZHpGQSjs35cySqiM8BLJLraYLoFCdMLjA=|
|MyClient|sender|SA6vw+CdqtqOhkyIh38YeyltZ1juYOW8VSPsnNH4bME=|
|MyClient|receiver|uuXzB4A3gABejBkdAfhdtPT4NVrcC3cDsp7CE+8tpO8=|
|MyTopic|sender|ry9saNL+HvzEDSI1gfJe5Kcsiro45GDe1QHcMgml9kk=|
|MyTopic/Subcriptions/default|receiver|up9a+DN18fu2yJB3BakphmFXta+P1mEjL7V/EGWwmXE=|

Note that the keys need to be URL encoded if stored in a configuration file.
  The messages in the queue/topic timeout after 1 minute which might cause issues when debugging. This is done to ensure that multiple debug sessions are not messed up by leftover messages.

