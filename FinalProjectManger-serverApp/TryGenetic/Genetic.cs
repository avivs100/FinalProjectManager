
namespace TryGenetic
{
    public class Solution
    {
        public List<Gene> Genes = new();
        public double FitnessScore;
        public Solution(List<Gene> genes)
        {
            Genes = genes;
        }
        public Solution()
        {

        }
    }
    public class Gene
    {
        public int SessionNum { get; set; }
        public Lecturer Lec3 { get; set; } = null!;
        public Lecturer Lec2 { get; set; } = null!;
        public Lecturer Lec1 { get; set; } = null!;

        public bool AddLec(int lecIndex, Lecturer lec)
        {
            switch (lecIndex)
            {
                case 1:
                    Lec1 = lec;
                    break;
                case 2 when lec.id != Lec1.id:
                    Lec2 = lec;
                    break;
                case 2:
                    return false;
                case 3 when lec.id != Lec1.id && lec.id != Lec2.id:
                    Lec3 = lec;
                    break;
                case 3:
                    return false;
            }

            return true;
        }
    }
    public class Genetic
    {
        public const int PopSize = 1000;
        public const int NumOfSessions = 12;
        public List<Solution> Solutions { get; set; } = new();
        public const int NumOfBestSolutions = 100;
        public double Treshold = 0.1;
        public int LecNumbers { get; set; }

        public void CreatePopulation(List<TryGenetic.Lecturer> lecturers)
        {
            for (var j = 0; j < PopSize; j++)
            {
                var geneList = new List<Gene>();
                for (var i = 0; i < NumOfSessions; i++)
                {
                    //create 1 gene
                    var gene = new Gene
                    {
                        SessionNum = i + 1
                    };
                    while (!(gene.AddLec(1, lecturers[new Random().Next(lecturers.Count)]))) { }
                    while (!(gene.AddLec(2, lecturers[new Random().Next(lecturers.Count)]))) { }
                    while (!(gene.AddLec(3, lecturers[new Random().Next(lecturers.Count)]))) { }
                    geneList.Add(gene);
                }
                var solution = new Solution { Genes = geneList };
                Solutions.Add(solution);
            }
            LecNumbers = lecturers.Count;
        }
        public double GenFit(Gene gene)
        {
            var totalMatch = 0;
            if (!(gene.Lec1.constraints.Contains(gene.SessionNum)))
                totalMatch++;
            if (!(gene.Lec2.constraints.Contains(gene.SessionNum)))
                totalMatch++;
            if (!(gene.Lec3.constraints.Contains(gene.SessionNum)))
                totalMatch++;
            return totalMatch / 3;
        }

        public void Fitness(Solution solution)
        {
            double sumEachGenFit = 0;
            var lecturerMappingCounter = new Dictionary<Lecturer, int>();
            foreach (var gene in solution.Genes)
            {
                sumEachGenFit += GenFit(gene);

                if (lecturerMappingCounter.ContainsKey(gene.Lec1))
                    lecturerMappingCounter[gene.Lec1]++;
                else
                    lecturerMappingCounter.Add(gene.Lec1, 1);
                if (lecturerMappingCounter.ContainsKey(gene.Lec2))
                    lecturerMappingCounter[gene.Lec2]++;
                else
                    lecturerMappingCounter.Add(gene.Lec2, 1);
                if (lecturerMappingCounter.ContainsKey(gene.Lec3))
                    lecturerMappingCounter[gene.Lec3]++;
                else
                    lecturerMappingCounter.Add(gene.Lec3, 1);
            }
            solution.FitnessScore = 8 * (sumEachGenFit / solution.Genes.Count) + (lecturerMappingCounter.Count / LecNumbers) * 2;
        }


        public void Selection()
        {
            Solutions.Sort((x, y) => x.FitnessScore.CompareTo(y.FitnessScore));
            Solutions.Reverse();


        }
        public void CrossOver()
        {

            var betterSolutions = new List<Solution>();
            var bestSolutions = Solutions.Take(NumOfBestSolutions).ToList();
            for (var j = 0; j < PopSize; j++)
            {
                // Create specific solution
                var geneList = new List<Gene>();
                for (var i = 0; i < NumOfSessions; i++)
                {
                    // Create new Gene
                    var gene = new Gene
                    {
                        SessionNum = i + 1
                    };

                    for (var z = 0; z < 3; z++)
                    {
                        var randSolutionIndex = new Random().Next(NumOfBestSolutions);
                        var randLecIndex = new Random().Next(1, 4);
                        var lecTemp = randLecIndex switch
                        {
                            1 => bestSolutions[randSolutionIndex].Genes[i].Lec1,
                            2 => bestSolutions[randSolutionIndex].Genes[i].Lec2,
                            _ => bestSolutions[randSolutionIndex].Genes[i].Lec3
                        };
                        if (gene.AddLec(z + 1, lecTemp) == false)
                            z--;
                    }

                    geneList.Add(gene);
                }

                var betterSolution = new Solution
                {
                    Genes = geneList
                };
                betterSolutions.Add(betterSolution);
            }
            Solutions = betterSolutions;
        }
    }
}
