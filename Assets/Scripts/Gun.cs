using UnityEngine;

[CreateAssetMenu(menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public bool fullAuto;
    public int magazineSize;

    [Range(0, 1)]
    public float fireRate;

    public Sprite droppedSprite, pickedSprite;
}
