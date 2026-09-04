namespace ClassReview.Model
{
    public class Pet
    {
        /// <summary>
        /// エサの数（ペットたちで共有）
        /// </summary>
        private static int feedCount = 10;
        /// <summary>
        /// ペット名
        /// </summary>
        private string name;
        /// <summary>
        /// ペットの体力
        /// </summary>
        private int hp;

        /// <summary>
        /// エサの残り数
        /// </summary>
        internal static int FeedCount
        {
            get
            {
                return Pet.feedCount;
            }
        }

        /// <summary>
        /// ペット名（プロパティ）
        /// </summary>
        internal string Name
        {
            get
            {
                return this.name;
            }
        }
        /// <summary>
        /// ペットの体力（プロパティ）
        /// </summary>
        internal int Hp
        {
            get
            {
                return this.hp;
            }
        }

        /// <summary>
        /// コンストラクタ（オーバロード）
        /// </summary>
        /// <param name="name">ペット名</param>
        internal Pet(string name) : this(name, 10)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ペット名</param>
        /// <param name="hp">体力</param>
        internal Pet(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }

        /// <summary>
        /// エサを食べる
        /// </summary>
        /// <returns>食べた後のメッセージ</returns>
        internal string Eat()
        {
            string message;
            if (this.hp <= 0)
            {
                message = $"{this.name}は死んでいるようだ。悲しいなぁ。";
            }
            else
            {
                if (0 < Pet.feedCount)
                {
                    this.hp++;
                    Pet.feedCount--;
                    message = $"{this.name}は餌を食べました。";
                }
                else
                {
                    message = $"{this.name}が食べるエサがありません。";
                }
            }
            return message;
        }

        /// <summary>
        /// 芸をする
        /// </summary>
        /// <returns>芸をした後のメッセージ</returns>
        internal string Play()
        {
            string message;
            if (this.hp <= 0)
            {
                message = $"{this.name}は死んでいるようだ。悲しいなぁ。";
            }
            else
            {
                this.hp--;
                Pet.feedCount++;
                message = $"{this.name}は芸をしました。";
                if (this.hp <= 0)
                {
                    message += $"{this.name}は死んでしまいました。悲しいなぁ。";
                }
            }
            return message;
        }
    }
}
