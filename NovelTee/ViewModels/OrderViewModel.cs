using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelTee.Models;

namespace NovelTee.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public State State { get; set; }
    }

    public enum State
    {
        AL,AK,AZ,AR,CA,CO,CT,DE,DC,FL,GA,HI,ID,IL,IN,IA,KS,KY,LA,ME,MD,MA,MI,MS,MO,MT,NE,NV,
        NH,NJ,NY,NC,ND,OH,OK,PA,PR,RI,SC,SD,TN,TX,UT,VT,VA,WA,WV,WI,WY
    }
}