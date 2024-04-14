using System.Collections.Generic;
using UnityEngine;

namespace LudumDare55
{
    public class InGamePentagramView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer pentagramFigure;
        [SerializeField] private SpriteRenderer pentagramBorder;
        [SerializeField] private SpriteRenderer pentagramDrawing;

        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Transform[] itemSpawnPoints;
        private List<GameObject> spawnedItems = new();

        // TODO make cassette
        public void DisplaySetup(CreateScriptableObjectOfSetup setup)
        {
            DrawPentagram(setup.setupPentagram);
            CreateItems(setup.setupItems);
        }
        
        private void DrawPentagram(Pentagram pentagram)
        {
            pentagramFigure.sprite = pentagram.figure;
            pentagramBorder.sprite = pentagram.border;
            pentagramDrawing.sprite = pentagram.drawing;
        }

        private void CreateItems(Item[] items)
        {
            for (var i = 0; i < items.Length; i++)
            {
                var itemObject = Instantiate(itemPrefab, itemSpawnPoints[i]);
                spawnedItems.Add(itemObject);
                itemObject.GetComponent<InGameItem>().Construct(items[i]);
            } 
        }
    }
}