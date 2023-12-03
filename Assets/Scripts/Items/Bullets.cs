using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Bullets")]
    public class Bullets : Item
    {
        [SerializeField] private int _quantity = 20;

        //Event to notify shootmanager player to update its bullets magazine.
        public delegate void DelegateAddBullets(int add);
        public static DelegateAddBullets OnAddBullets;

        public override void Use()
        {
            OnAddBullets?.Invoke(_quantity);
        }
    }
}