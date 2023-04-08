using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    #region Variables
    // Private
    [SerializeField] private float maxSpeed = 1.0f;
    [SerializeField] private float jumpPower = 1.0f;
    [SerializeField] private Text coinsText;
    private Vector2 healthBarOrigSize;
    private int maxHealth = 100;

    // Public
    
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public Image inventoryItemImage;
    public Sprite keySprite;
    public Sprite keyGemSprite;
    public Sprite inventoryItemBlank;

    public int health;
    public int ammo;
    public int coinsCollected;
    public Image healthBar;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
        //AddInventoryItem("key2",keyGemSprite);
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        
        // If the player presses "jump", Set the velocity to a jump power value
        if(Input.GetButtonDown("Jump") && grounded)
        { 
        velocity.y = jumpPower;
        }
    }

    // Update UI elements
    public void UpdateUI()
    {
        coinsText.text = "Coins " + coinsCollected.ToString();
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), healthBar.rectTransform.sizeDelta.y);
    }

    // Add Inventory items
    public void AddInventoryItem(string inventoryName,Sprite image)
    {
        inventory.Add(inventoryName, image);
        inventoryItemImage.sprite = inventory[inventoryName];
    }

    public void RemoveInventoryItem(string inventoryName)
    {
        inventory.Remove(inventoryName);
        inventoryItemImage.sprite = inventoryItemBlank;
    }
}
