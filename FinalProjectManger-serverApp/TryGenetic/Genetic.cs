
namespace TryGenetic
{
    public class Solution
    {
        public List<Gene> genes= new List<Gene>();
        public double fitnessScore = 0;
        public Solution(List<Gene> genes)
        {
            this.genes = genes;
        }
        public Solution()
        {

        }
    }
    public class Gene
    {
        public int SessionNum { get; set; }
        public Lecturer Lec3 { get; set; }
        public Lecturer Lec2 { get; set; }
        public Lecturer Lec1 { get; set; }
 
        public bool AddLec(int LecIndex, Lecturer Lec)
        {
            if(LecIndex == 1)
                Lec1 = Lec;
            else if (LecIndex == 2)
            {
                if(Lec.id != Lec1.id)  
                    Lec2 = Lec;
                else
                    return false;
            }
            else if (LecIndex == 3)
            {
                if (Lec.id != Lec1.id && Lec.id != Lec2.id)
                    Lec3 = Lec;
                else
                    return false;
            }
            return true;
        }
    }
    public class Genetic
    {
        public int popSize = 1000;
        public int numOfSessions = 40;
        public List<Solution> Solutions { get; set; } = new List<Solution>();
        public int numOfBestSolutions = 100;
        public double Treshold = 0.1;
        public int lecNumbers { get; set; }

        public void CreatePopulation(List<TryGenetic.Lecturer> lecturers)
        {
            for (int j = 0; j < popSize; j++)
            {
                var geneList = new List<Gene>();
                for (int i = 0; i < numOfSessions; i++)
                {
                    //create 1 gene
                    var gene = new Gene();
                    gene.SessionNum = i + 1;
                    while (!(gene.AddLec(1, lecturers[new Random().Next(lecturers.Count)]))) ;
                    while (!(gene.AddLec(2, lecturers[new Random().Next(lecturers.Count)]))) ;
                    while (!(gene.AddLec(3, lecturers[new Random().Next(lecturers.Count)]))) ;
                    geneList.Add(gene);
                }
                Solution solution = new Solution();
                solution.genes = geneList;
                Solutions.Add(solution);
            }
            lecNumbers = lecturers.Count;
        }
        public double genFit(Gene gene)
        {
            int totalMatch = 0;
            if (!(gene.Lec1.constraints.Contains(gene.SessionNum)))
                totalMatch++;
            if (!(gene.Lec2.constraints.Contains(gene.SessionNum)))
                totalMatch++;
            if (!(gene.Lec3.constraints.Contains(gene.SessionNum)))
                totalMatch++;
            return totalMatch / 3;
        }

        public void Fitness(Solution Solution)
        {
            double SumEachGenFit = 0;
            var LecturerMappingCounter = new Dictionary<Lecturer,int>();
            foreach (var gene in Solution.genes)
            {
                SumEachGenFit += genFit(gene);

                if (LecturerMappingCounter.ContainsKey(gene.Lec1))
                     LecturerMappingCounter[gene.Lec1]++;
                else
                    LecturerMappingCounter.Add(gene.Lec1, 1);
                if (LecturerMappingCounter.ContainsKey(gene.Lec2))
                    LecturerMappingCounter[gene.Lec2]++;
                else
                    LecturerMappingCounter.Add(gene.Lec2, 1);
                if (LecturerMappingCounter.ContainsKey(gene.Lec3))
                    LecturerMappingCounter[gene.Lec3]++;
                else
                    LecturerMappingCounter.Add(gene.Lec3, 1);
            }
            Solution.fitnessScore = 8 * (SumEachGenFit / Solution.genes.Count) + (LecturerMappingCounter.Count / lecNumbers) * 2;
        }


        public void Selection()
        {
            Solutions.Sort((x, y) => x.fitnessScore.CompareTo(y.fitnessScore));
            Solutions.Reverse();

        }
        public void CrossOver()
        {
            var BetterSolutions = new List<Solution>();
            var BestSolutions = Solutions.Take(numOfBestSolutions).ToList();
            for (int j = 0; j < popSize; j++)
            {
                // Create specific solution
                var geneList = new List<Gene>();
                for (int i = 0; i < numOfSessions; i++)
                {
                    // Create new Gene
                    var gene = new Gene();
                    gene.SessionNum = i + 1;

                    for (int z = 0; z < 3; z++)
                    {
                        var randSolutionIndex = new Random().Next(numOfBestSolutions);
                        var randLecIndex = new Random().Next(1,4);
                        Lecturer LecTemp;
                        if (randLecIndex == 1)
                            LecTemp = BestSolutions[randSolutionIndex].genes[i].Lec1;
                        else if (randLecIndex == 2)
                            LecTemp = BestSolutions[randSolutionIndex].genes[i].Lec2;
                        else
                            LecTemp = BestSolutions[randSolutionIndex].genes[i].Lec3;
                        if (gene.AddLec(z + 1, LecTemp) == false)
                            z--;
                    }

                    geneList.Add(gene);
                }

                var BetterSolution = new Solution();
                BetterSolution.genes = geneList;
                BetterSolutions.Add(BetterSolution);
            }
            Solutions = BetterSolutions;
        }
    }
}
