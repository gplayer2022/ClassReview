namespace ClassReview.Model
{
    public class Lion : Animal
    {
        public Lion(string name, int hp) : base(name, hp)
        {
        }

        /// <summary>
        /// 戦う
        /// </summary>
        /// <returns>戦闘後のメッセージ</returns>
        internal override string Fight()
        {
            string message;
            // 死んでいる場合
            if (this.hp <= 0)
            {
                message = $"{this.name}は死んでいる。もう何もできない。";
            }
            // 生きている場合
            else
            {
                Random random = new Random();
                int injury = random.Next(1, this.hp + 1);
                this.hp -= injury;
                message = $"{this.name}は嚙んで敵を攻撃した。 {injury} のダメージを受けた。";
                if (this.hp <= 0)
                {
                    message += $"{this.name}は死んでしまった。悲しいなぁ。";
                }
            }
            return message;
        }
    }
}
