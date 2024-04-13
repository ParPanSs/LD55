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
        [SerializeField] private SpriteRenderer pentagramBorder;
        [SerializeField] private SpriteRenderer[] demonItems;
        [SerializeField] private TextMeshPro demonDescription;
        
        private CreateScriptableObjectOfDemon demonSO;

        public void DisplayCurrentDemon(string demonID)
        {
            Debug.Log(demonID);
            demonSO = allDemons.Find(x => x.demonID == demonID);
            demonIcon.sprite = demonSO.catalogueDemonSprite;
            pentagramFigure.sprite = demonSO.pentagram.figure;
            pentagramBorder.sprite = demonSO.pentagram.border;
            pentagramDrawing.sprite = demonSO.pentagram.drawing;
            demonDescription.text = demonSO.cassette.GetDescription();
            for (int i = 0; i < demonItems.Length; i++)
            {
                if(demonItems[i])
                    demonItems[i].sprite = demonSO.itemToSummon[i].itemSprite;
            }
        }
    }
}