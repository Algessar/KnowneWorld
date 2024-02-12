public static class DiceRoller
{
    private static System.Random random = new System.Random();

    public static int Roll( int minValue, int maxValue )
    {
        return random.Next(minValue, maxValue + 1);
    }

    public static int RollDice( int _arcpower )
    {
        return Roll(1, _arcpower + 1);
    }


}