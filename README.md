# Project Blackout Server

This is a private server project for the classic FPS game, Point Blank. This repository contains the server-side source code, database scripts, and tools necessary to run a custom server.

## About The Project

The goal of this project is to provide a fully functional and customizable server environment for the game Point Blank. It is intended for private use, educational purposes, and community-driven development.

### Core Features

* **Authentication & Game Servers**: Handles player logins, character data, and real-time gameplay.
* **Database Integration**: Stores player stats, items, inventory, and account information.
* **Customizable Game Mechanics**: Easily modify EXP rates, in-game currency gain (Points), and other game parameters.
* **Community Features**: Supports in-game chat, room creation, and basic clan systems.

---

## Getting Started

### Prerequisites

To build and run this server, you'll need the following software installed:

* **Microsoft Visual Studio**: Required for compiling the C++/C# source code.
* **PostgreSQL**: The primary database used to store all game data.
* **.NET Framework**: For certain server components.

### Installation

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/dekthaiinchina/ProjectBlackoutServerV324.git
    ```

2.  **Set up the database**:
    * Create a new database instance in PostgreSQL.
    * Execute the SQL scripts found in the project folder to create all the necessary tables and stored procedures.

3.  **Configure the server**:
    * Edit config file in`./build/rel/Config` or `./build/dbg/Config` file to set your database connection string and server settings.

4.  **Build and run**:
    * Open the `PointBlankServer.sln` file in Visual Studio.
    * Select your desired build configuration (`Debug` or `Release`) and build the solution.
    * Run the compiled executable (e.g., `StartServer.cmd`) from the `build/rel` or `build/dbg` directory.

---

## Disclaimer and License

**Disclaimer**: This project is for personal and educational use only. It is not affiliated with, endorsed by, or sponsored by Zepetto or any other official Point Blank developers. Please do not use this code for any commercial purposes, as it may violate intellectual property rights.

**License**: This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

## Contributing

If you'd like to contribute, feel free to fork the repository and submit a pull request with your
