@0xcfb6d289c6aec20b;

using import "Date.capnp".Date;
using import "PhoneNumber.capnp".PhoneNumber;

annotation foo(struct) :Text;
annotation bar(field) :Text;

struct Test $foo("struct annotation") {
  name @0 :Text $bar("field annotation");
  birthdate @3 :Date;

  email @1 :Text;
  phones @2 :List(PhoneNumber);
}
