
using TryGenetic;

Genetic genetic = new Genetic();
var lecturers = new List<Lecturer>();
var projects = new List<Project>();
int lecNum = 20;
int conNum = 6;
int projNum = 50;
for (int i = 0; i < lecNum; i++)
{
    var con = new List<int>();
    for (int j = 0; j < conNum; j++)
        con.Add(new Random().Next(1, genetic.numOfSessions+1));
    lecturers.Add(new Lecturer(i + 1, con));
}

for (int i = 0; i < projNum; i++)
{
    projects.Add(new Project(i, lecturers[new Random().Next(lecNum)].id));
}
genetic.CreatePopulation(lecturers, projects);


for (int i = 0; i < 1000; i++)
{
    for (int j = 0; j < genetic.Solutions.Count; j++)
    {
        genetic.Fitness(genetic.Solutions[j]);
    }
    genetic.Selection();
    System.Diagnostics.Debug.WriteLine("index: " + i + " Score: " + genetic.Solutions[0].fitnessScore); 
    if (genetic.Solutions[0].fitnessScore >= 10 - 10 * genetic.Treshold)
        break;
    genetic.CrossOver();
}
var bestSolution = genetic.Solutions[0];
Console.WriteLine();
