using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    PlayerCharacter player;
    EnemyNPC enemy;
    private void Start()
    {
        Weapon sword = new Weapon("Sword", 35, 15);
        Weapon bowAndArrow = new Weapon("BowAndArrod", 13, 25);

        player = new PlayerCharacter("Player", 100, sword, 2);
        enemy = new EnemyNPC("Enemy", 80, bowAndArrow, 3);
    }

    private void Update()
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            player.Attack(enemy);
            if (enemy.Health <= 0)
            {
                Debug.Log($"{enemy.Name} has been defeated!");
                break;
            }

            enemy.Attack(player);
            if (player.Health <= 0)
            {
                Debug.Log($"{player.Name} has been defeated!");
                break;
            }
        }
    }
}
