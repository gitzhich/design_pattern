/********************
* Builder Sample    *
*                   *
********************/
enum EnemyType
{
    Zombie,
    Skelton,
    Creeper
}

class Enemy
{
    public EnemyType Type { get; set; }
    public int Life { get; set; }
    public float Speed { get; set; }
    public int AttackDamage { get; set; }
    public bool IsVillager { get; set; }
    public float ShootingInterval { get; set; }
    public int ExplosionSize { get; set; }
}

class Director
{
    private Builder builder;

    public Enemy construct()
    {
        builder.buildType();
        builder.buildLife();
        builder.buildSpeed();
        builder.buildAttackDamage();

        if (builder is ZombieBuilder)
        {
            builder.buildIsVillager();
        }
        if (builder is SkeltonBuilder)
        {
            builder.buildShootingInterval();
        }
        if (builder is CreeperBuilder)
        {
            builder.buildExplosionSize();
        }
        return builder.getResult();
    }
}

interface Builder
{
    void buildType();
    void buildLife();
    void buildSpeed();
    void buildAttackDamage();
    Enemy getResult();
}

class ZombieBuilder : Builder
{
    private Enemy enemy;

    ZombieBuilder()
    {
        this.enemy = new Enemy();
    }

    public void buildType() { this.enemy.Type = EnemyType.Zombie; }
    public void buildLife() { this.enemy.Life = 10; }
    public void buildSpeed() { this.enemy.Speed = 7.0f; }
    public void buildAttackDamage() { this.enemy.AttackDamage = 3; }

    public void buildIsVillager() { this.enemy.IsVillager = false; }

    public Enemy getResult()
    {
        return this.enemy;
    }
}

class SkeltonBuilder : Builder
{
    private Enemy enemy;

    SkeltonBuilder()
    {
        this.enemy = new Enemy();
    }

    public void buildType() { this.enemy.Type = EnemyType.Skelton; }
    public void buildLife() { this.enemy.Life = 8; }
    public void buildSpeed() { this.enemy.Speed = 10.0f; }
    public void buildAttackDamage() { this.enemy.AttackDamage = 6; }

    public void buildShootingInterval() { this.enemy.ShootingInterval = 1.5f; }

    public Enemy getResult()
    {
        return this.enemy;
    }
}

class CreeperBuilder : Builder
{
    private Enemy enemy;

    CreeperBuilder()
    {
        this.enemy = new Enemy();
    }

    public void buildType() { this.enemy.Type = EnemyType.Creeper; }
    public void buildLife() { this.enemy.Life = 4; }
    public void buildSpeed() { this.enemy.Speed = 5.5f; }
    public void buildAttackDamage() { this.enemy.AttackDamage = 10; }

    public void buildExplosionSize() { this.enemy.ExplosionSize = 2; }

    public Enemy getResult()
    {
        return this.enemy;
    }
}

public class Sample()
{
    public static void Main()
    {
        Director directorZombie = new Director(new ZombieBuilder());
        Director directorSkelton = new Director(new SkeltonBuilder());
        Director directorCreeper = new Director(new CreeperBuilder());
        Enemy zombie = directorZombie.construct();
        Enemy skelton = directorSkelton.construct();
        Enemy creeper = directorCreeper.construct();
    }
}
