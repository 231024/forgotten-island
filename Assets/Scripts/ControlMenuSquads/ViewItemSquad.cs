using System;
using UnityEngine;

public class ViewItemSquad : MonoBehaviour
{
       private string _id;

       public Action<string> CallBackItem;

       public void OnClick()
       {
             CallBackItem.Invoke(_id); 
       }

       public void Init(string id, Action<string> callBack)
       {
              _id = id;
              CallBackItem = callBack;
       }
}