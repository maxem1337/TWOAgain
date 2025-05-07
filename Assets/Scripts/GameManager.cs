using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject worldA;
    [SerializeField] private GameObject worldB;
    [SerializeField] private GameObject Camera1;
    [SerializeField] private GameObject Camera2;
    private bool isWorldAActive = true;

    void OnSwitchCharacter(InputValue value)
    {
        if (!value.isPressed) return;

        isWorldAActive = !isWorldAActive;
        worldA.SetActive(isWorldAActive);
        worldB.SetActive(!isWorldAActive);
        
        Camera1.SetActive(isWorldAActive);
        Camera2.SetActive(!isWorldAActive);


    }
}
