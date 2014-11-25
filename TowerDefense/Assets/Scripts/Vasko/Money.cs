using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Vasko
{
    class Money : MonoBehaviour
    {
        private int gold;

        public Money(int gold)
        {
            this.Gold = gold;
        }

        public int Gold
        {
            get { return this.gold; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money cannot be negative");
                }
                this.gold = value; 
            }
        }
       
        public void Show(float left, float top, float width, float height)
        {
            GUI.Box(new Rect(left, top, width, height), this.Gold.ToString());
        }

        public static Money operator -(Money myMoney, int moneyToWithdraw)
        {
            return new Money(myMoney.Gold - moneyToWithdraw);
        }

        public static Money operator +(Money myMoney, int moneyToAddition)
        {
            return new Money(myMoney.Gold + moneyToAddition);
        }

    }
}
