// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SocketGameProtocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketGameProtocol {

  /// <summary>Holder for reflection information generated from SocketGameProtocol.proto</summary>
  public static partial class SocketGameProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for SocketGameProtocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SocketGameProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhTb2NrZXRHYW1lUHJvdG9jb2wucHJvdG8SElNvY2tldEdhbWVQcm90b2Nv",
            "bCKoAQoITWFpblBhY2sSNAoLcmVxdWVzdGNvZGUYASABKA4yHy5Tb2NrZXRH",
            "YW1lUHJvdG9jb2wuUmVxdWVzdENvZGUSMgoKYWN0aW9uY29kZRgCIAEoDjIe",
            "LlNvY2tldEdhbWVQcm90b2NvbC5BY3Rpb25Db2RlEjIKCnJldHVybmNvZGUY",
            "AyABKA4yHi5Tb2NrZXRHYW1lUHJvdG9jb2wuUmV0dXJuQ29kZSoeCgtSZXF1",
            "ZXN0Q29kZRIPCgtSZXF1ZXN0Tm9uZRAAKhwKCkFjdGlvbkNvZGUSDgoKQWN0",
            "aW9uTm9uZRAAKhwKClJldHVybkNvZGUSDgoKUmV0dXJuTm9uZRAAYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::SocketGameProtocol.RequestCode), typeof(global::SocketGameProtocol.ActionCode), typeof(global::SocketGameProtocol.ReturnCode), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketGameProtocol.MainPack), global::SocketGameProtocol.MainPack.Parser, new[]{ "Requestcode", "Actioncode", "Returncode" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  ///ö������
  /// </summary>
  public enum RequestCode {
    [pbr::OriginalName("RequestNone")] RequestNone = 0,
  }

  public enum ActionCode {
    [pbr::OriginalName("ActionNone")] ActionNone = 0,
  }

  public enum ReturnCode {
    [pbr::OriginalName("ReturnNone")] ReturnNone = 0,
  }

  #endregion

  #region Messages
  public sealed partial class MainPack : pb::IMessage<MainPack> {
    private static readonly pb::MessageParser<MainPack> _parser = new pb::MessageParser<MainPack>(() => new MainPack());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MainPack> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketGameProtocol.SocketGameProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MainPack() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MainPack(MainPack other) : this() {
      requestcode_ = other.requestcode_;
      actioncode_ = other.actioncode_;
      returncode_ = other.returncode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MainPack Clone() {
      return new MainPack(this);
    }

    /// <summary>Field number for the "requestcode" field.</summary>
    public const int RequestcodeFieldNumber = 1;
    private global::SocketGameProtocol.RequestCode requestcode_ = global::SocketGameProtocol.RequestCode.RequestNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.RequestCode Requestcode {
      get { return requestcode_; }
      set {
        requestcode_ = value;
      }
    }

    /// <summary>Field number for the "actioncode" field.</summary>
    public const int ActioncodeFieldNumber = 2;
    private global::SocketGameProtocol.ActionCode actioncode_ = global::SocketGameProtocol.ActionCode.ActionNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.ActionCode Actioncode {
      get { return actioncode_; }
      set {
        actioncode_ = value;
      }
    }

    /// <summary>Field number for the "returncode" field.</summary>
    public const int ReturncodeFieldNumber = 3;
    private global::SocketGameProtocol.ReturnCode returncode_ = global::SocketGameProtocol.ReturnCode.ReturnNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.ReturnCode Returncode {
      get { return returncode_; }
      set {
        returncode_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MainPack);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MainPack other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Requestcode != other.Requestcode) return false;
      if (Actioncode != other.Actioncode) return false;
      if (Returncode != other.Returncode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) hash ^= Requestcode.GetHashCode();
      if (Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) hash ^= Actioncode.GetHashCode();
      if (Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) hash ^= Returncode.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Requestcode);
      }
      if (Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Actioncode);
      }
      if (Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) {
        output.WriteRawTag(24);
        output.WriteEnum((int) Returncode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Requestcode);
      }
      if (Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Actioncode);
      }
      if (Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Returncode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MainPack other) {
      if (other == null) {
        return;
      }
      if (other.Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) {
        Requestcode = other.Requestcode;
      }
      if (other.Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) {
        Actioncode = other.Actioncode;
      }
      if (other.Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) {
        Returncode = other.Returncode;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Requestcode = (global::SocketGameProtocol.RequestCode) input.ReadEnum();
            break;
          }
          case 16: {
            Actioncode = (global::SocketGameProtocol.ActionCode) input.ReadEnum();
            break;
          }
          case 24: {
            Returncode = (global::SocketGameProtocol.ReturnCode) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
