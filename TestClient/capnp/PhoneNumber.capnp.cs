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
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfadcbb3b3073b440UL)]
    public class PhoneNumber : ICapnpSerializable
    {
        public const UInt64 typeId = 0xfadcbb3b3073b440UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Number = reader.Number;
            Type = reader.Type;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Number = Number;
            writer.Type = Type;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string? Number
        {
            get;
            set;
        }

        public My.CSharp.Namespace.PhoneNumberType Type
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
            public string? Number => ctx.ReadText(0, null);
            public My.CSharp.Namespace.PhoneNumberType Type => (My.CSharp.Namespace.PhoneNumberType)ctx.ReadDataUShort(0UL, (ushort)0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public string? Number
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public My.CSharp.Namespace.PhoneNumberType Type
            {
                get => (My.CSharp.Namespace.PhoneNumberType)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }
        }
    }
}