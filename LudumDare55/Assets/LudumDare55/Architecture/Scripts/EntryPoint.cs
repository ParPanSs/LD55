using UnityEngine;

namespace LudumDare55
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CatalogueController catalogueController;
        [SerializeField] private InGamePentagramController inGamePentagramController;
        [SerializeField] private TimerController timerController;
        
        [SerializeField] private RoundManager roundManager;
        [SerializeField] private CatalogueBookmark[] bookmarks;
        
        private void Start()
        {
            roundManager.Construct(inGamePentagramController, timerController);
            
            foreach (var bookmark in bookmarks)
            {
                bookmark.Construct(catalogueController);
            }
        }
    }
}