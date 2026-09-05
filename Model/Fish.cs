namespace ClassReview.Model
{
    public class Fish : Animal, ISpawnable
    {
        public Fish(string name, int hp) : base(name, hp)
        {
        }

        /// <summary>
        /// 卵を産む
        /// </summary>
        /// <returns>産卵後のメッセージ</returns>
        public string Spawn()
        {
            string message;
            // 死んでいる場合
            if (this.hp <= 0)
            {
                message = $"{this.name}は死んでいる。もう何もできない。";
            }
            else
            {
                Random random = new Random();
                int injury = random.Next(this.hp / 2 + 2);
                this.hp -= injury;
                message = $"{this.name}は卵を産んだ。";
                if (this.hp <= 0)
                {
                    message += $"{this.name}は死んでしまった。悲しいなぁ。";
                }
            }
            return message;
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
                this.hp--;
                message = $"{this.name}は空を飛んで敵を攻撃した。 1 のダメージを受けた。";
                if (this.hp <= 0)
                {
                    message += $"{this.name}は死んでしまった。悲しいなぁ。";
                }
            }
            return message;
        }
    }
}
