using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO ItemSO;

    private void Start() {
        GetComponent<SpriteRenderer>().sprite = ItemSO.itemSprite;
    }

    public Item GetItem(){
        return this;
    }
    public void DestroySelf(){
        Destroy(this.gameObject);
    }
}
