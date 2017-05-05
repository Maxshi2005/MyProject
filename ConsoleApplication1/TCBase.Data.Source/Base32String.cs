// Decompiled with JetBrains decompiler
// Type: TCBase.Data.Base32String
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;

namespace TCBase.Data
{
  public static class Base32String
  {
    private const byte BitsInBlock = 5;
    private const byte BitsInByte = 8;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
    private const char Padding = '=';

    public static string Encode(byte[] input)
    {
      if (input.Length == 0)
        return string.Empty;
      char[] chArray = new char[(int) Decimal.Ceiling((Decimal) input.Length / new Decimal(5)) * 8];
      int num1 = 0;
      byte num2 = 0;
      byte num3 = 5;
      foreach (byte num4 in input)
      {
        byte num5 = (byte) ((uint) num2 | (uint) num4 >> 8 - (int) num3);
        chArray[num1++] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"[(int) num5];
        if ((int) num3 < 3)
        {
          byte num6 = (byte) ((int) num4 >> 3 - (int) num3 & 31);
          chArray[num1++] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"[(int) num6];
          num3 += (byte) 5;
        }
        num3 -= (byte) 3;
        num2 = (byte) ((int) num4 << (int) num3 & 31);
      }
      if (num1 != chArray.Length)
        chArray[num1++] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"[(int) num2];
      while (num1 < chArray.Length)
        chArray[num1++] = '=';
      return new string(chArray).TrimEnd('=');
    }

    public static byte[] Decode(string input)
    {
      if (string.IsNullOrEmpty(input))
        return new byte[0];
      input = input.TrimEnd('=').ToUpperInvariant();
      byte[] numArray = new byte[input.Length * 5 / 8];
      int num1 = 0;
      byte num2 = 0;
      byte num3 = 8;
      foreach (char ch in input.ToCharArray())
      {
        int num4 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".IndexOf(ch);
        if ((int) num3 > 5)
        {
          int num5 = num4 << (int) num3 - 5;
          num2 |= (byte) num5;
          num3 -= (byte) 5;
        }
        else
        {
          int num5 = num4 >> 5 - (int) num3;
          byte num6 = (byte) ((uint) num2 | (uint) num5);
          numArray[num1++] = num6;
          num2 = (byte) (num4 << 3 + (int) num3);
          num3 += (byte) 3;
        }
      }
      return numArray;
    }
  }
}
