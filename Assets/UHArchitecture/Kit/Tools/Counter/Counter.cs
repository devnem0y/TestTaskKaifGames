using System;

namespace UralHedgehog
{
    public abstract class Counter
    {
        public int Value { get; private set; }
        public event Action Change;

        protected Counter(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Добавление
        /// </summary>
        public void Add(int value)
        {
            Value += value;
            Change?.Invoke();
        }

        /// <summary>
        /// Проверка на наличие
        /// </summary>
        public bool Available(int value)
        {
            return Value >= value;
        }

        /// <summary>
        /// Снятие
        /// </summary>
        public void Withdraw(int value)
        {
            if (!Available(value)) return;
            
            Value -= value;
            Change?.Invoke();
        }

        /// <summary>
        /// Обнуление
        /// </summary>
        public void Zero()
        {
            Value = 0;
            Change?.Invoke();
        }
    }
}
