using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DnkOnformationPlant2 : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    
    public bool ismouse;
    public Image txt;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (txt != null)
        {
            if (ismouse)
            {
                txt.gameObject.SetActive(true);
            }
            else
            {
                txt.gameObject.SetActive(false);
            }
        }
      
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