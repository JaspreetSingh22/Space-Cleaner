using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,time);
    }

}
