using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawn : MonoBehaviour
{
    public Camera cam;

    public Text zcnt;
    int zombiecount;

    const string path = @"D:\Unity_Projects\Reverse_TD\Assets\Scripts\SaveFile.ncr";
    public GameObject prefab;
    public string ct;
    public int gold;
    public int zombiecost;
    public Audio sounds;

    void Start()
    {
        zombiecount = getGoldFromFile();
    }
    void Update()
    {
        Spawn();
        zcnt.text = zombiecount.ToString();

    }
    void Spawn()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePixelPos = Input.mousePosition;

            // Add depth so it can actually be used to cast a ray.
            mousePixelPos.z = 15f;

            // Transform from pixel to world coordinates
            Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mousePixelPos);

            // Remove depth
            mouseWorldPosition.z = 0f;

            // Spawn your prefab
            if (zombiecount > 0)
            {
                zombiecount--;
                updateFile(zombiecount);
                Instantiate(prefab, mouseWorldPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No Money");
                //TODO: No more gold popup
            }
        }
    }
    int getGoldFromFile()
    {
        int val = 0;

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

    void updateFile(int currgold)
    {
        string msg = "Current Gold: " + currgold.ToString();
        File.WriteAllText(path, msg);
    }
    void OnApplicationQuit()
    {
        const string path = @"D:\Unity_Projects\Reverse_TD\Assets\Scripts\SaveFile.ncr";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        Application.Quit();
    }
}
