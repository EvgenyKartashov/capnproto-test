@0xd5a9825e2101da7c;

using CSharp = import "include/csharp.capnp";

$CSharp.namespace("My.CSharp.Namespace");
$CSharp.nullableEnable(true);

enum PhoneNumberType {
    mobile @0;
    home @1;
    work @2;
}
