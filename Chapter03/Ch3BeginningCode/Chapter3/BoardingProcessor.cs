﻿using Packt.CloudySkiesAir.Chapter3;
using System.Linq;

public class BoardingProcessor {

  public int CurrentBoardingGroup { get; set; } = 2;
  public BoardingStatus Status { get; set; }

  private int[] _priorityLaneGroups = new[] {
    1,
    2
  };

  public void DisplayBoardingStatus(List<Passenger> passengers, bool? hasBoarded = null) {
    List<Passenger> filteredPassengers = new();
    for (int i = 0; i < passengers.Count; i++) {
      Passenger p = passengers[i];
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

    if (Status == BoardingStatus.PlaneDeparted) {
      return "Flight Departed";
    }

    bool isBoarding = Status == BoardingStatus.Boarding;
    if (isBoarding) {
      if (isMilitary || needsHelp) {
        return "Board Now via Priority Lane";
      }

      if (CurrentBoardingGroup < group) {
        return "Please Wait";
      }

      if (_priorityLaneGroups.Contains(group)) {
        return "Board Now via Priority Lane";
      }

      return "Board Now";

    }

    return "Boarding Not Started";
  }

}