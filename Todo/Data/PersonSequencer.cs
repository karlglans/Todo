using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Data
{
    public class PersonSequencer
    {
        static private int personId;

        public static int NextPersonId()
        {
            return ++personId;
        }

        public static void Reset()
        {
            personId = 0;
        }
    }
}
