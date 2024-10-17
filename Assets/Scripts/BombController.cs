using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.Space;
    public float bomFuseTime = 3f;
    public int bomAmount = 1;

    private int bomsRemaining;

    [Header("Explosion")]
    public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    [Header("Destructible")]
    public Tilemap destructibleTiles;
    public Destructible destructiblePrefab;

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
        position.x = Mathf.Round(position.x) + 0.1f;
        position.y = Mathf.Round(position.y) + 0.2f;
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);

        bomsRemaining--;

        yield return new WaitForSeconds(bomFuseTime);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x) + 0.1f;
        position.y = Mathf.Round(position.y) + 0.2f;
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRendered(explosion.start);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);

        Destroy(bomb);
        bomsRemaining++;
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if(length <= 0) return;

        position += direction;

        if(Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDestructible(position);
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRendered(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1);
    }

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
        }
    }

    public void AddBomb()
    {
        bomAmount++;
        bomsRemaining++;
    }
}
