using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player player;

    public UnityEvent OnDie;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Awake()
    {
        if(player == null)
        {
            player = this;
        }
    }

    public void Die()
    {
        OnDie.Invoke();
    }
}
