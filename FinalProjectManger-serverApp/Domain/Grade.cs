using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grade
    {
        public int ID;
        public string Description { get; set; }
        //public int GradeCollectionId { get; set; }
        public int Score { get; set; }
        public double Precentage { get; set; }
        public string Name { get; set; }

        public Grade()
        {
            ID = new Random().Next();
        }

        public Grade(string description, int score, double precentage, string name)
        {
            //GradeCollectionId = 1;
            ID = new Random().Next();
            Description = description;
            Score = score;
            Precentage = precentage;
            Name = name;
        }
        
        public Grade(double precentage, string name)
        {
            //GradeCollectionId = 1;
            ID = new Random().Next();
            Precentage = precentage;
            Name = name;
            Score = 0;
            Description = "";
        }

        public void UpdateScoreAndDescription(int score, string des)
        {
            Score = score;
            Description = des;
        }


    }



}
