using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;
    private float spawnRate = 2.0f;
    private float spawnDistance = 40.0f;
    private float trajVariance = 15.0f;
    private int spawnAmount = 1;

    private void Start() {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn() {
        for (int i = 0; i < this.spawnAmount; i++) {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajVariance, this.trajVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.setSize(Random.Range(asteroid.getMinSize(), asteroid.getMaxSize()));
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
