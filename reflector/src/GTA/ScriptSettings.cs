namespace GTA
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;

    public sealed class ScriptSettings
    {
        private string _filename;
        private Dictionary<string, string> _values;

        private ScriptSettings(string filename)
        {
            this._filename = filename;
            this._values = new Dictionary<string, string>();
        }

        public string[] GetAllValues(string section, string name)
        {
            string objA = null;
            List<string> list = new List<string>();
            objA = this.GetValue(section, name, null);
            if (!ReferenceEquals(objA, null))
            {
                list.Add(objA);
                int num = 1;
                if (this._values.TryGetValue($"[{section}]{name}//{1}".ToUpper(), out objA))
                {
                    do
                    {
                        list.Add(objA);
                        num++;
                    }
                    while (this._values.TryGetValue($"[{section}]{name}//{num}".ToUpper(), out objA));
                }
            }
            return list.ToArray();
        }

        public string GetValue(string section, string name) => 
            this.GetValue(section, name, string.Empty);

        public string GetValue(string section, string name, string defaultvalue)
        {
            string str = null;
            string key = $"[{section}]{name}".ToUpper();
            str = null;
            return (!this._values.TryGetValue(key, out str) ? defaultvalue : str);
        }

        public T GetValue<T>(string section, string name, T defaultvalue)
        {
            T local;
            string str = this.GetValue(section, name, string.Empty);
            try
            {
                local = !typeof(T).IsEnum ? ((T) Convert.ChangeType(str, typeof(T))) : ((T) Enum.Parse(typeof(T), str, true));
            }
            catch (Exception)
            {
                return defaultvalue;
            }
            return local;
        }

        public static ScriptSettings Load(string filename)
        {
            StreamReader reader = null;
            ScriptSettings settings = new ScriptSettings(filename);
            if (!File.Exists(filename))
            {
                return settings;
            }
            string str4 = string.Empty;
            reader = null;
            try
            {
                reader = new StreamReader(filename);
            }
            catch (IOException)
            {
                return settings;
            }
            while (true)
            {
                try
                {
                    while (true)
                    {
                        string objA = reader.ReadLine();
                        if (ReferenceEquals(objA, null))
                        {
                            return settings;
                        }
                        else
                        {
                            objA = objA.Trim();
                            if ((objA.Length != 0) && (!objA.StartsWith(";") && !objA.StartsWith("//")))
                            {
                                if (objA.StartsWith("[") && objA.Contains("]"))
                                {
                                    str4 = objA.Substring(1, objA.IndexOf(']') - 1).Trim();
                                }
                                else if (objA.Contains("="))
                                {
                                    int index = objA.IndexOf('=');
                                    string str5 = objA.Substring(0, index).Trim();
                                    string str2 = objA.Substring(index + 1).Trim();
                                    if (str2.Contains("//"))
                                    {
                                        char[] trimChars = new char[0];
                                        str2 = str2.Substring(0, str2.IndexOf("//") - 1).TrimEnd(trimChars);
                                    }
                                    if (str2.StartsWith("\"") && str2.EndsWith("\""))
                                    {
                                        str2 = str2.Substring(1, str2.Length - 2);
                                    }
                                    string key = $"[{str4}]{str5}".ToUpper();
                                    if (settings._values.ContainsKey(key))
                                    {
                                        int num = 1;
                                        while (true)
                                        {
                                            key = $"[{str4}]{str5}//{num}".ToUpper();
                                            if (!settings._values.ContainsKey(key))
                                            {
                                                break;
                                            }
                                            num++;
                                        }
                                    }
                                    settings._values.Add(key, str2);
                                }
                            }
                        }
                        break;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public bool Save()
        {
            Dictionary<string, List<Tuple<string, string>>> dictionary = new Dictionary<string, List<Tuple<string, string>>>();
            Dictionary<string, string>.Enumerator enumerator3 = this._values.GetEnumerator();
            if (enumerator3.MoveNext())
            {
                do
                {
                    KeyValuePair<string, string> current = enumerator3.Current;
                    string str2 = current.Key.Substring(current.Key.IndexOf("]") + 1);
                    string key = current.Key.Remove(current.Key.IndexOf("]")).Substring(1);
                    if (dictionary.ContainsKey(key))
                    {
                        dictionary[key].Add(new Tuple<string, string>(str2, current.Value));
                    }
                    else
                    {
                        List<Tuple<string, string>> list = new List<Tuple<string, string>> {
                            new Tuple<string, string>(str2, current.Value)
                        };
                        dictionary.Add(key, list);
                    }
                }
                while (enumerator3.MoveNext());
            }
            StreamWriter writer = null;
            try
            {
                writer = File.CreateText(this._filename);
            }
            catch (IOException)
            {
                return false;
            }
            try
            {
                byte num;
                bool flag;
                try
                {
                    Dictionary<string, List<Tuple<string, string>>>.Enumerator enumerator2 = dictionary.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        KeyValuePair<string, List<Tuple<string, string>>> current = enumerator2.Current;
                        writer.WriteLine("[" + current.Key + "]");
                        List<Tuple<string, string>>.Enumerator enumerator = current.Value.GetEnumerator();
                        while (true)
                        {
                            if (!enumerator.MoveNext())
                            {
                                writer.WriteLine();
                                break;
                            }
                            Tuple<string, string> tuple = enumerator.Current;
                            writer.WriteLine(tuple.Item1 + " = " + tuple.Item2);
                        }
                    }
                }
                catch (IOException)
                {
                    flag = false;
                    goto TR_0004;
                }
                goto TR_000B;
            TR_0004:
                num = (byte) flag;
                return (bool) num;
            }
            finally
            {
                writer.Close();
            }
        TR_000B:
            return true;
        }

        public void SetValue(string section, string name, string value)
        {
            string key = $"[{section}]{name}".ToUpper();
            if (!this._values.ContainsKey(key))
            {
                this._values.Add(key, value);
            }
            else
            {
                this._values[key] = value;
            }
        }

        public void SetValue<T>(string section, string name, T value)
        {
            this.SetValue(section, name, value.ToString());
        }
    }
}

