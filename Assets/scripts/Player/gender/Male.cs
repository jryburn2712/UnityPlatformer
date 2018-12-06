
using UnityEngine;

class Male : CharacterGender
{

    public Male(Player player) : base(player)
    {
       
    }

    private const string IDLE_ANIM_NAME = "male_idle";
    private const string WALK_ANIM_NAME = "male_walk";
    private const string ATTACK_ANIM_NAME = "male_attack";
    private const string DEATH_ANIM_NAME = "male_dead";


    public override string getAttackAnimName()
    {
        return ATTACK_ANIM_NAME;
    }

    public override string getDeathAnimName()
    {
        return DEATH_ANIM_NAME;
    }

    public override string getIdleAnimName()
    {
        return IDLE_ANIM_NAME;
    }

    public override string getWalkAnimName()
    {
        return WALK_ANIM_NAME;
    }

    public override AudioClip getJumpAudio()
    {
        //Get a random AudioClip form the maleJumpSounds AudioClip array
        int rand = Random.Range(0, player.maleJumpSounds.Length);
        return player.maleJumpSounds[rand];
    }
}

