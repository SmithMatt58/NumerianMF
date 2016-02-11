using System;
using System.Collections.Generic;

namespace NumerianMF
{
	public static class MysteryFluid
	{
		public static bool IsSameResult(int roll1, int roll2)
		{
			if (roll1 == roll2)
				return true;

			if (InRange (roll1, 86, 90) && InRange (roll2, 86, 90))
				return true;

			return GetEffectString (roll1) == GetEffectString (roll2);
		}

		// Effects chart (http://www.d20pfsrd.com/gamemastering/afflictions/drugs/strange-fluids)
		public static string GetEffectString(int roll)
		{
			if (roll == 1)
				return "The drinker's cellular structure breaks down, and her flesh dissolves off of her bones. The victim dies in 1 round unless a limited wish, regeneration (not just the regeneration ability), or wish spell is administered. Immunity to ability drain prevents death, but immunity to death effects or poison does not.";

			if (InRange (roll, 2, 4))
				return "The drinker permanently loses a random sense (roll 1d4: 1–hearing, 2–sight, 3–smell, 4–taste). A regenerate spell restores lost smell or taste. Moderate addiction.";

			if (InRange (roll, 5, 7))
				return "The drinker ages 2d10 years.";

			if (InRange (roll, 8, 10))
				return "The drinker takes 2d6 points of damage to all ability scores (roll once for damage, apply it to each). If any score reaches 0, death results. If the imbiber survives, roll again for an additional side effect, rerolling a result of 15 or lower.";

			if (InRange (roll, 11, 15))
				return "The drinker takes 2d4 points of drain to a random ability score.";

			if (InRange (roll, 16, 20))
				return "The drinker takes 1d4 points of Intelligence damage and loses the ability to speak or write (but not to listen and read) for 1d4 days. Moderate addiction.";

			if (InRange (roll, 21, 30))
				return "The drinker contracts a random form of insanity for 1d4 days.";

			if (InRange (roll, 31, 35))
				return "The fluids impart 1d4 negative levels to the drinker (Fortitude DC 20 to remove).";

			if (InRange (roll, 36, 40))
				return "The drinker is rendered unconscious until the effects of the dose wear off. Mild addiction.";

			if (InRange (roll, 41, 50))
				return "The drinker is nauseated for 2d6×10 minutes.";

			if (InRange (roll, 51, 60))
				return "The drinker is sickened until the effects of the dose wear off.";

			if (InRange (roll, 61, 65))
				return "The drinker is fascinated by visions of a far-off reality for 1d4 hours. An interruption that ends the fascination provokes incoherent anger (attack nearest creature) for 1d4 rounds. Strong addiction.";

			if (InRange (roll, 66, 70))
				return "The drinker exudes an unpleasant odor, as the stench ability, for 24 hours.";

			if (InRange (roll, 71, 75))
				return "The drinker gains increased empathy with mechanical minds for 24 hours, gaining a +10 bonus on Bluff, Diplomacy, Intimidate, and Sense Motive checks against androids and robots, but takes a –5 penalty on such checks against other creatures.";

			if (InRange (roll, 76, 80))
				return "For 1d4 hours, the drinker is healed by a random energy type (acid, cold, electricity, fire, or sonic) instead of harmed. Being healed in this fashion staggers the drinker for 1 round.";

			if (InRange (roll, 81, 85))
				return "The drinker's skin thickens into armor-like plates. This gives a +2 bonus to natural armor and a –2 penalty to Dexterity. Multiple doses do not stack. It takes 1d4 months for the excess skin to slough off.";

			if (InRange (roll, 86, 90))
			{
				string result = "Roll twice. If the first result is below 20, add 20 to the result. If the second result is above 80, subtract 20 from the result. If the same side effect results on both rolls, apply it only once, but the drinker becomes severely addicted to that result.";
				int roll1 = RNG.RollDie (100);
				int roll2 = RNG.RollDie (100);

				if (roll1 < 20)
					roll1 += 20;

				if (roll2 > 80)
					roll2 -= 20;

				if (IsSameResult (roll1, roll2))
					result += string.Format ("\n<b>({0} and {1})</b> {2}", roll1, roll2, GetEffectString (roll1));
				else
					result += string.Format ("\n<b>({0})</b> {1}\n<b>({2})</b> {3}", roll1, GetEffectString (roll1), roll2, GetEffectString (roll2));

				return result;
			}

			if (InRange (roll, 91, 92))
				return "The drinker gains fast healing 5 for 24 hours, but must consume twice as much food and water as normal.";

			if (InRange (roll, 93, 94))
				return "The drinker gains a +6 enhancement bonus to a random ability score for 2d4 days.";

			if (InRange (roll, 95, 96))
				return "The drinker gains telepathy with a range of 100 feet for 2d4 days.";

			if (roll == 97)
				return "The drinker gains the ability to see possible futures a few seconds ahead for 24 hours. Because the visions are distracting, the drinker takes a –2 penalty on ability checks, attack rolls, saving throws, and skill checks, but for one such roll, she can ignore the penalty and roll twice, keeping the better result. The drinker must decide to use this ability before rolling.";

			if (roll == 98)
				return "The drinker becomes 1d6 years younger. If this changes her age category, adjust physical attributes but not mental. Mental attributes don't increase when the original age category is reached again (see Young Characters).";

			if (roll == 99)
				return "The drinker foresees her death in a cryptic and disjointed vision. The next time an effect would cause her death, she can take an extra standard action just before she dies (including actions like healing spells that prevent the impending death).";

			if (roll == 100)
			{
				int random = RNG.RollDie (10);

				if (random == 1)
					return "<b>Immortality:</b> The drinker no longer takes penalties for aging (bonuses still apply) and does not die from old age.";

				if (random == 2)
					return "<b>Mutant:</b> The drinker gains the mutant template. The mutations should reflect the drinker's inner personality, as determined by the GM.";

				if (random == 3)
					return "<b>Phasing:</b> The drinker gains the ability to become incorporeal for 1d4 rounds as a swift action, but takes 1 point of Con damage when he does so. Phasing can be extended as a free action by taking 1 additional point of Con damage. Coming out of phase inside a solid object is instantly fatal. Phasing cannot be used by creatures that are immune to Con damage.";

				if (random == 4)
					return "<b>Three-Dimensional Touch:</b> The drinker gains blindsense with a range of 60 feet. Focusing on this sense as a move action improves it to blindsight with a range of 60 feet until the start of the drinker's next turn.";

				if (random == 5)
					return "<b>Wings:</b> The drinker grows a pair of batlike wings that grant a fly speed of 30 feet and average maneuverability.";

				if (random == 6)
					return "<b>Ability Score Bonus:</b> The drinker gains a +2 inherent bonus to a random ability score.";

				if (random == 7)
					return "<b>Fluid Generation:</b> The drinker's body naturally creates its own approximation of Strange fluids, which he can, as a standard action once a day, redirect into his system to gain the effects of drinking 1 dose of Strange fluids. Treat the addiction, effects, and side effects of this dose as normal, save that it cannot provide an additional exceptional effect (reroll results of 100).";

				if (random == 8)
					return "<b>Grounding Skin:</b> The drinker grows a metal mesh surrounding his skin that grants him electricity resistance 10.";

				if (random == 9)
					return "<b>Bioluminescence:</b> The drinker's body glows as gem of brightness. The drinker can produce this effect 5 times per day.";

				if (random == 10)
					return "<b>Sleep of Experience:</b> For 24 hours, the drinker falls into a coma and cannot be awakened. During this time, he dreams of living an entire lifetime on a different planet in an alien body. The drinker gains the number of bonus experience points needed to advance 1 level. A creature can gain this exceptional effect only once (reroll all future exceptional effect rolls of 10).";
			}

			return "";
		}

		private static bool InRange(int i, int min, int max)
		{
			return i >= min && i <= max;
		}
	}
}

