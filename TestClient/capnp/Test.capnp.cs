// Test class description.
using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace My.CSharp.Namespace
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
            Phones = reader.Phones?.ToReadOnlyList(_ => CapnpSerializable.Create<My.CSharp.Namespace.PhoneNumber>(_)!);
            Birthdate = CapnpSerializable.Create<My.CSharp.Namespace.Date>(reader.Birthdate);
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

        public string? Name
        {
            get;
            set;
        }

        public string? Email
        {
            get;
            set;
        }

        public IReadOnlyList<My.CSharp.Namespace.PhoneNumber>? Phones
        {
            get;
            set;
        }

        public My.CSharp.Namespace.Date? Birthdate
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
            public string? Name => ctx.ReadText(0, null);
            public string? Email => ctx.ReadText(1, null);
            public IReadOnlyList<My.CSharp.Namespace.PhoneNumber.READER> Phones => ctx.ReadList(2).Cast(My.CSharp.Namespace.PhoneNumber.READER.create);
            public My.CSharp.Namespace.Date.READER Birthdate => ctx.ReadStruct(3, My.CSharp.Namespace.Date.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 4);
            }

            public string? Name
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string? Email
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public ListOfStructsSerializer<My.CSharp.Namespace.PhoneNumber.WRITER> Phones
            {
                get => BuildPointer<ListOfStructsSerializer<My.CSharp.Namespace.PhoneNumber.WRITER>>(2);
                set => Link(2, value);
            }

            public My.CSharp.Namespace.Date.WRITER Birthdate
            {
                get => BuildPointer<My.CSharp.Namespace.Date.WRITER>(3);
                set => Link(3, value);
            }
        }
    }
}