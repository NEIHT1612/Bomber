using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.Space;
    public float bomFuseTime = 3f;
    public int bomAmount = 1;

    private int bomsRemaining;

    private void OnEnable() {
        bomsRemaining = bomAmount;
    }

    private void Update() {
        if(Input.GetKeyDown(inputKey) && bomsRemaining > 0) {
            StartCoroutine(PlaceBom());
        }
    }

    private IEnumerator PlaceBom(){
        Vector2 position = transform.position;

        position.x = Mathf.Round(position.x) + 0.5f;
        position.y = Mathf.Round(position.y) + 0.5f;

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bomsRemaining--;

        yield return new WaitForSeconds(bomFuseTime);

        Destroy(bomb);
        bomsRemaining++;
    }
}
