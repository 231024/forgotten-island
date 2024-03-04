using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSquads : MonoBehaviour
{
    [SerializeField] private ViewItemSquad _itemButton;
    [SerializeField] private Transform _parent;

    public event Action<string> IdsInstance; 
    
    public void Reinstantiate(string [] ids)
    {
        foreach (var id in ids)
        {
            Instantiate(_itemButton, _parent).Init(id, CallBack);
        }
    }

    private void CallBack(string id)
    {
        IdsInstance?.Invoke(id);
    }
}
