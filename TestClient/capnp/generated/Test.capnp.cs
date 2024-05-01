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
            Phones = reader.Phones?.ToReadOnlyList(_ => CapnpSerializable.Create<CapnpGen.PhoneNumber>(_));
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

        public IReadOnlyList<CapnpGen.PhoneNumber> Phones
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
            public IReadOnlyList<CapnpGen.PhoneNumber.READER> Phones => ctx.ReadList(2).Cast(CapnpGen.PhoneNumber.READER.create);
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

            public ListOfStructsSerializer<CapnpGen.PhoneNumber.WRITER> Phones
            {
                get => BuildPointer<ListOfStructsSerializer<CapnpGen.PhoneNumber.WRITER>>(2);
                set => Link(2, value);
            }

            public CapnpGen.Date.WRITER Birthdate
            {
                get => BuildPointer<CapnpGen.Date.WRITER>(3);
                set => Link(3, value);
            }
        }
    }
}