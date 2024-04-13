using System;
using TMPro;
using UnityEngine;

namespace LudumDare55
{
    public class CatalogueView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer demonIcon;
        [SerializeField] private SpriteRenderer[] demonItems;
        [SerializeField] private SpriteRenderer pentagramFigure;
        [SerializeField] private SpriteRenderer pentagramDrawing;
        [SerializeField] private SpriteRenderer pentagramBorder;
        [SerializeField] private TextMeshProUGUI demonDescription;
    }
}