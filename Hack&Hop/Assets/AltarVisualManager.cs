using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AltarVisualManager : MonoBehaviour
{
    public AltarDataSctript altarData;
    public SpriteRenderer itemLocation;
    public TMP_Text text_itemName;
    public TMP_Text text_description;
    void Start()
    {
        itemLocation.sprite = altarData.powerUpTool.sprite;
        text_description.SetText(altarData.powerUpTool.toolExplanation);
        text_itemName.SetText(altarData.powerUpTool.toolName);
        setTextVisible(false);
    }
    public void setTextVisible(bool isVisible){
        text_description.enabled = isVisible;
        text_itemName.enabled = isVisible;
    }
    public void setSpriteVisible(bool isVisible){
        itemLocation.enabled = isVisible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
