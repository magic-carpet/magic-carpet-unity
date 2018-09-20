﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCache : MonoBehaviour
{

    public GameObject lowLODPanelPrefab;
    public GameObject highLODPanelPrefab;
    public Transform[] panelPosn;
    [SerializeField] private int _numOfPanels;
    private GameObject _panelParent;
    [SerializeField] private Transform _panelsGroup;

    [SerializeField] private Color32[] _panelColors;
    public bool colourfulTiles = false;

    // Use this for initialization
    void Start()
    {
        _panelParent = this.gameObject;
        _numOfPanels = _panelParent.transform.childCount;
        panelPosn = new Transform[_numOfPanels];
        _panelColors = new Color32[4];
        _panelColors[0] = new Color32(178, 209, 240, 100);
        _panelColors[1] = new Color32(211, 102, 133, 100);
        _panelColors[2] = new Color32(238, 219, 80, 100);
        _panelColors[3] = new Color32(2, 168, 148, 100);
        CachePanelPositions();
       InstancePanels();
    }

    private void CachePanelPositions()
    {
        for (int i = 0; i < _numOfPanels; i++)
        {
            panelPosn[i] = _panelParent.transform.GetChild(i);
        }

    }
    private void InstancePanels()
    {
        for (int i = 0; i < _numOfPanels; i++)
        {
           var clone = Instantiate(lowLODPanelPrefab, panelPosn[i].position, panelPosn[i].rotation, _panelsGroup.transform);
            clone.name = "PanelPosition(" + i + ")";
            if (colourfulTiles){
                Renderer rend = clone.GetComponent<Renderer>();
                rend.material.color = _panelColors[Random.Range(0, _panelColors.Length)];
            }
        }

    }

}
