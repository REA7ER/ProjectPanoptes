using UnityEngine;
using System.Collections;

public class FoodSourcce : MonoBehaviour
{
    public int Capacity;
    public int Remaining;

    void Start()
    {
        Remaining = Capacity;
    }
}
    