using System;
using UnityEngine;

public class SimpleLibrarian : Player
{
    private void Start()
    {
        weapons.Add(new SimpleHands());
    }
}
