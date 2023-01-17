using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Session;

namespace Domain
{
    public class ClassSessions
    {
        public int Id { get; set; }
        public int Session1Id { get; set; }
        public int Session2Id { get; set; }
        public int Session3Id { get; set; }
        public int Session4Id { get; set; }
        public int Session5Id { get; set; }
        public string ClassName { get; set; }

        public ClassSessions()
        {
            Id = new Random().Next();
        }

        public ClassSessions(int session1, int session2, int session3, int session4, string className)
        {
            Id = new Random().Next();
            Session1Id = session1;
            Session2Id = session2;
            Session3Id = session3;
            Session4Id = session4;
            ClassName = className;
        }
    }



    public class ClassSessionsFull
    {
        public int id { get; set; }
        public SessionFull Session1 { get; set; }
        public SessionFull Session2 { get; set; }
        public SessionFull Session3 { get; set; }
        public SessionFull Session4 { get; set; }
        public SessionFull Session5 { get; set; }
        public string ClassName { get; set; }

        public ClassSessionsFull()
        {
            id = new Random().Next();
        }

        public ClassSessionsFull(SessionFull session1, SessionFull session2, SessionFull session3, SessionFull session4, string className)
        {
            id = new Random().Next();
            Session1 = session1;
            Session2 = session2;
            Session3 = session3;
            Session4 = session4;
            ClassName = className;
        }
    }


}
