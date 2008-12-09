using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    class Call : DBAbstractObject
    {
        #region <fields>

        string _NumberToCall;
        DateTime _StartTime;
        TimeSpan _Duration;
        double _Cost;

        #endregion

        #region <props>
        public string NumberToCall
        {
            get { return _NumberToCall; }
            set { _NumberToCall = value; }
        }
        
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        public TimeSpan Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        public double Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        #endregion

        public Call(int id) : base(id)
        {
            
        }

        public Call(Call call)
            : base(call)
        {
            _NumberToCall = call.NumberToCall;
            _StartTime = call.StartTime;
            _Duration = call.Duration;
            _Cost = call.Cost;
        }
    }
}
