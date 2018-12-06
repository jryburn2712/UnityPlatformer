
public abstract class CharacterGender
{
    protected Player player;

    public CharacterGender(Player player)
    {
        this.player = player;
    }

    public abstract string getWalkAnimName();
    public abstract string getIdleAnimName();
    public abstract string getAttackAnimName();
    public abstract string getDeathAnimName();

    public abstract UnityEngine.AudioClip getJumpAudio();
    
}

