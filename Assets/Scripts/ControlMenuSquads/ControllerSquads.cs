using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ControllerSquads : MonoBehaviour
{
    [SerializeField] private ViewSquads _viewSquads;
    
    
    void Start()
    {
        UnitPool.EventInstantiate += EventInstantiate;
        _viewSquads.IdsInstance += ViewSquadsOnIdsInstance;
    }

    void Update()
    {
        
    }

    private void EventInstantiate()
    {
        _viewSquads.Reinstantiate(new string[2]);
    }

    private void ViewSquadsOnIdsInstance(string id)
    {
        Debug.Log("Create Button");
    }

    private void OnDestroy()
    {
        UnitPool.EventInstantiate -= EventInstantiate;
        _viewSquads.IdsInstance -= ViewSquadsOnIdsInstance;
    }
}
