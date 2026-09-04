namespace ClassReview.Model
{
    public abstract class Animal
    {
        /// <summary>
        /// 名前
        /// </summary>
        protected string name;
        /// <summary>
        /// 体力
        /// </summary>
        protected int hp;

        /// <summary>
        /// 名前（プロパティ）
        /// </summary>
        internal string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// 体力（プロパティ）
        /// </summary>
        internal int Hp
        {
            get
            {
                return this.hp;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="hp">体力</param>
        internal Animal(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }

        /// <summary>
        /// コンストラクタ（オーバロード）
        /// </summary>
        /// <param name="name"></param>
        internal Animal(string name) : this(name, 10)
        {
        }

        /// <summary>
        /// 食事をする
        /// </summary>
        /// <returns>食事後のメッセージ</returns>
        internal string Eat()
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
                this.hp++;
                message = $"{this.name}はエサを食べた。体力が回復した。";
            }
            return message;
        }

        /// <summary>
        /// 戦う（抽象メソッド）
        /// </summary>
        /// <returns>戦闘後のメッセージ</returns>
        internal abstract string Fight();
    }
}
