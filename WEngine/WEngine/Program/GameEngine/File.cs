using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WEngine
{
    public static class File
    {
        //判断文件目录是否存在
        public static bool Exist(string path)
        {
            if (Directory.Exists(path)) return true;
            return false;
        }
        //判断文件是否存在
        public static bool isExistFile(string path)
        {
            if (System.IO.File.Exists(path)) return true;
            return false;
        }
        public static void Save(string filepath, byte[] data)
        {
            FileStream fs = new FileStream(filepath, FileMode.Create);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        public static byte[] Load(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, data.Length);
            fs.Close();
            return data;
        }

        public static void Save<T>(string filepath, T cls)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filepath, FileMode.Create);
            bf.Serialize(fs, cls);
            fs.Close();
        }

        public static T Load<T>(string filepath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            T target;

            target = (T)bf.Deserialize(fs);
            return target;
            
        }
    }
}
