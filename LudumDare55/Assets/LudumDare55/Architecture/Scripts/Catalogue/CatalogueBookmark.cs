using UnityEngine;

namespace LudumDare55
{
    public class CatalogueBookmark : MonoBehaviour
    {
        [SerializeField] private string demonID;
        private CatalogueController _catalogueController = new();
        private BookmarkEvent bookmarkEvent = new();

        private void Start()
        {
            bookmarkEvent.OnBookmarkPressed += _catalogueController.ChangeDemon;
        }
        
        private void OnMouseDown()
        {
            bookmarkEvent.InvokeEvent(demonID);
        }

        private void OnDestroy()
        {
            bookmarkEvent.OnBookmarkPressed -= _catalogueController.ChangeDemon;
        }
    }
}
