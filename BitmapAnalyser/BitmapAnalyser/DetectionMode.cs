using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapAnalyser
{
    public enum DetectionMode
    {
        /// <summary>
        /// Any point of the source image will be checked.
        /// </summary>
        Full = 1,
        /// <summary>
        /// Only second point/row of the source image will be checked.
        /// </summary>
        Rare2 = 2,
        /// <summary>
        /// Only fourth point/row of the source image will be checked.
        /// </summary>
        Rare4 = 4,
        /// <summary>
        /// Only eighth point/row of the source image will be checked.
        /// </summary>
        Rare8 = 8,
        /// <summary>
        /// Each third point/row of the source image will be checked. If a match will be found, 8 surrounding points will be checked.
        /// </summary>
        Group3 = 3,
        /// <summary>
        /// Each fifth point/row of the source image will be checked. If a match will be found, 24 surrounding points will be checked.
        /// </summary>
        Group5 = 5,
    }
}
