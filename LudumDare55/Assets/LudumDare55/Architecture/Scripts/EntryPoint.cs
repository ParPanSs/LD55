using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace LudumDare55
{
    public class EntryPoint : MonoBehaviour
    {
        private CatalogueController catalogueController;
        [Header("Catalogue")]
        [SerializeField] private CatalogueView catalogueView;
        [SerializeField] private CatalogueBookmark[] bookmarks;

        private InGamePentagramController inGamePentagramController;
        [Header("Pentagram")]
        [SerializeField] private InGamePentagramView inGamePentagramView;

        private TimerController timerController;
        [Header("Timer")]
        [SerializeField] private TimerView timerView;

        private RoundStarter roundStarter;
        private RoundEnder roundEnder;
        [Header("Round")]
        [SerializeField] private float dayTime;
        [SerializeField] private List<CreateScriptableObjectOfSetup> daySetups;
        [SerializeField] private TextMeshPro roundsLeftText;
        [SerializeField] private Bell bell;
        [SerializeField] private SceneTransition sceneTransition;
        
        private void Awake()
        {
            PlayerPrefs.DeleteKey("RequiredAmount");
            PlayerPrefs.Save();
            catalogueController = new CatalogueController();
            inGamePentagramController = new InGamePentagramController();
            timerController = new TimerController();
            roundStarter = new RoundStarter();
            roundEnder = new RoundEnder();
            
            catalogueController.Construct(catalogueView);
            foreach (var bookmark in bookmarks) { bookmark.Construct(catalogueController); }
            
            inGamePentagramController.Construct(inGamePentagramView);
            
            roundStarter.Construct(inGamePentagramController, daySetups);
            roundEnder.Construct(roundStarter,
                inGamePentagramController,
                timerController,
                sceneTransition,
                bell.GetComponent<PlayableDirector>(),
                roundsLeftText);
            
            bell.Construct(catalogueController, roundEnder);
            timerController.Construct(roundEnder, timerView);

            roundsLeftText.text = daySetups.Count.ToString();
            PlayerPrefs.SetInt("RequiredAmount", daySetups.Count);
            StartCoroutine(timerController.DecrementTimeCoroutine(dayTime));
        }
    }
}