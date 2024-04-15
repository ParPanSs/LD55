using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LudumDare55
{
    public class InGamePentagramView : MonoBehaviour
    {
        [SerializeField] private GameObject cassettePrefab;
        
        [SerializeField] private Transform[] itemSpawnPoints;
        [SerializeField] private Transform cassetteSpawnPoint;
        [SerializeField] private Transform pentagramFigureSpawnPoint;
        [SerializeField] private Transform[] pentagramDrawingSpawnPoints;
        [SerializeField] private Transform demonSpawnPoint;
        
        private readonly List<GameObject> spawnedItems = new();
        private readonly List<GameObject> spawnedPentagramParts = new();
        private GameObject _spawnedCassette;
        private GameObject _spawnedDemon;
        private GameObject _demonPrefab;
        private Animator _animator;
        
        public void DisplaySetup(CreateScriptableObjectOfSetup setup)
        {
            CreatePentagram(setup.setupCataloguePentagram);
            CreateItems(setup.setupItems);
            CreateCassette(setup.setupCassette);
            _demonPrefab = setup.demonObject;
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
            Debug.Log(gameObject.name);
            _animator.SetTrigger("Dissapear");
            if (_spawnedDemon == null) CreateDemon();
            Destroy(gameObject, time);
        }

        private void CreatePentagram(InGamePentagram pentagram)
        {
            if (pentagram.drawings.Length == 0) return;
            for (var i = 0; i < pentagram.drawings.Length; i++)
            {
                spawnedPentagramParts.Add(Instantiate(pentagram.drawings[i], pentagramDrawingSpawnPoints[i]));
            }

            if (pentagram.figure == null) return;
            spawnedPentagramParts.Add(Instantiate(pentagram.figure, pentagramFigureSpawnPoint));
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

        private void CreateDemon()
        {
            _spawnedDemon = Instantiate(_demonPrefab, demonSpawnPoint);
            DestroyWithDelay(_spawnedDemon, 5f);
        }
    }
}