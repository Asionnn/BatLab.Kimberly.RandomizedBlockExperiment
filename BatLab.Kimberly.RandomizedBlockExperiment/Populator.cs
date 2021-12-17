﻿using System;
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
                new Pattern { BlockNumber = "1.1.1", Warning="Left Turn", SeatLocation = "Belt", TactorSequence = "2->3->4", Counter = 3 },
                new Pattern { BlockNumber = "1.1.2", Warning="Left Turn", SeatLocation = "Back", TactorSequence = "6->9->12", Counter = 3 },
                new Pattern { BlockNumber = "1.2.1", Warning="Right Turn", SeatLocation = "Belt", TactorSequence = "4->3->2", Counter = 3 },
                new Pattern { BlockNumber = "1.2.2", Warning="Right Turn", SeatLocation = "Back", TactorSequence = "12->9->6", Counter = 3 },
                new Pattern { BlockNumber = "1.3.1", Warning="U Turn", SeatLocation = "Belt", TactorSequence = "3->4->12" , Counter = 3},
                new Pattern { BlockNumber = "1.3.2", Warning="U Turn", SeatLocation = "Pan", TactorSequence = "15->18->19" , Counter = 3},
                new Pattern { BlockNumber = "1.4.1", Warning="Speed Up", SeatLocation = "Belt", TactorSequence = "2,4", IsSimultaneous = true , Counter = 3},
                new Pattern { BlockNumber = "1.4.2", Warning="Speed Up", SeatLocation = "Pan", TactorSequence = "15,18", IsSimultaneous = true , Counter = 3},
                new Pattern { BlockNumber = "1.5.1", Warning="Slow Down", SeatLocation = "Back", TactorSequence = "6,12", IsSimultaneous = true , Counter = 3},
                new Pattern { BlockNumber = "1.5.2", Warning="Left Turn", SeatLocation = "Pan", TactorSequence = "17,20", IsSimultaneous = true , Counter = 3},

                new Pattern { BlockNumber = "2.1.1", Warning="Left Turn", SeatLocation = "Belt", TactorSequence = "2->3->4", Counter = 3 },
                new Pattern { BlockNumber = "2.1.2", Warning="Left Turn", SeatLocation = "Back", TactorSequence = "6->9->12", Counter = 3 },
                new Pattern { BlockNumber = "2.2.1", Warning="Right Turn", SeatLocation = "Belt", TactorSequence = "4->3->2", Counter = 3 },
                new Pattern { BlockNumber = "2.2.2", Warning="Right Turn", SeatLocation = "Back", TactorSequence = "12->9->6", Counter = 3 },
                new Pattern { BlockNumber = "2.3.1", Warning="U Turn", SeatLocation = "Belt", TactorSequence = "3->4->12" , Counter = 3},
                new Pattern { BlockNumber = "2.3.2", Warning="U Turn", SeatLocation = "Pan", TactorSequence = "15->18->19" , Counter = 3},
                new Pattern { BlockNumber = "2.4.1", Warning="Speed Up", SeatLocation = "Belt", TactorSequence = "2,4", IsSimultaneous = true , Counter = 3},
                new Pattern { BlockNumber = "2.4.2", Warning="Speed Up", SeatLocation = "Pan", TactorSequence = "15,18", IsSimultaneous = true , Counter = 3},
                new Pattern { BlockNumber = "2.5.1", Warning="Slow Down", SeatLocation = "Back", TactorSequence = "6,12", IsSimultaneous = true , Counter = 3},
                new Pattern { BlockNumber = "2.5.2", Warning="Left Turn", SeatLocation = "Pan", TactorSequence = "17,20", IsSimultaneous = true , Counter = 3},

                new Pattern { BlockNumber="3.6.1", Warning="Back Left", SeatLocation="Back", TactorSequence="12->13->14", Counter=3 },
                new Pattern { BlockNumber="3.6.2", Warning="Back", SeatLocation="Back", TactorSequence="9->10->11", Counter=3 },
                new Pattern { BlockNumber="3.6.3", Warning="Back Right", SeatLocation="Back", TactorSequence="6->7->8", Counter=3 },
                new Pattern { BlockNumber="3.7.1", Warning="Pan back-to-front", SeatLocation="Pan(Left)", TactorSequence="20->19->18", Counter=3 },
                new Pattern { BlockNumber="3.7.2", Warning="Pan back-to-front", SeatLocation="Pan(Right)", TactorSequence="17->16->15", Counter=3 },
                new Pattern { BlockNumber="3.8.1", Warning="Speeding", SeatLocation="Back", TactorSequence="7,13", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="3.8.2", Warning="Speeding", SeatLocation="Pan", TactorSequence="16,19", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="3.9.1", Warning="Forward Collision", SeatLocation="Belt", TactorSequence="3", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="3.10.1", Warning="Left", SeatLocation="Belt", TactorSequence="1->2->3->4->5", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="3.10.2", Warning="Right", SeatLocation="Belt", TactorSequence="5->4->3->2->1", IsSimultaneous=true, Counter=3 },

                new Pattern { BlockNumber="4.6.1", Warning="Back Left", SeatLocation="Back", TactorSequence="12->13->14", Counter=3 },
                new Pattern { BlockNumber="4.6.2", Warning="Back", SeatLocation="Back", TactorSequence="9->10->11", Counter=3 },
                new Pattern { BlockNumber="4.6.3", Warning="Back Right", SeatLocation="Back", TactorSequence="6->7->8", Counter=3 },
                new Pattern { BlockNumber="4.7.1", Warning="Pan back-to-front", SeatLocation="Pan(Left)", TactorSequence="20->19->18", Counter=3 },
                new Pattern { BlockNumber="4.7.2", Warning="Pan back-to-front", SeatLocation="Pan(Right)", TactorSequence="17->16->15", Counter=3 },
                new Pattern { BlockNumber="4.8.1", Warning="Speeding", SeatLocation="Back", TactorSequence="7,13", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="4.8.2", Warning="Speeding", SeatLocation="Pan", TactorSequence="16,19", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="4.9.1", Warning="Forward Collision", SeatLocation="Belt", TactorSequence="3", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="4.10.1", Warning="Left", SeatLocation="Belt", TactorSequence="1->2->3->4->5", IsSimultaneous=true, Counter=3 },
                new Pattern { BlockNumber="4.10.2", Warning="Right", SeatLocation="Belt", TactorSequence="5->4->3->2->1", IsSimultaneous=true, Counter=3 }
            };
        }
    }
}
