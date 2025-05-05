using System.Collections;
using UnityEngine;

public class Melody : MonoBehaviour
{
    public int melodyIdx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetInstance().GetMelody(melodyIdx);
            Destroy(gameObject);
        }
    }
}
