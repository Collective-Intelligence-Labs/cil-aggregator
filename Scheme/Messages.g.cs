// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: messages.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Example.Protobuf {

  /// <summary>Holder for reflection information generated from messages.proto</summary>
  internal static partial class MessagesReflection {

    #region Descriptor
    /// <summary>File descriptor for messages.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MessagesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5tZXNzYWdlcy5wcm90bxIHRXhhbXBsZSI7CghNaW50SXRlbRIMCgRoYXNo",
            "GAEgASgJEhEKCXNpZ25hdHVyZRgCIAEoDBIOCgZzZW5kZXIYAyABKAkiSwoM",
            "VHJhbnNmZXJJdGVtEgwKBGhhc2gYASABKAkSCgoCdG8YAiABKAkSEQoJc2ln",
            "bmF0dXJlGAMgASgMEg4KBnNlbmRlchgEIAEoCSI4Cg5JdGVtVHJhbnNmZXJl",
            "ZBIMCgRoYXNoGAEgASgJEgwKBGZyb20YAiABKAkSCgoCdG8YAyABKAkiKQoK",
            "SXRlbU1pbnRlZBIMCgRoYXNoGAEgASgJEg0KBW93bmVyGAIgASgJQhOqAhBF",
            "eGFtcGxlLlByb3RvYnVmYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Example.Protobuf.MintItem), global::Example.Protobuf.MintItem.Parser, new[]{ "Hash", "Signature", "Sender" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Example.Protobuf.TransferItem), global::Example.Protobuf.TransferItem.Parser, new[]{ "Hash", "To", "Signature", "Sender" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Example.Protobuf.ItemTransfered), global::Example.Protobuf.ItemTransfered.Parser, new[]{ "Hash", "From", "To" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Example.Protobuf.ItemMinted), global::Example.Protobuf.ItemMinted.Parser, new[]{ "Hash", "Owner" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  internal sealed partial class MintItem : pb::IMessage<MintItem>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MintItem> _parser = new pb::MessageParser<MintItem>(() => new MintItem());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<MintItem> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Example.Protobuf.MessagesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MintItem() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MintItem(MintItem other) : this() {
      hash_ = other.hash_;
      signature_ = other.signature_;
      sender_ = other.sender_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MintItem Clone() {
      return new MintItem(this);
    }

    /// <summary>Field number for the "hash" field.</summary>
    public const int HashFieldNumber = 1;
    private string hash_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Hash {
      get { return hash_; }
      set {
        hash_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "signature" field.</summary>
    public const int SignatureFieldNumber = 2;
    private pb::ByteString signature_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pb::ByteString Signature {
      get { return signature_; }
      set {
        signature_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "sender" field.</summary>
    public const int SenderFieldNumber = 3;
    private string sender_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Sender {
      get { return sender_; }
      set {
        sender_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as MintItem);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(MintItem other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Hash != other.Hash) return false;
      if (Signature != other.Signature) return false;
      if (Sender != other.Sender) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Hash.Length != 0) hash ^= Hash.GetHashCode();
      if (Signature.Length != 0) hash ^= Signature.GetHashCode();
      if (Sender.Length != 0) hash ^= Sender.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (Signature.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Signature);
      }
      if (Sender.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Sender);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (Signature.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Signature);
      }
      if (Sender.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Sender);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Hash.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Hash);
      }
      if (Signature.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Signature);
      }
      if (Sender.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Sender);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(MintItem other) {
      if (other == null) {
        return;
      }
      if (other.Hash.Length != 0) {
        Hash = other.Hash;
      }
      if (other.Signature.Length != 0) {
        Signature = other.Signature;
      }
      if (other.Sender.Length != 0) {
        Sender = other.Sender;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            Signature = input.ReadBytes();
            break;
          }
          case 26: {
            Sender = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            Signature = input.ReadBytes();
            break;
          }
          case 26: {
            Sender = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  internal sealed partial class TransferItem : pb::IMessage<TransferItem>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TransferItem> _parser = new pb::MessageParser<TransferItem>(() => new TransferItem());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TransferItem> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Example.Protobuf.MessagesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransferItem() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransferItem(TransferItem other) : this() {
      hash_ = other.hash_;
      to_ = other.to_;
      signature_ = other.signature_;
      sender_ = other.sender_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransferItem Clone() {
      return new TransferItem(this);
    }

    /// <summary>Field number for the "hash" field.</summary>
    public const int HashFieldNumber = 1;
    private string hash_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Hash {
      get { return hash_; }
      set {
        hash_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "to" field.</summary>
    public const int ToFieldNumber = 2;
    private string to_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string To {
      get { return to_; }
      set {
        to_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "signature" field.</summary>
    public const int SignatureFieldNumber = 3;
    private pb::ByteString signature_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pb::ByteString Signature {
      get { return signature_; }
      set {
        signature_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "sender" field.</summary>
    public const int SenderFieldNumber = 4;
    private string sender_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Sender {
      get { return sender_; }
      set {
        sender_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TransferItem);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TransferItem other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Hash != other.Hash) return false;
      if (To != other.To) return false;
      if (Signature != other.Signature) return false;
      if (Sender != other.Sender) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Hash.Length != 0) hash ^= Hash.GetHashCode();
      if (To.Length != 0) hash ^= To.GetHashCode();
      if (Signature.Length != 0) hash ^= Signature.GetHashCode();
      if (Sender.Length != 0) hash ^= Sender.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (To.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(To);
      }
      if (Signature.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Signature);
      }
      if (Sender.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Sender);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (To.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(To);
      }
      if (Signature.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Signature);
      }
      if (Sender.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Sender);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Hash.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Hash);
      }
      if (To.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(To);
      }
      if (Signature.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Signature);
      }
      if (Sender.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Sender);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TransferItem other) {
      if (other == null) {
        return;
      }
      if (other.Hash.Length != 0) {
        Hash = other.Hash;
      }
      if (other.To.Length != 0) {
        To = other.To;
      }
      if (other.Signature.Length != 0) {
        Signature = other.Signature;
      }
      if (other.Sender.Length != 0) {
        Sender = other.Sender;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            To = input.ReadString();
            break;
          }
          case 26: {
            Signature = input.ReadBytes();
            break;
          }
          case 34: {
            Sender = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            To = input.ReadString();
            break;
          }
          case 26: {
            Signature = input.ReadBytes();
            break;
          }
          case 34: {
            Sender = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  internal sealed partial class ItemTransfered : pb::IMessage<ItemTransfered>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ItemTransfered> _parser = new pb::MessageParser<ItemTransfered>(() => new ItemTransfered());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ItemTransfered> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Example.Protobuf.MessagesReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemTransfered() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemTransfered(ItemTransfered other) : this() {
      hash_ = other.hash_;
      from_ = other.from_;
      to_ = other.to_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemTransfered Clone() {
      return new ItemTransfered(this);
    }

    /// <summary>Field number for the "hash" field.</summary>
    public const int HashFieldNumber = 1;
    private string hash_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Hash {
      get { return hash_; }
      set {
        hash_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "from" field.</summary>
    public const int FromFieldNumber = 2;
    private string from_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string From {
      get { return from_; }
      set {
        from_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "to" field.</summary>
    public const int ToFieldNumber = 3;
    private string to_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string To {
      get { return to_; }
      set {
        to_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ItemTransfered);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ItemTransfered other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Hash != other.Hash) return false;
      if (From != other.From) return false;
      if (To != other.To) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Hash.Length != 0) hash ^= Hash.GetHashCode();
      if (From.Length != 0) hash ^= From.GetHashCode();
      if (To.Length != 0) hash ^= To.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (From.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(From);
      }
      if (To.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(To);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (From.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(From);
      }
      if (To.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(To);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Hash.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Hash);
      }
      if (From.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(From);
      }
      if (To.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(To);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ItemTransfered other) {
      if (other == null) {
        return;
      }
      if (other.Hash.Length != 0) {
        Hash = other.Hash;
      }
      if (other.From.Length != 0) {
        From = other.From;
      }
      if (other.To.Length != 0) {
        To = other.To;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            From = input.ReadString();
            break;
          }
          case 26: {
            To = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            From = input.ReadString();
            break;
          }
          case 26: {
            To = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  internal sealed partial class ItemMinted : pb::IMessage<ItemMinted>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ItemMinted> _parser = new pb::MessageParser<ItemMinted>(() => new ItemMinted());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ItemMinted> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Example.Protobuf.MessagesReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemMinted() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemMinted(ItemMinted other) : this() {
      hash_ = other.hash_;
      owner_ = other.owner_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemMinted Clone() {
      return new ItemMinted(this);
    }

    /// <summary>Field number for the "hash" field.</summary>
    public const int HashFieldNumber = 1;
    private string hash_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Hash {
      get { return hash_; }
      set {
        hash_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "owner" field.</summary>
    public const int OwnerFieldNumber = 2;
    private string owner_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Owner {
      get { return owner_; }
      set {
        owner_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ItemMinted);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ItemMinted other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Hash != other.Hash) return false;
      if (Owner != other.Owner) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Hash.Length != 0) hash ^= Hash.GetHashCode();
      if (Owner.Length != 0) hash ^= Owner.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (Owner.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Owner);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Hash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Hash);
      }
      if (Owner.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Owner);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Hash.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Hash);
      }
      if (Owner.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Owner);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ItemMinted other) {
      if (other == null) {
        return;
      }
      if (other.Hash.Length != 0) {
        Hash = other.Hash;
      }
      if (other.Owner.Length != 0) {
        Owner = other.Owner;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            Owner = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Hash = input.ReadString();
            break;
          }
          case 18: {
            Owner = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
