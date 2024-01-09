using System;

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon EquippedWeapon { get; set; }

    public Character(string name, int health, Weapon equippedWeapon)
    {
        Name = name;
        Health = health;
        EquippedWeapon = equippedWeapon;
    }

    public void Attack(Character target)
    {
        int damage = EquippedWeapon.Attack * (int)Math.Ceiling((double)EquippedWeapon.Agility / 10);
        target.Health -= damage;
    }
}

class Weapon
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Agility { get; set; }

    public Weapon(string name, int attack, int agility)
    {
        Name = name;
        Attack = attack;
        Agility = agility;
    }
}

class PlayerCharacter : Character
{
    public int DamageBoost { get; set; }

    public PlayerCharacter(string name, int health, Weapon equippedWeapon, int damageBoost)
        : base(name, health, equippedWeapon)
    {
        DamageBoost = damageBoost;
    }
}

class EnemyNPC : Character
{
    public int DifficultyLevel { get; set; }

    public EnemyNPC(string name, int health, Weapon equippedWeapon, int difficultyLevel)
        : base(name, health, equippedWeapon)
    {
        DifficultyLevel = difficultyLevel;
    }
}
