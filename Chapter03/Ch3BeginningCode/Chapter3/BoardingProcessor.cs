using Packt.CloudySkiesAir.Chapter3;

public class BoardingProcessor {

  public int CurrentBoardingGroup { get; set; } = 2;
  public BoardingStatus Status { get; set; }

  private int[] _priorityLaneGroups = new[] {
    1,
    2
  };

  public void DisplayBoardingStatus(List<Passenger> passengers, bool? hasBoarded = null) {
    List<Passenger> filteredPassengers = new();
    foreach (var p in passengers)
    {
      if (!hasBoarded.HasValue || p.HasBoarded == hasBoarded) {
        filteredPassengers.Add(p);
      }
    }

    DisplayBoardingHeader();

    foreach (Passenger passenger in filteredPassengers) {
      string statusMessage = passenger.HasBoarded
        ? "Onboard"
        : CanPassengerBoard(passenger);

      Console.WriteLine($"{passenger.FullName,-23} Group {passenger.BoardingGroup}: {statusMessage}");
    }
  }

  private void DisplayBoardingHeader() {
    switch (Status) {
      case BoardingStatus.NotStarted:
        Console.WriteLine("Boarding is closed and the plane has departed.");
        break;

      case BoardingStatus.Boarding:
        if (_priorityLaneGroups.Contains(CurrentBoardingGroup)) {
          Console.WriteLine($"Priority Boarding Group {CurrentBoardingGroup}");
        } else {
          Console.WriteLine($"Boarding Group {CurrentBoardingGroup}");
        }

        break;

      case BoardingStatus.PlaneDeparted:
        Console.WriteLine("Boarding is closed and the plane has departed.");
        break;

      default:
        Console.WriteLine($"Unknown Boarding Status: {Status}");
        break;
    }

    Console.WriteLine();
  }

  public string CanPassengerBoard(Passenger passenger) {
    bool isMilitary = passenger.IsMilitary;
    bool needsHelp = passenger.NeedsHelp;
    int group = passenger.BoardingGroup;

    return Status switch {
      BoardingStatus.PlaneDeparted => "Flight Departed",
      BoardingStatus.Boarding when isMilitary || needsHelp => "Board Now via Priority Lane",
      BoardingStatus.Boarding when CurrentBoardingGroup < group => "Please Wait",
      BoardingStatus.Boarding => _priorityLaneGroups.Contains(group) ? "Board Now via Priority Lane" : "Board Now",
      _ => "Boarding Not Started"
    };

  }

}