using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput = Vector2.zero;

    [SerializeField] private GameObject[] fruits;

    private static int _fruitsCount;

    private void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs/Fruits");

        foreach (GameObject fruit in fruits)
        {
            Debug.Log("Loaded fruit: " + fruit.name);
        }

        _fruitsCount = fruits.Length;
    }

    private void FixedUpdate()
    {
        ApplyMove();
    }

    public void SetFruit()
    {
        int fruitIndex = Random.Range(0, _fruitsCount);

    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnDrop()
    {
        GameObject fruit = fruits[Random.Range(0, _fruitsCount)];
        Vector3 spawnPosition = this.transform.position;
        Instantiate(fruit, spawnPosition, Quaternion.identity);
    }

    private void ApplyMove()
    {
        transform.position += new Vector3(moveInput.x, 0, 0) * 0.1f;
        if(transform.position.x < -4)
        {
            transform.position = new Vector3(-4, transform.position.y, 0);
        }
        else if(transform.position.x > 4)
        {
            transform.position = new Vector3(4, transform.position.y, 0);
        }
    }
}
