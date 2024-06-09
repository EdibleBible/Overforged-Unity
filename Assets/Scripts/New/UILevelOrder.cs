using OverForged;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ItemTypes;

public class UILevelOrder : MonoBehaviour
{
    public TextMeshProUGUI textGui;
    public int localAmount;
    public ItemType orderType;

    private void OnEnable()
    {
        GameProgress.ProgressEvent += UpdateAmount;
        textGui.text = localAmount.ToString();
    }

    private void OnDisable()
    {
        GameProgress.ProgressEvent -= UpdateAmount;
    }

    void UpdateAmount(ItemInteract item)
    {
        if (item.IsType(orderType))
        {
            textGui.text = (++localAmount).ToString();
        }
    }
}
