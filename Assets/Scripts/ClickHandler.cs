using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onClick;
    private void OnMouseUpAsButton()
    {
        _onClick?.Invoke();
    }
}
