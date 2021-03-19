using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemtToPlaceDefenderAt(GetSquareClicked());
    }

    public void SelectNewDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemtToPlaceDefenderAt(Vector2 gridPos)
    {
        if (!defender)
        {
            return;
        }
        
        var manaDisplay = FindObjectOfType<ManaDisplay>();
        int defenderCost = defender.GetManaCost();

        if (manaDisplay.HaveEnoughMana(defenderCost))
        {
            manaDisplay.SpendMana(defenderCost);
            SpawnDefender(gridPos);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }


    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity, defenderParent.transform) as Defender;
    }

}