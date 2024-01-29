using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfMech {  get; private set; }

    public void MechCollected()
    {
        NumberOfMech++;


    }

}
