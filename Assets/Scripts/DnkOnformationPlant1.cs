using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DnkOnformationPlant1 : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    
    public bool ismouse;
    private void Start()
    {
        
    }

    private void Update()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ismouse = true;
    }
   public void OnPointerExit(PointerEventData eventData) 
    {
        ismouse = false;
    }

    
}