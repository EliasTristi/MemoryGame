using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator _animator;
    

    void Start()
    {
        //_animator = FindObjectOfType<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Hello");
        _animator.Play("Shown");
    }
}
