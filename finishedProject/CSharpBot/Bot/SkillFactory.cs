using Bot.Skills;
using System;

namespace Bot
{
    internal class SkillFactory
    {
        public static ISkill CreateSkill(int id)
        {
            switch (id)
            {
                case 0:
                    return new ExampleSkill();
                default:
                    throw new ArgumentException($"Invalid id '{id}'.");
            }
        }
    }
}
