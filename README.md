# RouletteSimulator
A simulation of the roulette casino game. Based on the French single-zero wheel game type. Implemented in C# .NET WPF, using the Prism framework.

The application is made up of 4 modules:
* Dealer:
  - Spins the wheel.
  - Announces the winning number.
  - Displays the last 10 winning numbers.
* Wheel:
  - Simulates a roulette wheel.
  - The wheel spins and the ball is dropped.
  - The ball lands on a random number.
* Board:
  - Allows bets to be placed, by placing chips.
* Player:
  - Can select the type of chip to place on the board.
  - Can clear all chips from the board.

The winning number is chosen using the **Random** class from C# .NET.

![alt text](https://github.com/prbasha/RouletteSimulator/blob/master/RouletteSimulator/Documentation/screen_shot.PNG)
