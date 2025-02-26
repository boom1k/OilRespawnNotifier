# OilRespawnNotifier

A simple Rust Oxide plugin that notifies players when Oil Rigs and Large Oil respawn every 1 hour.

## Features

- **Color-coded messages**:
  - **3 seconds left**: Yellow
  - **2 seconds left**: Orange
  - **1 second left**: Red
  - **After respawn**: Green (announcing Oil Rigs respawned)
  
- **1 Hour timer**: The plugin will notify players every 1 hour when the Oil Rig and Large Oil respawn.
  
- **`/timer` Command**: Players can use the `/timer` command to check the time left until the next respawn.

## Installation

1. Download the `OilRespawnNotifier.cs` plugin file.
2. Upload the `.cs` file to the `oxide/plugins` directory of your Rust server.
3. Reload or restart your server.

Once installed, the plugin will automatically start running every 1 hour, and players will be notified with color-coded messages as the respawn time approaches.

## Commands

- `/timer`: Displays the time left until the next Oil Rig and Large Oil respawn in the format `HH:mm:ss`.

## Configuration

There is no configuration file for this plugin. The plugin works with default settings:

- **Respawn time**: Every 1 hour.
- **Color-coded messages** for the last 3, 2, and 1 seconds before respawn.
- **`spawn.fill_groups`** command will be executed on each respawn.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Changelog

### 1.2
- Reverted timer back to 1 hour.
- Added colored messages for the last 3, 2, and 1 seconds before respawn.
- Added `/timer` command to check remaining time.
