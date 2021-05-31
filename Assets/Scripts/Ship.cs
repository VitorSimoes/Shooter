using System.Collections;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Transform cannon;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject laser2;
    [SerializeField] private GameObject laser3;
    [SerializeField] private GameObject laser4;
    [SerializeField] private GameObject laser5;
    [SerializeField] private GameObject laser6;
    [SerializeField] private GameObject laser7;
    [SerializeField] private GameObject laser8;
    [SerializeField] private GameObject laser9;
    [SerializeField] private GameObject laser10;


    public float shootingTime = 0.1f;
    private bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(
            new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));

        var cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y
        );

        Vector3 position = transform.position;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        position.x += x * 5.0f * Time.deltaTime;
        position.y += y * 5.0f * Time.deltaTime;

        transform.position = position;

        float clampX = Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax);
        float clampY = Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax);

        transform.position = new Vector3(clampX, clampY, transform.position.z);


        if(Input.GetKey(KeyCode.F1))Shot(laser);
        if(Input.GetKey(KeyCode.F2))Shot(laser2);
        if(Input.GetKey(KeyCode.F3))Shot(laser3);
        if(Input.GetKey(KeyCode.F4))Shot(laser4);
        if(Input.GetKey(KeyCode.F5))Shot(laser5);
        if(Input.GetKey(KeyCode.F6))Shot(laser6);
        if(Input.GetKey(KeyCode.F7))Shot(laser7);
        if(Input.GetKey(KeyCode.F8))Shot(laser8);
        if(Input.GetKey(KeyCode.F9))Shot(laser9);
        if(Input.GetKey(KeyCode.F11))Shot(laser10);
        
    }

    void Shot (GameObject laser)
    {
        if (shooting) return;
        shooting = true;

        GameObject newShot = Instantiate(laser, cannon.position, cannon.rotation);
        newShot.TryGetComponent(out Rigidbody2D rb);
        rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
        Destroy(newShot, 2);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown ()
    {
        yield return new WaitForSeconds(shootingTime);
        shooting = false;
    }
}
