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
        public string getNumberToCall()
        {
            return _NumberToCall;
        }
        public void setNumberToCall(string value)
        {
            _NumberToCall = value; 
        }
        public DateTime getStartTime()
        {
            return _StartTime;
        }
        public void setStartTime(DateTime value)
        {
             _StartTime = value; 
        }
        public TimeSpan getDuration()
        {
            return _Duration;
        }
        public void setDuration(TimeSpan value)
        {
            _Duration = value;
        }
        public double getCost()
        {
            return _Cost;
        }
        public void setCost(double value)
        {
            _Cost = value;
        }
        #endregion

        public Call(int id) : base(id)
        {
            
        }

        public Call(Call call)
            : base(call)
        {
            _NumberToCall = call.getNumberToCall();
            _StartTime = call.getStartTime();
            _Duration = call.getDuration();
            _Cost = call.getCost();
        }
    }
}
