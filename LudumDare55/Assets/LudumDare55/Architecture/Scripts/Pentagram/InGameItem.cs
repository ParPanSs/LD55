using UnityEngine;

namespace LudumDare55
{
    public class InGameItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer itemSpriteRenderer;

        public void Construct(Item item)
        {
            itemSpriteRenderer.sprite = item.catalogueItemSprite;
        }
    }
}