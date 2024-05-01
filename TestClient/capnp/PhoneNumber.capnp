@0xbe6ce010c0c1e9cd;

using import "PhoneNumberType.capnp".PhoneNumberType;

struct PhoneNumber {
    number @0 :Text;
    type @1 :PhoneNumberType;
}
