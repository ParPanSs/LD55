using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LudumDare55
{
    public class CatalogueView : MonoBehaviour
    {
        [SerializeField] private List<CreateScriptableObjectOfDemon> allDemons;
        [SerializeField] private SpriteRenderer demonIcon;
        [SerializeField] private SpriteRenderer pentagramFigure;
        [SerializeField] private SpriteRenderer pentagramDrawing;
        [SerializeField] private SpriteRenderer[] demonItems;
        [SerializeField] private TextMeshPro demonDescription;
        
        private CreateScriptableObjectOfDemon _demonSo;

        // TODO: reorder display and remove debug
        public void DisplayCurrentDemon(string demonID)
        {
            Debug.Log("Catalogue demon ID: " + demonID);
            
            _demonSo = allDemons.Find(x => x.demonID == demonID);
            demonDescription.text = _demonSo.catalogueCassette.GetDescription();
            if (_demonSo.itemToSummon.Count < 3) return;
            
            demonIcon.sprite = _demonSo.catalogueDemonSprite;
            pentagramDrawing.sprite = _demonSo.cataloguePentagram.sprite;
            for (int i = 0; i < demonItems.Length; i++)
            {
                if (demonItems[i]) demonItems[i].sprite = _demonSo.itemToSummon[i].itemSprite;
            }
        }
    }
}