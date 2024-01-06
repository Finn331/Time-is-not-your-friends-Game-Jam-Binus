using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour
{

    //public GameObject winObject;  // GameObject yang diaktifkan saat menang
    //public GameObject loseObject; // GameObject yang dihapus saat kalah
    [Header ("Health System Script")]
    public HealthSystem healthSystem;

    [Header ("Interact Button")]
    public GameObject interactButton;

    private bool canJudi = false;
    private Shelf shelf;

    void Start()
    {
        
        shelf = gameObject.GetComponent<Shelf>();
    }

    private void Update()
    {
        if (canJudi && Input.GetKeyDown(KeyCode.E))
        {
            RunRNG();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(true);
            canJudi = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            interactButton.SetActive (false);
            canJudi= false;
        }
    }

    void RunRNG()
    {
        // Gunakan nilai random antara 0 dan 1 untuk menentukan kemenangan atau kekalahan
        float randomValue = Random.value;
        Debug.Log("RunRNG function is executing.");
        // Jika nilai random kurang dari 0.5, maka menang
        if (randomValue < 0.5f)
        {
            Debug.Log("Menang!");
            ActivateWinObject();
        }
        // Jika nilai random lebih besar atau sama dengan 0.5, maka kalah
        else
        {
            Debug.Log("Kalah!");
            DestroyLoseObject();
        }
    }

    void ActivateWinObject()
    {
        healthSystem.TakeHeal(10);
        shelf.enabled = false;
        interactButton.SetActive(false);
    }

    void DestroyLoseObject()
    {
        shelf.enabled = false;
        interactButton.SetActive(false);
    }
}
