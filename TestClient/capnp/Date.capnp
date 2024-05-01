@0xc48ad2550447216a;

using CSharp = import "include/csharp.capnp";

$CSharp.namespace("My.CSharp.Namespace");
$CSharp.nullableEnable(true);

struct Date {
  year @0 :Int16;
  month @1 :UInt8;
  day @2 :UInt8;
}
