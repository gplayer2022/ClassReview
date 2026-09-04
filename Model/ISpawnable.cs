namespace ClassReview.Model
{
    public interface ISpawnable
    {
        /// <summary>
        /// 産卵する
        /// </summary>
        /// <returns>産卵時のメッセージ</returns>
        public string Spawn();
    }
}
