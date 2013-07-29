using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class WinningBid
    {
       public int winningBidId { get; set; }
       public WinningBid(int WinningBidID)
       {
           winningBidId = WinningBidID;
       }

    }
}
