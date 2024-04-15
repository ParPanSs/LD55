using UnityEngine;

namespace LudumDare55
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CatalogueController catalogueController;
        [SerializeField] private InGamePentagramController inGamePentagramController;
        [SerializeField] private TimerController timerController;
        [SerializeField] private RoundStarter roundStarter;
        [SerializeField] private RoundEnder roundEnder;
        [SerializeField] private CatalogueBookmark[] bookmarks;
        [SerializeField] private Bell bell;
        [SerializeField] private SceneTransition sceneTransition;
        [SerializeField] private float dayTime;
        
        private void Awake()
        {
            StartCoroutine(timerController.DecrementTimeCoroutine(dayTime));
            catalogueController.Construct();
            roundStarter.Construct(inGamePentagramController);
            roundEnder.Construct(roundStarter, inGamePentagramController, timerController, sceneTransition);
            foreach (var bookmark in bookmarks)
            {
                bookmark.Construct(catalogueController);
            }
            timerController.Construct(roundEnder);
            bell.Construct(catalogueController, roundEnder);
        }
    }
}