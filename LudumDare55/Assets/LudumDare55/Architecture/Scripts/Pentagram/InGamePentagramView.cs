using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace LudumDare55
{
    [System.Serializable]
    public class IdDemonPrefab
    {
        public string id;
        public GameObject demonPrefab;
    }
    public class InGamePentagramView : MonoBehaviour
    {
        [SerializeField] private GameObject cassettePrefab;
        [SerializeField] private IdDemonPrefab[] idDemonPrefabs;
        [SerializeField] private Transform[] itemSpawnPoints;
        [SerializeField] private Transform cassetteSpawnPoint;
        [SerializeField] private SpriteRenderer pentagramFigureSpriteRenderer;
        [SerializeField] private SpriteRenderer[] pentagramDrawingSpriteRenderers;
        [SerializeField] private Transform demonSpawnPoint;
        [SerializeField] private PlayableDirector pentagramStartDirector;
        [SerializeField] private PlayableDirector pentagramExitDirector;
        
        
        private readonly List<GameObject> spawnedItems = new();
        private GameObject _spawnedCassette;
        private GameObject _spawnedDemon;
        private GameObject _demonPrefab;
        
        public void DisplaySetup(CreateScriptableObjectOfSetup setup)
        {
            CreatePentagram(setup.setupCataloguePentagram);
            CreateItems(setup.setupItems);
            CreateCassette(setup.setupCassette);
            _demonPrefab = idDemonPrefabs.FirstOrDefault(prefab => prefab.id == setup.demonSetupId)?.demonPrefab;
        }

        public void ClearSetup()
        {
            DestroyPentagram();
            DestroyItems();
            DestroyCassette();
        }

        private void DestroyPentagram()
        {
            pentagramExitDirector.Play();
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

        private void DestroyWithDelay(GameObject objectToDestroy, float time)
        {
            objectToDestroy.TryGetComponent<Animator>(out var animator);
                
            try { animator.SetTrigger("Disappear"); }
            catch
            {
                // ignored
            }

            if (_spawnedDemon == null) CreateDemon();
            Destroy(objectToDestroy, time);
        }

        private void CreatePentagram(InGamePentagram pentagram)
        {
            if (pentagram.drawings.Length == 0) return;
            for (var i = 0; i < pentagram.drawings.Length; i++)
            {
                pentagramDrawingSpriteRenderers[i].sprite = pentagram.drawings[i];
            }
            pentagramFigureSpriteRenderer.sprite = pentagram.figure;
            
            pentagramStartDirector.Play();
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
            if (cassetteObject.TryGetComponent(out InGameCassetteObject inGameCassetteObject))
            {
                inGameCassetteObject.Construct(cassette.cassetteAudio);
            }
            _spawnedCassette = cassetteObject;
        }

        private void CreateDemon()
        {
            _spawnedDemon = Instantiate(_demonPrefab, demonSpawnPoint);
            DestroyWithDelay(_spawnedDemon, 4f);
        }
    }
}