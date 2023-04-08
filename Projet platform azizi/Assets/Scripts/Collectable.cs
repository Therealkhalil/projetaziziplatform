using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    #region Variables
        NewPlayer newPlayerScript;

        enum ItemType {Coin,Health,Ammo,InventoryItem} 
        [SerializeField] private ItemType item;

        [SerializeField] private string inventoryStringName;
        [SerializeField] private Sprite inventorySprite;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        newPlayerScript = GameObject.Find("Player").GetComponent<NewPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    // If player touching me, print "Collect" in the console
    if(collision.gameObject.name == "Player")
      {
       if (item == ItemType.Coin)
         {
           newPlayerScript.coinsCollected++;
         }
       else if (item == ItemType.Health)
         {
                if(newPlayerScript.health <= 100)
                newPlayerScript.health +=10 ;
         }
       else if (item == ItemType.Ammo)
         {
                
         }
       else if (item == ItemType.InventoryItem)
         {
          newPlayerScript.AddInventoryItem(inventoryStringName, inventorySprite);
         }
       else
         {
              
         }

       newPlayerScript.UpdateUI();
       Destroy(gameObject);
      }
    }
}




