using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class GameData
    {
        private XElement _xElement;
        private XElement _TicksGame;
        private XElement _StartingYear;
        private XElement _GameStartAbsTick;

        public long StartYear
        {
            get
            {
                if (_StartingYear.GetValue().Length > 0)
                {
                    return long.Parse(_StartingYear.GetValue());
                }
                return 0;
            }
            set
            {
                _StartingYear.SetValue(value);
            }
        }

        public long GameTime
        {
            get
            {
                if (_TicksGame.GetValue().Length > 0)
                {
                    return long.Parse(_TicksGame.GetValue());
                }
                return 0;
            }
            set
            {
                if(value > 0)
                {
                    _TicksGame.SetValue(value);
                }
                else
                {
                    _TicksGame.SetValue(0);
                }
            }
        }

        public long GameStartAbsTick
        {
            get
            {
                if (_GameStartAbsTick.GetValue().Length > 0)
                {
                    return long.Parse(_GameStartAbsTick.GetValue());
                }
                return 0;
            }
            set
            {
                _GameStartAbsTick.SetValue(value);
            }
        }

        public GameData(XElement xElement)
        {
            _xElement = xElement;
            _TicksGame = xElement.Element("ticksGame");
            _StartingYear = xElement.Element("startingYear");
            _GameStartAbsTick = xElement.Element("gameStartAbsTick");
        }


    }
}
