namespace TMPointCalc
{
    class TreasureMap
    {
        public int bosspoints { get; private set; }
        public int minibosspoints { get; private set; }
        public int invasionbosspoints { get; private set; }

        public int bossincrease { get; private set; }
        public int minibossincrease { get; private set; }
        public int invasionbossincrease { get; private set; }

        public bool invasion { get; private set; }

        public double pointmultiplier { get; private set; }

        public TreasureMap(int bosspoints, int minibosspoints, int bossincrease, int minibossincrease, bool invasion = false, double pointmultiplier = 1, int invasionbosspoints = 0, int invasionbossincrease = 0)
        {
            this.bosspoints = bosspoints;
            this.minibosspoints = minibosspoints;
            this.bossincrease = bossincrease;
            this.minibossincrease = minibossincrease;
            this.invasion = invasion;
            if (!invasion)
            {
                this.invasionbosspoints = 0;
                this.invasionbossincrease = 0;
            }
            else
            {
                this.invasionbosspoints = invasionbosspoints;
                this.invasionbossincrease = invasionbossincrease;
            }
            this.pointmultiplier = pointmultiplier;
        }

        public void Run()
        {
            bosspoints += bossincrease;
            minibosspoints += minibossincrease;
        }
    }
}
