using UnityEngine;

namespace Items
{
    public class GrabItems : MonoBehaviour
    {
        [SerializeField] private Item _item;

        private bool _blockInteraction = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //block posible multiple entries.
            if (_blockInteraction) return;

            if (collision.CompareTag("Player"))
            {
                _blockInteraction = true;
                _item.Use();

                gameObject.SetActive(false);
            }
        }
    }
}