using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {

        protected int _sevensOutTurnCounter;
        protected int _sevensOutPlayCounter;
        protected int _threeOrMorePlayCounter;

        public void SevensOutTurnCountIncrement()
        {
            _sevensOutTurnCounter = _sevensOutTurnCounter + 1;
        }

        public void ResetSevensOutTurns()
        {
            _sevensOutTurnCounter = 0;
        }

        public int GetSevensOutTurnCount()
        {
            return _sevensOutTurnCounter;
        }

        public void SevensOutPlayCountIncrement()
        {
            _sevensOutPlayCounter = _sevensOutPlayCounter + 1;
        }

        public int GetSevensOutPlayCount()
        {
            return _sevensOutPlayCounter;
        }

        public void threeOrMorePlayCounterIncrement()
        {
            _threeOrMorePlayCounter = _threeOrMorePlayCounter + 1;
        }

        public int GetThreeOrMorePlayCount()
        {
            return _threeOrMorePlayCounter;
        }

    }
}
