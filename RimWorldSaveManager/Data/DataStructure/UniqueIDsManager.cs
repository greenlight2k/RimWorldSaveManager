using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class UniqueIDsManager
    {

        private XElement uniqueIDsManager;

        public UniqueIDsManager(XElement element)
        {
            uniqueIDsManager = element;
        }
        public int getNextThingID()
        {
            return getNextId("nextThingID");
        }
        public int getNextBillID()
        {
            return getNextId("nextBillID");
        }
        public int getNextFactionID()
        {
            return getNextId("nextFactionID");
        }
        public int getNextLordID()
        {
            return getNextId("nextLordID");
        }
        public int getNextTaleID()
        {
            return getNextId("nextTaleID");
        }
        public int getNextPassingShipID()
        {
            return getNextId("nextPassingShipID");
        }
        public int getNextWorldObjectID()
        {
            return getNextId("nextWorldObjectID");
        }
        public int getNextMapID()
        {
            return getNextId("nextMapID");
        }
        public int getNextCaravanID()
        {
            return getNextId("nextCaravanID");
        }
        public int getNextAreaID()
        {
            return getNextId("nextAreaID");
        }
        public int getNextAncientCryptosleepCasketGroupID()
        {
            return getNextId("nextAncientCryptosleepCasketGroupID");
        }
        public int getNextJobID()
        {
            return getNextId("nextJobID");
        }
        public int getNextSignalTagID()
        {
            return getNextId("nextSignalTagID");
        }
        public int getNextWorldFeatureID()
        {
            return getNextId("nextWorldFeatureID");
        }
        public int getNextHediffID()
        {
            return getNextId("nextHediffID");
        }
        public int getNextBattleID()
        {
            return getNextId("nextBattleID");
        }
        public int getNextLogID()
        {
            return getNextId("nextLogID");
        }
        public int getNextLetterID()
        {
            return getNextId("nextLetterID");
        }
        public int getNextArchivedDialogID()
        {
            return getNextId("nextArchivedDialogID");
        }
        public int getNextMessageID()
        {
            return getNextId("nextMessageID");
        }
        public int getNextZoneID()
        {
            return getNextId("nextZoneID");
        }


        private int getNextId(string elementName)
        {

            int nextID = int.Parse(uniqueIDsManager.Element(elementName).GetValue());
            uniqueIDsManager.Element(elementName).SetValue(nextID + 1);
            return nextID;

        }
    }
}
