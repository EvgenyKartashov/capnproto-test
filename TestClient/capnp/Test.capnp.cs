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
            Birthdate = CapnpSerializable.Create<My.CSharp.Namespace.Test.birthdate>(reader.Birthdate);
            Email = reader.Email;
            Phones = reader.Phones?.ToReadOnlyList(_ => CapnpSerializable.Create<My.CSharp.Namespace.PhoneNumber>(_)!);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Name = Name;
            Birthdate?.serialize(writer.Birthdate);
            writer.Email = Email;
            writer.Phones.Init(Phones, (_s1, _v1) => _v1?.serialize(_s1));
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

        public My.CSharp.Namespace.Test.birthdate? Birthdate
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
            public birthdate.READER Birthdate => new birthdate.READER(ctx);
            public string? Email => ctx.ReadText(2, null);
            public IReadOnlyList<My.CSharp.Namespace.PhoneNumber.READER> Phones => ctx.ReadList(3).Cast(My.CSharp.Namespace.PhoneNumber.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 4);
            }

            public string? Name
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public birthdate.WRITER Birthdate
            {
                get => Rewrap<birthdate.WRITER>();
            }

            public string? Email
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public ListOfStructsSerializer<My.CSharp.Namespace.PhoneNumber.WRITER> Phones
            {
                get => BuildPointer<ListOfStructsSerializer<My.CSharp.Namespace.PhoneNumber.WRITER>>(3);
                set => Link(3, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd84cc12089ef7399UL)]
        public class birthdate : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd84cc12089ef7399UL;
            public enum WHICH : ushort
            {
                Nullopt = 0,
                Value = 1,
                undefined = 65535
            }

            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                switch (reader.which)
                {
                    case WHICH.Nullopt:
                        which = reader.which;
                        break;
                    case WHICH.Value:
                        Value = CapnpSerializable.Create<My.CSharp.Namespace.Date>(reader.Value);
                        break;
                }

                applyDefaults();
            }

            private WHICH _which = WHICH.undefined;
            private object? _content;
            public WHICH which
            {
                get => _which;
                set
                {
                    if (value == _which)
                        return;
                    _which = value;
                    switch (value)
                    {
                        case WHICH.Nullopt:
                            break;
                        case WHICH.Value:
                            _content = null;
                            break;
                    }
                }
            }

            public void serialize(WRITER writer)
            {
                writer.which = which;
                switch (which)
                {
                    case WHICH.Nullopt:
                        break;
                    case WHICH.Value:
                        Value?.serialize(writer.Value!);
                        break;
                }
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public My.CSharp.Namespace.Date? Value
            {
                get => _which == WHICH.Value ? (My.CSharp.Namespace.Date? )_content : null;
                set
                {
                    _which = WHICH.Value;
                    _content = value;
                }
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
                public WHICH which => (WHICH)ctx.ReadDataUShort(0U, (ushort)0);
                public My.CSharp.Namespace.Date.READER Value => which == WHICH.Value ? ctx.ReadStruct(1, My.CSharp.Namespace.Date.READER.create) : default;
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                }

                public WHICH which
                {
                    get => (WHICH)this.ReadDataUShort(0U, (ushort)0);
                    set => this.WriteData(0U, (ushort)value, (ushort)0);
                }

                [DisallowNull]
                public My.CSharp.Namespace.Date.WRITER? Value
                {
                    get => which == WHICH.Value ? BuildPointer<My.CSharp.Namespace.Date.WRITER>(1) : default;
                    set => Link(1, value!);
                }
            }
        }
    }
}