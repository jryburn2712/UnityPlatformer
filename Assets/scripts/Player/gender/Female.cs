
using UnityEngine;

class Female : CharacterGender
{

    public Female(Player player) : base(player)
    {

    }

    private const string IDLE_ANIM_NAME = "female_idle";
    private const string WALK_ANIM_NAME = "female_walk";
    private const string ATTACK_ANIM_NAME = "female_attack";
    private const string DEATH_ANIM_NAME = "female_dead";

    public override string getWalkAnimName()
    {
        return WALK_ANIM_NAME;
    }

    public override string getIdleAnimName()
    {
        return IDLE_ANIM_NAME;
    }

    public override string getAttackAnimName()
    {
        return ATTACK_ANIM_NAME;
    }

    public override string getDeathAnimName()
    {
        return DEATH_ANIM_NAME;
    }

    public override AudioClip getJumpAudio()
    {
        //Get a random AudioClip form the femaleJumpSounds AudioClip array
        int rand = Random.Range(0, player.femaleJumpSounds.Length);
        return player.femaleJumpSounds[rand];
    }
}

