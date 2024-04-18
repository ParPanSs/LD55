using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace LudumDare55
{
    public class CatalogueView : MonoBehaviour
    {
        [SerializeField] private Demon[] allDemons;
        [SerializeField] private SpriteRenderer demonIcon;
        [SerializeField] private SpriteRenderer pentagramDrawing;
        [SerializeField] private SpriteRenderer[] demonItems;
        [SerializeField] private TextMeshProUGUI demonDescription;
        [SerializeField] private TextMeshProUGUI demonName;
        [SerializeField] private AudioSource bookmarkSound;
        
        private Demon _demonSo;

        // TODO: reorder display and remove debug
        public void DisplayCurrentDemon(string demonID)
        {
            _demonSo = allDemons.FirstOrDefault(x => x.demonID == demonID);
            if (_demonSo == null) return;
            demonDescription.text = _demonSo.catalogueCassette.GetDescription();
            demonName.text = _demonSo.demonName;
            if (_demonSo.itemToSummon.Length < 3) return;
            
            demonIcon.sprite = _demonSo.catalogueDemonSprite;
            pentagramDrawing.sprite = _demonSo.cataloguePentagram.sprite;
            for (int i = 0; i < demonItems.Length; i++)
            {
                if (demonItems[i]) demonItems[i].sprite = _demonSo.itemToSummon[i].itemSprite;
            }

            if (!bookmarkSound.mute) bookmarkSound.Play();
            else bookmarkSound.mute = false;
        }

        private void OnDestroy()
        {
            for (int i = 0; i < allDemons.Length; i++)
            {
                allDemons[i] = null;
            }
            allDemons = null;
        }
    }
}