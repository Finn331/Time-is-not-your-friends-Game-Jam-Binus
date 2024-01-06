using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IInventoryItem 
{
    public string Name
    {
        get
        {
            return "Axe";
        }
    }
    
    public Sprite _Image = null;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    public void OnPickup()
    {
        throw new System.NotImplementedException();
    }
}
