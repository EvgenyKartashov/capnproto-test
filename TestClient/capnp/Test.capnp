@0xcfb6d289c6aec20b;

using import "Date.capnp".Date;
using import "PhoneNumber.capnp".PhoneNumber;

struct Test {
  name @0 :Text;
  birthdate @3 :Date;

  email @1 :Text;
  phones @2 :List(PhoneNumber);
}
