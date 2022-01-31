using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public float spawnRate = 2.0f;
    public float spawnDistance = 30.0f;
    public float trajVariance = 15.0f;
    public int spawnAmount = 1;

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
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}