@0xcfb6d289c6aec20b;
# $$embed
# // Test class description.

using CSharp = import "include/csharp.capnp";

$CSharp.namespace("My.CSharp.Namespace");
$CSharp.nullableEnable(true);

using import "Date.capnp".Date;
using import "PhoneNumber.capnp".PhoneNumber;

struct Test {
  name @0 :Text;
  birthdate : union {
    nullopt @1 :Void;
    value @2 :Date;
  }
  email @3 :Text;
  phones @4 :List(PhoneNumber);
}
