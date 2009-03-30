using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    [Flags]
    public enum TribePermission
    {
        Untribe = 0x00,
        Member = 0x01,
        CanInvite = 0x02,
        DiplomacyInteract = 0x04,
        DismissPlayer = 0x08,
        ChangeTribeDescription = 0x10,
        DisbandTribe = 0x20,
        SetMemberPrivilage = 0x40,
        SetDuke = 0x80,
        Inviter = CanInvite,
        DiplomateOfficer = DiplomacyInteract | Inviter,
        Baron = DiplomateOfficer | ChangeTribeDescription | SetMemberPrivilage,
        Duke = Baron | DisbandTribe | SetDuke
    }
}
