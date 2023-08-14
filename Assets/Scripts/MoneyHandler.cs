using System;
using System.IO;
using System.Text;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int getGoldFromFile()
    {
        int val = 0;
        const string path = "SaveFile.ncr";

        if (File.Exists(path))
        {

            string readtext = File.ReadAllText(path);

            val = Int32.Parse(readtext.Substring(readtext.Length - 2));
            return val;
        }
        else
        {
            val = 40;
            File.WriteAllText(path, "Current Gold: 40");
            return val;
        }
    }

    void updateFile()
    {

    }
    void Start()
    {
        getGoldFromFile();
    }

    void Update()
    {

    }
}
