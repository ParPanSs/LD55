using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace LudumDare55
{
    public class EntryPoint : MonoBehaviour
    {
        private readonly CatalogueController catalogueController = new();
        [Header("Catalogue")]
        [SerializeField] private CatalogueView catalogueView;
        [SerializeField] private CatalogueBookmark[] bookmarks;
        
        private readonly InGamePentagramController inGamePentagramController = new();
        [Header("Pentagram")]
        [SerializeField] private InGamePentagramView inGamePentagramView;
        
        private readonly TimerController timerController = new();
        [Header("Timer")]
        [SerializeField] private TimerView timerView;
        
        private readonly RoundStarter roundStarter = new();
        private readonly RoundEnder roundEnder = new();
        [Header("Round")]
        [SerializeField] private float dayTime;
        [SerializeField] private List<CreateScriptableObjectOfSetup> daySetups;
        [SerializeField] private TextMeshPro roundsLeftText;
        [SerializeField] private Bell bell;
        [SerializeField] private SceneTransition sceneTransition;
        
        private void Awake()
        {
            catalogueController.Construct(catalogueView);
            foreach (var bookmark in bookmarks) { bookmark.Construct(catalogueController); }
            
            inGamePentagramController.Construct(inGamePentagramView);
            
            roundStarter.Construct(inGamePentagramController, daySetups, roundsLeftText);
            roundEnder.Construct(roundStarter, inGamePentagramController, timerController, sceneTransition, bell.GetComponent<PlayableDirector>());
            bell.Construct(catalogueController, roundEnder);
            timerController.Construct(roundEnder, timerView);

            roundsLeftText.text = daySetups.Count.ToString();
            
            StartCoroutine(timerController.DecrementTimeCoroutine(dayTime));
        }
    }
}