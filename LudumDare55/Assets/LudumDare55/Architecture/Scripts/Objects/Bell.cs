using UnityEngine;

namespace LudumDare55
{
    public class Bell : MonoBehaviour
    {
        private RoundEnder _roundEnder;
        private CatalogueController _catalogueController;
        
        public void Construct(CatalogueController catalogueController, RoundEnder roundEnder)
        {
            _catalogueController = catalogueController;
            _roundEnder = roundEnder;
        }
        private void OnMouseDown()
        {
            _roundEnder.CompareId(_catalogueController.GetSelectedDemon());
        }
        
        //TODO: Катя не понимает, почему связь такая (диалоги между разработчиками в комментариях строго запрещены)
    }
}
