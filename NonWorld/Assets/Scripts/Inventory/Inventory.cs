using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    List<Item> itemList;
    GameObject loadoutPanel;
    [SerializeField]bool isInGame;
    public Item headItem;
    public Item bodyItem;
    public WeaponSO weaponItem;
    [SerializeField] Image headImage;
    [SerializeField] Image bodyImage;
    [SerializeField] Image weaponImage;

    
    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start() {
        loadoutPanel = this.gameObject;
        if (isInGame)
        {
            loadoutPanel.SetActive(false);
        }
        else loadoutPanel.SetActive(true);
    }
    private void Update() {
        if (isInGame)
        {
            if (Input.GetKey(KeyCode.I))
            {
                if (loadoutPanel.activeSelf == false)
                {
                    loadoutPanel.SetActive(true);
                }
                else loadoutPanel.SetActive(false);    
            }
        }
        else loadoutPanel.SetActive(true);
        
    }
    
    
    public void SetHeadItem(Item _item){
        headItem = _item;
        headImage.sprite = _item.ItemSO.itemSprite;
    }

    public void SetBodyItem(Item _item){
        bodyItem = _item;
        bodyImage.sprite = _item.ItemSO.itemSprite;
    }
    public void SetWeapon(WeaponSO _weapon){
        weaponItem = _weapon;
        Shooting.Instance.LoadGunData(_weapon);
        weaponImage.sprite = _weapon.weaponSprite;
    }

    public void AddItemToList(Item item){
        itemList.Add(item);
    }
    public List<Item> GetItemList(){
        return itemList;
    }
}
