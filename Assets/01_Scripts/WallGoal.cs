using System;
using UnityEngine;

public class WallGoal : MonoBehaviour
{
    [SerializeField] private int IDPlayer;
    public event Action<int> OnGoal;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            int scoringPLayerID = IDPlayer == 1 ? 2 : 1;
            OnGoal?.Invoke(scoringPLayerID);
        }
    }
}
