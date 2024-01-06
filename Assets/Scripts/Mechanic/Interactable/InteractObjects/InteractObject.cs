using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
   private bool Interacted = false;
   public GameObject interactButton;
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);

    void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
        foreach(var o in z_CollidedObjects)
        {
            OnCollided(o.gameObject);
            
        }
    }

    private void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Collided With " + collidedObject.name);
        if (collidedObject.tag == "Player")
        {
            interactButton.SetActive(true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }


    public void OnInteract()
    {
        if (!Interacted)
        {
            Interacted = true;
            Debug.Log("INTERACT WITH " + name);
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(false);
        }
    }
}
