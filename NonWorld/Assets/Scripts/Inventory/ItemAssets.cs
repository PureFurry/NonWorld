using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }


    public Transform pfItemWorld;

    public Sprite weaponSprite;
    public Sprite medkitSprite;
    public Sprite ammoSprite;
    public Sprite corruptionCoreSprite;
    public Sprite armorSprite;

}
