
class Male : CharacterGender
{

    private const string IDLE_ANIM_NAME = "male_idle";
    private const string WALK_ANIM_NAME = "male_walk";
    private const string ATTACK_ANIM_NAME = "male_attack";
    private const string DEATH_ANIM_NAME = "male_dead";


    public string getAttackAnimName()
    {
        return ATTACK_ANIM_NAME;
    }

    public string getDeathAnimName()
    {
        return DEATH_ANIM_NAME;
    }

    public string getIdleAnimName()
    {
        return IDLE_ANIM_NAME;
    }

    public string getWalkAnimName()
    {
        return WALK_ANIM_NAME;
    }
}

