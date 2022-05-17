using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.FaceRecognition
{
    public enum ReconizerResultOption
    {
        NoFace,
        RecognizedFace,
        NotRecognizedFace
    }

    public class ReconizerResult
    {
        public ReconizerResultOption ResultOption { get; set; }
        public int ChildId { get; set; }
    }
}
