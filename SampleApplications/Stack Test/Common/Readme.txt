The StackTest Client and Server appliations are used to verify that the serializers and the stack.

The tool currently tests the following stacks:

1) WCF + C# UA TCP + UA Binary
2) WCF + ANSI C UA TCP + UA Binary
3) WCF + SOAP/HTTP + UA Binary
4) WCF + SOAP/HTTP + UA XML

The test cases fall into 3 groups:

1) Direct Serializer
2) Normal
3) Abnormal 
4) Multiple Channel


The Direct Serializer tests are Used to test interoperability between the C# and the ANSI C serializers. They are skipped when testing an actual connection between two servers and must be invoked by clicking Test | Serializers Direct in the main menu.

SerializerDirect - tests basic types
SerializerDirectEx - tests structures contained in ExtensionObjects

The Normal Tests verify that different types of data can be exchanged correctly.

ScalarValues - test basic types
ArrayValues - tests arrays of basic types
ExtensionObjectValues - tests structures contained in ExtensionObjects
BuiltInTypes - tests a single structure that contains every possible built-in datatype,

The Abnormal Tests verify correct operation under a variety of error conditions.

ServerFault - verifies that application faults are returned correctly.
ServerTimeout - verifies that clients can set a timeout per operation.

The following abnormal tests verify that UA TCP implementations automatically reconnect after error:

Interrupted Listener - the socket is closed for a period of type requiring the client to retry.
Corrupt Messages - messages are corrupted which produces a signature verification error.
Duplicate Sequence Numbers - messages are sent with previously used sequence numbers.
Broken Sockets - the socket is closed.

The test client will still run the tests for SOAP/HTTP stacks, however, no errors will be generated. These tests simply verify that the SOAP/HTTP stacks support out of order message processing.

The Multiple Channel channel tests verify that stack is capable of handling many independent channels.

Note the abornmal test define two parameters that depend on the processing speed of the machine used for testing: MaxRecoveryTime and MaxTransportDelay. If the tests fail because timeouts are exceeded then these numbers may need to be increased. Note that making these numbers too large willl render the test useless. If a system cannot handle values close to the default values then the StackEventFrequency must be increased as well. This parameter controls how frequently the errors are generated. If the StackEventFrequency is 3 then errors are generated every 3 seconds. The MaxRecoveryTime should not exceed the type between requests.