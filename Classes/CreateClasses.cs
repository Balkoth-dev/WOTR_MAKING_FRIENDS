using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.Classes.EidolonClasses;

namespace WOTR_MAKING_FRIENDS.Classes
{
    internal class CreateClasses
    {
        public static void CreateAllClasses()
        {
            EidolonBaseClass.CreateEidolonBaseClass();
            CreateAllEidolonClasses.Create();
        }
    }
}
