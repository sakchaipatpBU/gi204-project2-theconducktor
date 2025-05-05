using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int hp;
    private int maxHp;
    public GameObject[] feathers;
    public GameObject[] melodies;

    public float jumpForce = 10f;
    private Rigidbody2D rb2D;
    private InputAction jumpAction;

    public bool isGameOver = false;

    public TMP_Text gameOverText;
    public Canvas canvas;

    public bool note1;
    public bool note2;
    public bool note3;
    public bool note4;

    private static Player instance;
    public static Player GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        maxHp = hp;
        canvas.enabled = false;
    }

    void Update()
    {
        if (hp <= 0) return;
        if (jumpAction.triggered && isGameOver == false)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (note1 && note2 && note3 && note4)
        {
            GameWin();
            isGameOver = true;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"Player take {damage} damage");
        if (hp <= 0)
        {
            isGameOver = true;
            Debug.Log($"Game Over");

            canvas.enabled = true;
            gameOverText.text = "LOSE!!";
        }

        SpriteRenderer featherRen = feathers[hp].GetComponent<SpriteRenderer>();
        featherRen.color = Color.black;
    }

    public void GetMelody(int idx)
    {
        if (idx == 0) note1 = true;
        if (idx == 1) note2 = true;
        if (idx == 2) note3 = true;
        if (idx == 3) note4 = true;
        melodies[idx].SetActive(false);
    }
    public void GameWin()
    {
        canvas.enabled = true;
        gameOverText.text = "WIN!!";
    }
}
