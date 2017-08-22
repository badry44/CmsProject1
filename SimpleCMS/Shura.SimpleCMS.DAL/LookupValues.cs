using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shura.SimpleCMS.DAL
{
    public class LookupValues
    {
        /// <summary>
        /// 
        /// </summary>
        public enum Status
        {
            Active =1,
            Inactive=2,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PageType
        {
            StartPage =3,
            NormalPage = 4,
            GalleryPage = 5,
        }
    }
}
