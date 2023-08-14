using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public int Gold;
    public int Zombie;
    void Start()
    {
        Gold = 100;
    }

    public void Purchase()
    {
        if (Gold > 5)
        {
            Gold -= 5;
            Zombie++;
        }
    }


}
