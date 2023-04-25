using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int _level;
    private int _experience;
    private int _experienceToNextLevel;

    // Default Constructor
    public LevelSystem()
    {
        _level = 0;
        _experience = 0;
        _experienceToNextLevel = 100;
    }

    // Parameter Constructor
    public LevelSystem(int level, int experience, int experienceToNextLevel)
    {
        _level = level;
        _experience = experience;
        _experienceToNextLevel = experienceToNextLevel;
    }

    public void AddExperience(int amount)
    {
        _experience += amount;

        if (_experience >= _experienceToNextLevel)
        {
            // Player has enough experience to level up
            // Level up player
            _level++;

            // Reset experience
            _experience -= _experienceToNextLevel;
        }
    }

    public int GetCurrentLevel()
    {
        return _level;
    }
}
