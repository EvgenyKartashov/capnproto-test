@0xbe6ce010c0c1e9cd;

using CSharp = import "include/csharp.capnp";

$CSharp.namespace("My.CSharp.Namespace");
$CSharp.nullableEnable(true);

using import "PhoneNumberType.capnp".PhoneNumberType;

struct PhoneNumber {
    number @0 :Text;
    type @1 :PhoneNumberType;
}
