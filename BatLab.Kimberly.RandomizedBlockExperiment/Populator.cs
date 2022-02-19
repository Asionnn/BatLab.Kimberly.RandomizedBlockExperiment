using System;
using System.Collections.Generic;
using System.Text;

namespace BatLab.Kimberly.RandomizedBlockExperiment
{
    public class Populator
    {
        public static Pattern[] SetupPatterns()
        {
           return new Pattern[]
            {
                new Pattern { BlockNumber = "1.1.1", Warning="Left Turn", SeatLocation = "Belt", TactorSequence = "2->3->4", Counter = 3 , Sort = 1 },
                new Pattern { BlockNumber = "1.1.2", Warning="Left Turn", SeatLocation = "Back", TactorSequence = "6->9->12", Counter = 3, Sort = 2 },
                new Pattern { BlockNumber = "1.2.1", Warning="Right Turn", SeatLocation = "Belt", TactorSequence = "4->3->2", Counter = 3, Sort = 3 },
                new Pattern { BlockNumber = "1.2.2", Warning="Right Turn", SeatLocation = "Back", TactorSequence = "12->9->6", Counter = 3, Sort = 4 },
                new Pattern { BlockNumber = "1.3.1", Warning="U Turn", SeatLocation = "Belt", TactorSequence = "3->4->12" , Counter = 3, Sort = 5 },
                new Pattern { BlockNumber = "1.3.2", Warning="U Turn", SeatLocation = "Pan", TactorSequence = "15->18(10)->19(11)" , Counter = 3, Sort = 6 },
                new Pattern { BlockNumber = "1.4.1", Warning="Speed Up", SeatLocation = "Belt", TactorSequence = "2,4", IsSimultaneous = true , Counter = 3, Sort = 7 },
                new Pattern { BlockNumber = "1.4.2", Warning="Speed Up", SeatLocation = "Pan", TactorSequence = "15,18(10)", IsSimultaneous = true , Counter = 3, Sort = 8 },
                new Pattern { BlockNumber = "1.5.1", Warning="Slow Down", SeatLocation = "Back", TactorSequence = "6,12", IsSimultaneous = true , Counter = 3, Sort = 9 },
                new Pattern { BlockNumber = "1.5.2", Warning="Slow Down", SeatLocation = "Pan", TactorSequence = "17(8),20(14)", IsSimultaneous = true , Counter = 3, Sort = 10 },

                new Pattern { BlockNumber = "2.1.1", Warning="Left Turn", SeatLocation = "Belt", TactorSequence = "2->3->4", Counter = 3, Sort = 11 },
                new Pattern { BlockNumber = "2.1.2", Warning="Left Turn", SeatLocation = "Back", TactorSequence = "6->9->12", Counter = 3, Sort = 12 },
                new Pattern { BlockNumber = "2.2.1", Warning="Right Turn", SeatLocation = "Belt", TactorSequence = "4->3->2", Counter = 3, Sort = 13},
                new Pattern { BlockNumber = "2.2.2", Warning="Right Turn", SeatLocation = "Back", TactorSequence = "12->9->6", Counter = 3, Sort = 14 },
                new Pattern { BlockNumber = "2.3.1", Warning="U Turn", SeatLocation = "Belt", TactorSequence = "3->4->12" , Counter = 3, Sort = 15 },
                new Pattern { BlockNumber = "2.3.2", Warning="U Turn", SeatLocation = "Pan", TactorSequence = "15->18(10)->19(11)" , Counter = 3, Sort = 16 },
                new Pattern { BlockNumber = "2.4.1", Warning="Speed Up", SeatLocation = "Belt", TactorSequence = "2,4", IsSimultaneous = true , Counter = 3, Sort = 8 },
                new Pattern { BlockNumber = "2.4.2", Warning="Speed Up", SeatLocation = "Pan", TactorSequence = "15,18(10)", IsSimultaneous = true , Counter = 3, Sort = 10 },
                new Pattern { BlockNumber = "2.5.1", Warning="Slow Down", SeatLocation = "Back", TactorSequence = "6,12", IsSimultaneous = true , Counter = 3, Sort = 11 },
                new Pattern { BlockNumber = "2.5.2", Warning="Slow Down", SeatLocation = "Pan", TactorSequence = "17(8),20(14)", IsSimultaneous = true , Counter = 3, Sort = 14 },

                new Pattern { BlockNumber="3.6.1", Warning="Back Left", SeatLocation="Back", TactorSequence="12->13->14", Counter = 3, Sort = 21 },
                new Pattern { BlockNumber="3.6.2", Warning="Back", SeatLocation="Back", TactorSequence="9->10->11", Counter = 3, Sort = 22 },
                new Pattern { BlockNumber="3.6.3", Warning="Back Right", SeatLocation="Back", TactorSequence="6->7->8", Counter = 3, Sort = 23 },
                new Pattern { BlockNumber="3.7.1", Warning="Pan back-to-front", SeatLocation="Pan(Left)", TactorSequence="20(14)->19(11)->18(10)", Counter = 3, Sort = 24 },
                new Pattern { BlockNumber="3.7.2", Warning="Pan back-to-front", SeatLocation="Pan(Right)", TactorSequence="17(8)->16->15", Counter = 3, Sort = 25 },
                new Pattern { BlockNumber="3.8.1", Warning="Speeding", SeatLocation="Back", TactorSequence="7,13", IsSimultaneous=true, Counter = 3, Sort = 26 },
                new Pattern { BlockNumber="3.8.2", Warning="Speeding", SeatLocation="Pan", TactorSequence="16,19(11)", IsSimultaneous=true, Counter = 3, Sort = 27 },
                new Pattern { BlockNumber="3.9.1", Warning="Forward Collision", SeatLocation="Belt", TactorSequence="3", IsSimultaneous=true, Counter = 3, Sort = 28 },
                new Pattern { BlockNumber="3.10.1", Warning="Left", SeatLocation="Belt", TactorSequence="1->2->3->4->5", IsSimultaneous=true, Counter = 3, Sort = 29 },
                new Pattern { BlockNumber="3.10.2", Warning="Right", SeatLocation="Belt", TactorSequence="5->4->3->2->1", IsSimultaneous=true, Counter = 3, Sort = 30 },

                new Pattern { BlockNumber="4.6.1", Warning="Back Left", SeatLocation="Back", TactorSequence="12->13->14", Counter = 3, Sort = 31 },
                new Pattern { BlockNumber="4.6.2", Warning="Back", SeatLocation="Back", TactorSequence="9->10->11", Counter = 3, Sort = 32 },
                new Pattern { BlockNumber="4.6.3", Warning="Back Right", SeatLocation="Back", TactorSequence="6->7->8", Counter = 3, Sort = 33 },
                new Pattern { BlockNumber="4.7.1", Warning="Pan back-to-front", SeatLocation="Pan(Left)", TactorSequence="20(14)->19(11)->18(10)", Counter = 3, Sort = 34 },
                new Pattern { BlockNumber="4.7.2", Warning="Pan back-to-front", SeatLocation="Pan(Right)", TactorSequence="17(8)->16->15", Counter = 3, Sort = 35 },
                new Pattern { BlockNumber="4.8.1", Warning="Speeding", SeatLocation="Back", TactorSequence="7,13", IsSimultaneous=true, Counter = 3, Sort = 36 },
                new Pattern { BlockNumber="4.8.2", Warning="Speeding", SeatLocation="Pan", TactorSequence="16,19(11)", IsSimultaneous=true, Counter = 3, Sort = 37 },
                new Pattern { BlockNumber="4.9.1", Warning="Forward Collision", SeatLocation="Belt", TactorSequence="3", IsSimultaneous=true, Counter = 3, Sort = 38 },
                new Pattern { BlockNumber="4.10.1", Warning="Left", SeatLocation="Belt", TactorSequence="1->2->3->4->5", IsSimultaneous=true, Counter = 3, Sort = 39 },
                new Pattern { BlockNumber="4.10.2", Warning="Right", SeatLocation="Belt", TactorSequence="5->4->3->2->1", IsSimultaneous=true, Counter = 3, Sort = 40 }
            };
        }
    }
}
