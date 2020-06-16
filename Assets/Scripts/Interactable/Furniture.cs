using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : Interactable
{
    protected override void OnInteract()
    {
        Debug.Log(gameObject.name + " test");
    }
}
