using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    public void update(Player player) {
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButtonDown(0) &
                !GameManager.paused & !player.getPlayerData().getModes()[0]) {
            ShootBullets(player);
        }
    }

    private void ShootBullets(Player player) {
        Vector3 fireAngle;
        Quaternion rotation;
        if(player.getPlayerData().getModes()[1]) {
            fireAngle = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            rotation = Random.rotation;
            rotation *= Quaternion.Euler(0, 0, 0);
        } else {
            fireAngle = this.transform.up;
            rotation = this.transform.rotation;
            rotation *= Quaternion.Euler(0, 0, 0);
        }

        for (int i = 0; i < player.getNumBullets(); i++) {
            Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, rotation);
            bullet.Shoot(fireAngle);
            rotation *= Quaternion.Euler(0, 0, player.angleChange);
            fireAngle = Quaternion.Euler(0, 0, player.angleChange) * fireAngle;
        }
        player.setBulletsFired(player.getBulletsFired() + player.getNumBullets());
    }
}
