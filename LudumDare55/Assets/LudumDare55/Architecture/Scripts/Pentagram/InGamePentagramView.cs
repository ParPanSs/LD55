using System.Collections.Generic;
using UnityEngine;

namespace LudumDare55
{
    public class InGamePentagramView : MonoBehaviour
    {
        [SerializeField] private GameObject cassettePrefab;
        
        [SerializeField] private Transform[] itemSpawnPoints;
        [SerializeField] private Transform cassetteSpawnPoint;
        [SerializeField] private Transform pentagramSpawnPoint;
        
        private readonly List<GameObject> spawnedItems = new();
        private readonly List<GameObject> spawnedPentagramParts = new();
        private GameObject _spawnedCassette;
        private Animator _animator;
        
        public void DisplaySetup(CreateScriptableObjectOfSetup setup)
        {
            CreatePentagram(setup.setupCataloguePentagram);
            CreateItems(setup.setupItems);
            CreateCassette(setup.setupCassette);
        }

        public void ClearSetup()
        {
            DestroyPentagram();
            DestroyItems();
            DestroyCassette();
        }

        private void DestroyPentagram()
        {
            foreach (var part in spawnedPentagramParts)
            {
                DestroyWithDelay(part, 1f);
            }
            spawnedPentagramParts.Clear();
        }

        private void DestroyItems()
        {
            foreach (var item in spawnedItems)
            {
                DestroyWithDelay(item, 1f);
            }
            spawnedItems.Clear();
        }

        private void DestroyCassette()
        {
            DestroyWithDelay(_spawnedCassette, 1f);
        }

        private void DestroyWithDelay(GameObject gameObject, float time)
        {
            _animator = gameObject.GetComponent<Animator>();
            _animator.SetTrigger("Dissapear");
            Destroy(gameObject, time);
        }
        
        private void CreatePentagram(InGamePentagram pentagram)
        {
            if (pentagram.drawing == null) return;
            spawnedPentagramParts.Add(Instantiate(pentagram.drawing, pentagramSpawnPoint));
            
            if (pentagram.figure == null) return;
            spawnedPentagramParts.Add(Instantiate(pentagram.figure, pentagramSpawnPoint));
        }

        private void CreateItems(InGameItem[] items)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (items[i].itemObject == null) continue;
                
                var itemObject = Instantiate(items[i].itemObject, itemSpawnPoints[i]);
                spawnedItems.Add(itemObject);
            }
        }

        private void CreateCassette(InGameCassette cassette)
        {
            if (cassette.cassetteAudio == null) return;
            
            var cassetteObject = Instantiate(cassettePrefab, cassetteSpawnPoint);
            cassetteObject.GetComponent<InGameCassetteObject>().Construct(cassette.cassetteAudio);
            _spawnedCassette = cassetteObject;
        }
    }
}