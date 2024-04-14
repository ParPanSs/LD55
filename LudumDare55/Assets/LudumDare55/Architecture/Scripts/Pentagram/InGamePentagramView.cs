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
        [SerializeField] private GameObject cassettePrefab;
        [SerializeField] private Transform[] itemSpawnPoints;
        [SerializeField] private Transform casetteSpawnPoint;
        private List<GameObject> spawnedItems = new();

        // TODO make cassette
        public void DisplaySetup(CreateScriptableObjectOfSetup setup)
        {
            DrawPentagram(setup.setupPentagram);
            CreateItems(setup.setupItems);
        }

        public void ClearSetup()
        {
            ErasePentagram();
            DestroyItems();
        }

        private void ErasePentagram()
        {
            pentagramFigure.sprite = null;
            pentagramDrawing.sprite = null;
        }

        private void DestroyItems()
        {
            foreach (var item in spawnedItems)
            {
                Destroy(item);
            }
            spawnedItems.Clear();
        }
        
        private void DrawPentagram(Pentagram pentagram)
        {
            pentagramFigure.sprite = pentagram.figure;
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

        private void CreateCassete(Cassette cassette)
        {
            var spawnedCassette = Instantiate(cassettePrefab, casetteSpawnPoint);
            
        }
    }
}