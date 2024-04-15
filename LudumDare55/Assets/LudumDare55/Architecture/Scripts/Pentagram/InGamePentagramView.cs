using System.Collections.Generic;
using UnityEngine;

namespace LudumDare55
{
    public class InGamePentagramView : MonoBehaviour
    {
        [SerializeField] private GameObject cassettePrefab;
        
        [SerializeField] private Transform[] itemSpawnPoints;
        [SerializeField] private Transform cassetteSpawnPoint;
        [SerializeField] private SpriteRenderer pentagramFigureSpriteRenderer;
        [SerializeField] private SpriteRenderer[] pentagramDrawingSpriteRenderers;
        [SerializeField] private Transform demonSpawnPoint;
        
        private readonly List<GameObject> spawnedItems = new();
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
            foreach (var part in pentagramDrawingSpriteRenderers)
            {
                part.sprite = null;
            }

            pentagramFigureSpriteRenderer.sprite = null;
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
                pentagramDrawingSpriteRenderers[i].sprite = pentagram.drawings[i];
            }

            pentagramFigureSpriteRenderer.sprite = pentagram.figure;
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