using System.Collections;
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
 
    // Use this for initialization
    void Start()
    {
        _panelParent = this.gameObject;
        _numOfPanels = _panelParent.transform.childCount;
        panelPosn = new Transform[_numOfPanels];
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
        }

    }

}
