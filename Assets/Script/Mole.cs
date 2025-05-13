using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    public Vector3 hiddenPosition;   // 隠れている位置（下）
    public Vector3 visiblePosition;  // 出ている位置（上）
    public float speed = 5f;
    public float visibleDuration = 1.5f;//出ている時間

    private bool isHit = false;//叩かれたか？
    private bool isMovingUp = false;//true →　モグラ出現

    private MeshRenderer meshRenderer;
    public Color hitColor = Color.red;
    private Color originalColor;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
        hiddenPosition = transform.position + new Vector3(0, -1, 0);
        visiblePosition = transform.position;
        transform.position = hiddenPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        if (!isHit && isMovingUp)
        {
            isHit = true;
            gameManager.AddScore();
            meshRenderer.material.color = hitColor;
        }
    }

    public void PopUp()
    {
        if (!isHit && !isMovingUp)
        {
            isMovingUp = true;
            StartCoroutine(HideAfterDelay(visibleDuration));
        }
    }

    IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMovingUp = false;
    }

    void Move()
    {
        if (isMovingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, visiblePosition, speed * Time.deltaTime);
        }
        else
        {
            transform .position = Vector3.MoveTowards(transform.position, hiddenPosition, speed * Time.deltaTime);
            isHit = false;
            meshRenderer.material.color = originalColor;
        }
    }
}
