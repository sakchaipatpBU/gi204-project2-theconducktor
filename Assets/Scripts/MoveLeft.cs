using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        if (Player.GetInstance().hp > 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
