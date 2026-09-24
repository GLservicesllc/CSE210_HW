using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Electrical Engineer" ;
        job1._company = "Electric Co" ;
        job1._startYear = 2026 ;
        job1._endYear = 2028 ;

        Job job2 = new Job();
        job2._jobTitle = "Owner" ;
        job2._company = "G&L Services" ;
        job2._startYear = 2018 ;
        job2._endYear = 2022 ;

        Resume myResume = new Resume();
        myResume._name = "Logan Brizzee";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}