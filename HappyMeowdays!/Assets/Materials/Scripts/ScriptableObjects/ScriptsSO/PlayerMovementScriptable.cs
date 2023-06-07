using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "PlayerXX")]

public class PlayerMovementScriptable : ScriptableObject
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float groundDrag;
    [SerializeField] public float jumpCooldown;
    [SerializeField] public float jumpForce;
    [SerializeField] public float airMultiplyer;
    [SerializeField] public string Horizontal;
    [SerializeField] public string Vertical;
    [SerializeField] public string interactButton;
    [SerializeField] public KeyCode jumpButton;
}
