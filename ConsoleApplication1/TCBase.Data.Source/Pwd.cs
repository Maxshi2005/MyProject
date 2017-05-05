// Decompiled with JetBrains decompiler
// Type: TCBase.Data.Pwd
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System.Security.Cryptography;
using System.Text;

namespace TCBase.Data
{
  public class Pwd
  {
    internal static string Encrypt(string toEncrypt, string key)
    {
      byte[] bytes1 = Encoding.UTF8.GetBytes(key);
      byte[] bytes2 = Encoding.UTF8.GetBytes(toEncrypt);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Key = bytes1;
      rijndaelManaged.Mode = CipherMode.ECB;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      return Base32String.Encode(rijndaelManaged.CreateEncryptor().TransformFinalBlock(bytes2, 0, bytes2.Length));
    }

    internal static string Decrypt(string toDecrypt, string key)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(key);
      byte[] inputBuffer = Base32String.Decode(toDecrypt);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Key = bytes;
      rijndaelManaged.Mode = CipherMode.ECB;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      return Encoding.UTF8.GetString(rijndaelManaged.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }
  }
}
