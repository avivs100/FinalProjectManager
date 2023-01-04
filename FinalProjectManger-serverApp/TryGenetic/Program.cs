
using TryGenetic;

var genetic = new Genetic();
var lecturers = new List<Lecturer>();
const int lecNum = 8;
const int conNum = 6;
for (var i = 0; i < lecNum; i++)
{
    var con = new List<int>();
    for (var j = 0; j < conNum; j++)
        con.Add(new Random().Next(1, 13));
    lecturers.Add(new Lecturer(i + 1, con));
}
genetic.CreatePopulation(lecturers);


for (var i = 0; i < 1000; i++)
{
    foreach (var t in genetic.Solutions)
    {
        genetic.Fitness(t);
    }
    genetic.Selection();
    System.Diagnostics.Debug.WriteLine("index: " + i + " Score: " + genetic.Solutions[0].FitnessScore); 
    if (genetic.Solutions[0].FitnessScore >= 10 - 10 * genetic.Treshold)
        break;
    genetic.CrossOver();
    
}
