using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(20);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, 
                (int)transform.position.y, 0);

            if(GameManager.instance.tileManager.IsInteractable(position)) 
            {
                Debug.Log("Tile is interactable");
                GameManager.instance.tileManager.SetInteracted(position);
            }
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle*3.5f;

       Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, 
           Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * .4f, ForceMode2D.Impulse);
    }
}
