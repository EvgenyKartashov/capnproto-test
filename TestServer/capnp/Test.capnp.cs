using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CapnpGen
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8593d9ec1d0c3175UL)]
    public class Test : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8593d9ec1d0c3175UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Name = reader.Name;
            Email = reader.Email;
            Phones = reader.Phones?.ToReadOnlyList(_ => CapnpSerializable.Create<CapnpGen.Test.PhoneNumber>(_));
            Birthdate = CapnpSerializable.Create<CapnpGen.Date>(reader.Birthdate);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Name = Name;
            writer.Email = Email;
            writer.Phones.Init(Phones, (_s1, _v1) => _v1?.serialize(_s1));
            Birthdate?.serialize(writer.Birthdate);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public IReadOnlyList<CapnpGen.Test.PhoneNumber> Phones
        {
            get;
            set;
        }

        public CapnpGen.Date Birthdate
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Name => ctx.ReadText(0, null);
            public string Email => ctx.ReadText(1, null);
            public IReadOnlyList<CapnpGen.Test.PhoneNumber.READER> Phones => ctx.ReadList(2).Cast(CapnpGen.Test.PhoneNumber.READER.create);
            public CapnpGen.Date.READER Birthdate => ctx.ReadStruct(3, CapnpGen.Date.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 4);
            }

            public string Name
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string Email
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public ListOfStructsSerializer<CapnpGen.Test.PhoneNumber.WRITER> Phones
            {
                get => BuildPointer<ListOfStructsSerializer<CapnpGen.Test.PhoneNumber.WRITER>>(2);
                set => Link(2, value);
            }

            public CapnpGen.Date.WRITER Birthdate
            {
                get => BuildPointer<CapnpGen.Date.WRITER>(3);
                set => Link(3, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc6889a88381da3d2UL)]
        public class PhoneNumber : ICapnpSerializable
        {
            public const UInt64 typeId = 0xc6889a88381da3d2UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Number = reader.Number;
                TheType = reader.TheType;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Number = Number;
                writer.TheType = TheType;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public string Number
            {
                get;
                set;
            }

            public CapnpGen.Test.PhoneNumber.Type TheType
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public string Number => ctx.ReadText(0, null);
                public CapnpGen.Test.PhoneNumber.Type TheType => (CapnpGen.Test.PhoneNumber.Type)ctx.ReadDataUShort(0UL, (ushort)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 1);
                }

                public string Number
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public CapnpGen.Test.PhoneNumber.Type TheType
                {
                    get => (CapnpGen.Test.PhoneNumber.Type)this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, (ushort)value, (ushort)0);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb73cfc9813a2a826UL)]
            public enum Type : ushort
            {
                mobile,
                home,
                work
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd562cf411c176be8UL)]
    public class Date : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd562cf411c176be8UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Year = reader.Year;
            Month = reader.Month;
            Day = reader.Day;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Year = Year;
            writer.Month = Month;
            writer.Day = Day;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public short Year
        {
            get;
            set;
        }

        public byte Month
        {
            get;
            set;
        }

        public byte Day
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public short Year => ctx.ReadDataShort(0UL, (short)0);
            public byte Month => ctx.ReadDataByte(16UL, (byte)0);
            public byte Day => ctx.ReadDataByte(24UL, (byte)0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public short Year
            {
                get => this.ReadDataShort(0UL, (short)0);
                set => this.WriteData(0UL, value, (short)0);
            }

            public byte Month
            {
                get => this.ReadDataByte(16UL, (byte)0);
                set => this.WriteData(16UL, value, (byte)0);
            }

            public byte Day
            {
                get => this.ReadDataByte(24UL, (byte)0);
                set => this.WriteData(24UL, value, (byte)0);
            }
        }
    }
}