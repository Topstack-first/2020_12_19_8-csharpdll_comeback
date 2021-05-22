// Decompiled with JetBrains decompiler
// Type: GTA.ScriptSettings
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace GTA
{
  public sealed class ScriptSettings
  {
    private string _filename;
    private Dictionary<string, string> _values;

    public static ScriptSettings Load(string filename)
    {
      StreamReader streamReader1 = (StreamReader) null;
      ScriptSettings scriptSettings = new ScriptSettings(filename);
      if (!File.Exists(filename))
        return scriptSettings;
      string str1 = string.Empty;
      streamReader1 = (StreamReader) null;
      StreamReader streamReader2;
      try
      {
        streamReader2 = new StreamReader(filename);
      }
      catch (IOException ex)
      {
        return scriptSettings;
      }
      try
      {
        while (true)
        {
          string str2;
          do
          {
            do
            {
              string str3 = streamReader2.ReadLine();
              if (!object.ReferenceEquals((object) str3, (object) null))
                str2 = str3.Trim();
              else
                goto label_20;
            }
            while (str2.Length == 0 || str2.StartsWith(";") || str2.StartsWith("//"));
            if (str2.StartsWith("[") && str2.Contains("]"))
              str1 = str2.Substring(1, str2.IndexOf(']') - 1).Trim();
          }
          while (!str2.Contains("="));
          int length = str2.IndexOf('=');
          string str4 = str2.Substring(0, length).Trim();
          string str5 = str2.Substring(length + 1).Trim();
          if (str5.Contains("//"))
          {
            char[] chArray = new char[0];
            str5 = str5.Substring(0, str5.IndexOf("//") - 1).TrimEnd(chArray);
          }
          if (str5.StartsWith("\"") && str5.EndsWith("\""))
            str5 = str5.Substring(1, str5.Length - 2);
          string upper = string.Format("[{0}]{1}", (object) str1, (object) str4).ToUpper();
          if (scriptSettings._values.ContainsKey(upper))
          {
            int num = 1;
            while (true)
            {
              upper = string.Format("[{0}]{1}//{2}", (object) str1, (object) str4, (object) num).ToUpper();
              if (scriptSettings._values.ContainsKey(upper))
                ++num;
              else
                break;
            }
          }
          scriptSettings._values.Add(upper, str5);
        }
      }
      finally
      {
        streamReader2.Close();
      }
label_20:
      return scriptSettings;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Save()
    {
      Dictionary<string, List<Tuple<string, string>>> dictionary = new Dictionary<string, List<Tuple<string, string>>>();
      Dictionary<string, string>.Enumerator enumerator1 = this._values.GetEnumerator();
      if (enumerator1.MoveNext())
      {
        do
        {
          KeyValuePair<string, string> current = enumerator1.Current;
          string str = current.Key.Substring(current.Key.IndexOf("]") + 1);
          string key = current.Key.Remove(current.Key.IndexOf("]")).Substring(1);
          if (!dictionary.ContainsKey(key))
            dictionary.Add(key, new List<Tuple<string, string>>()
            {
              new Tuple<string, string>(str, current.Value)
            });
          else
            dictionary[key].Add(new Tuple<string, string>(str, current.Value));
        }
        while (enumerator1.MoveNext());
      }
      StreamWriter text;
      try
      {
        text = File.CreateText(this._filename);
      }
      catch (IOException ex)
      {
        return false;
      }
      try
      {
        bool flag;
        try
        {
          Dictionary<string, List<Tuple<string, string>>>.Enumerator enumerator2 = dictionary.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            KeyValuePair<string, List<Tuple<string, string>>> current1 = enumerator2.Current;
            text.WriteLine("[" + current1.Key + "]");
            List<Tuple<string, string>>.Enumerator enumerator3 = current1.Value.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              Tuple<string, string> current2 = enumerator3.Current;
              text.WriteLine(current2.Item1 + " = " + current2.Item2);
            }
            text.WriteLine();
          }
          goto label_17;
        }
        catch (IOException ex)
        {
          flag = false;
        }
        return flag;
      }
      finally
      {
        text.Close();
      }
label_17:
      return true;
    }

    public string GetValue(string section, string name, string defaultvalue)
    {
      string upper = string.Format("[{0}]{1}", (object) section, (object) name).ToUpper();
      string str = (string) null;
      return this._values.TryGetValue(upper, out str) ? str : defaultvalue;
    }

    public string GetValue(string section, string name) => this.GetValue(section, name, string.Empty);

    public T GetValue<T>(string section, string name, T defaultvalue)
    {
      string str = this.GetValue(section, name, string.Empty);
      try
      {
        return typeof (T).IsEnum ? (T) Enum.Parse(typeof (T), str, true) : (T) Convert.ChangeType((object) str, typeof (T));
      }
      catch (Exception ex)
      {
        return defaultvalue;
      }
    }

    public string[] GetAllValues(string section, string name)
    {
      List<string> stringList = new List<string>();
      string str = this.GetValue(section, name, (string) null);
      if (!object.ReferenceEquals((object) str, (object) null))
      {
        stringList.Add(str);
        int num = 1;
        if (this._values.TryGetValue(string.Format("[{0}]{1}//{2}", (object) section, (object) name, (object) 1).ToUpper(), out str))
        {
          do
          {
            stringList.Add(str);
            ++num;
          }
          while (this._values.TryGetValue(string.Format("[{0}]{1}//{2}", (object) section, (object) name, (object) num).ToUpper(), out str));
        }
      }
      return stringList.ToArray();
    }

    public void SetValue(string section, string name, string value)
    {
      string upper = string.Format("[{0}]{1}", (object) section, (object) name).ToUpper();
      if (!this._values.ContainsKey(upper))
        this._values.Add(upper, value);
      else
        this._values[upper] = value;
    }

    public void SetValue<T>(string section, string name, T value) => this.SetValue(section, name, ((object) value).ToString());

    private ScriptSettings(string filename)
    {
      this._filename = filename;
      this._values = new Dictionary<string, string>();
      // ISSUE: explicit constructor call
      base.__2Ector();
    }
  }
}
